(function () {
    const page = document.querySelector("[data-experience-page]");
    if (!page) {
        return;
    }

    const reduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches ||
        document.documentElement.dataset.motion === "off";

    const revealTargets = page.querySelectorAll("[data-reveal], .experience-section");
    if ("IntersectionObserver" in window) {
        const observer = new IntersectionObserver((entries) => {
            entries.forEach((entry) => {
                if (entry.isIntersecting) {
                    entry.target.classList.add("is-revealed");
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.16 });

        revealTargets.forEach((target, index) => {
            target.style.setProperty("--reveal-delay", `${Math.min(index * 55, 440)}ms`);
            observer.observe(target);
        });
    } else {
        revealTargets.forEach((target) => target.classList.add("is-revealed"));
    }

    if (reduceMotion || window.matchMedia("(pointer: coarse)").matches) {
        return;
    }

    const depthTargets = page.querySelectorAll("[data-depth-panel], .ui-card, .sec-vuln-panel, .sec-ctf-featured, .music-studio-inner");
    depthTargets.forEach((card) => {
        card.addEventListener("pointermove", (event) => {
            const rect = card.getBoundingClientRect();
            const x = event.clientX - rect.left;
            const y = event.clientY - rect.top;
            const rotateY = ((x / rect.width) - 0.5) * 8;
            const rotateX = (((y / rect.height) - 0.5) * -8);

            card.style.setProperty("--mx", `${x}px`);
            card.style.setProperty("--my", `${y}px`);
            card.style.transform = `perspective(900px) rotateX(${rotateX.toFixed(2)}deg) rotateY(${rotateY.toFixed(2)}deg) translateY(-4px)`;
        });

        card.addEventListener("pointerleave", () => {
            card.style.removeProperty("--mx");
            card.style.removeProperty("--my");
            card.style.transform = "";
        });
    });
})();
