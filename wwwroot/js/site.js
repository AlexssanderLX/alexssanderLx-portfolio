document.addEventListener("DOMContentLoaded", () => {
    const tabs = Array.from(document.querySelectorAll(".tab"));
    const panels = Array.from(document.querySelectorAll(".tab-content"));

    const activateTab = button => {
        const targetId = button.dataset.tab;
        if (!targetId) {
            return;
        }

        tabs.forEach(tab => {
            const isActive = tab === button;
            tab.classList.toggle("active", isActive);
            tab.setAttribute("aria-selected", isActive ? "true" : "false");
            tab.tabIndex = isActive ? 0 : -1;
        });

        panels.forEach(panel => {
            const isActive = panel.id === targetId;
            panel.classList.toggle("active", isActive);
            panel.hidden = !isActive;
        });
    };

    tabs.forEach((button, index) => {
        button.addEventListener("click", () => {
            activateTab(button);

            if (button.dataset.tab) {
                history.replaceState(null, "", `#${button.dataset.tab}`);
            }
        });
        button.addEventListener("keydown", event => {
            if (!["ArrowLeft", "ArrowRight", "Home", "End"].includes(event.key)) {
                return;
            }

            event.preventDefault();

            let nextIndex = index;

            if (event.key === "ArrowRight") {
                nextIndex = (index + 1) % tabs.length;
            } else if (event.key === "ArrowLeft") {
                nextIndex = (index - 1 + tabs.length) % tabs.length;
            } else if (event.key === "Home") {
                nextIndex = 0;
            } else if (event.key === "End") {
                nextIndex = tabs.length - 1;
            }

            tabs[nextIndex].focus();
            activateTab(tabs[nextIndex]);
        });
    });

    const activateTabFromHash = () => {
        const hashTarget = window.location.hash ? window.location.hash.slice(1) : "";
        const activeTab = tabs.find(tab => tab.dataset.tab === hashTarget)
            ?? tabs.find(tab => tab.classList.contains("active"))
            ?? tabs[0];

        if (activeTab) {
            activateTab(activeTab);
        }
    };

    activateTabFromHash();
    window.addEventListener("hashchange", activateTabFromHash);

    const terminalTabs = Array.from(document.querySelectorAll("[data-terminal-tab]"));
    const terminalPanels = Array.from(document.querySelectorAll(".terminal-panel"));

    const activateTerminalTab = button => {
        const targetId = button.dataset.terminalTab;
        if (!targetId) {
            return;
        }

        terminalTabs.forEach(tab => {
            const isActive = tab === button;
            tab.classList.toggle("active", isActive);
            tab.setAttribute("aria-selected", isActive ? "true" : "false");
        });

        terminalPanels.forEach(panel => {
            const isActive = panel.id === targetId;
            panel.classList.toggle("active", isActive);
            panel.hidden = !isActive;
        });
    };

    terminalTabs.forEach(button => {
        button.addEventListener("click", () => activateTerminalTab(button));
    });

    const isCompactViewport = window.matchMedia("(max-width: 700px)").matches;

    const mountBinaryRain = () => {
        if (document.querySelector(".binary-rain")) {
            return;
        }

        const binaryReduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
        if (binaryReduceMotion) {
            return;
        }

        const layer = document.createElement("div");
        layer.className = "binary-rain";
        layer.setAttribute("aria-hidden", "true");

        const bitCount = isCompactViewport ? 18 : 86;

        for (let index = 0; index < bitCount; index += 1) {
            const bit = document.createElement("span");
            bit.className = `binary-bit${index % 7 === 0 ? " cyan" : ""}`;
            bit.textContent = Math.random() > 0.5 ? "1" : "0";
            bit.style.left = `${Math.random() * 100}%`;
            bit.style.setProperty("--bit-size", `${0.72 + Math.random() * 0.78}rem`);
            bit.style.setProperty("--bit-duration", `${7 + Math.random() * 9}s`);
            bit.style.setProperty("--bit-delay", `${Math.random() * -14}s`);
            bit.style.setProperty("--bit-opacity", `${0.22 + Math.random() * 0.46}`);
            bit.style.setProperty("--bit-drift", `${-24 + Math.random() * 48}px`);
            layer.appendChild(bit);
        }

        document.body.prepend(layer);
    };

    mountBinaryRain();

    const revealItems = Array.from(document.querySelectorAll("[data-reveal]"));
    const reduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches;

    if (revealItems.length > 0) {
        if (reduceMotion || isCompactViewport || !("IntersectionObserver" in window)) {
            revealItems.forEach(item => item.classList.add("is-visible"));
        } else {
            const revealObserver = new IntersectionObserver(entries => {
                entries.forEach(entry => {
                    if (!entry.isIntersecting) {
                        return;
                    }

                    entry.target.classList.add("is-visible");
                    revealObserver.unobserve(entry.target);
                });
            }, {
                threshold: 0.18,
                rootMargin: "0px 0px -8% 0px"
            });

            revealItems.forEach((item, index) => {
                item.style.transitionDelay = `${Math.min(index * 70, 280)}ms`;
                revealObserver.observe(item);
            });
        }
    }

    document.querySelectorAll("[data-copy-text]").forEach(button => {
        button.addEventListener("click", async () => {
            const text = button.getAttribute("data-copy-text");
            if (!text) {
                return;
            }

            const originalLabel = button.textContent;

            try {
                if (navigator.clipboard && window.isSecureContext) {
                    await navigator.clipboard.writeText(text);
                } else {
                    fallbackCopyText(text);
                }

                button.textContent = "Copied";
            } catch {
                button.textContent = "Copy failed";
            }

            window.setTimeout(() => {
                button.textContent = originalLabel;
            }, 1800);
        });
    });
});

function fallbackCopyText(text) {
    const helper = document.createElement("textarea");
    helper.value = text;
    helper.setAttribute("readonly", "");
    helper.style.position = "absolute";
    helper.style.left = "-9999px";
    document.body.appendChild(helper);
    helper.select();
    document.execCommand("copy");
    helper.remove();
}
