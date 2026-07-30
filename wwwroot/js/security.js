/* AlexssanderLX — Security page interactions
   Mouse glow, stagger entry, terminal typing.
   Loaded only on /Home/Security via @section Scripts. */
(function () {
    "use strict";

    /* ── Mouse spotlight glow ── */
    function initGlow() {
        document.querySelectorAll("[data-glow]").forEach(function (card) {
            card.addEventListener("mousemove", function (e) {
                var rect = card.getBoundingClientRect();
                card.style.setProperty("--mx", (e.clientX - rect.left) + "px");
                card.style.setProperty("--my", (e.clientY - rect.top)  + "px");
            });
            card.addEventListener("mouseleave", function () {
                card.style.removeProperty("--mx");
                card.style.removeProperty("--my");
            });
        });
    }

    /* ── Stagger index on grid children ── */
    function initStagger() {
        document.querySelectorAll("[data-stagger-group]").forEach(function (group) {
            Array.from(group.children).forEach(function (child, i) {
                child.style.setProperty("--stagger-i", i);
            });
        });
    }

    /* ── Terminal typing animation ── */
    function initTyping() {
        var el = document.getElementById("secTerminalPrompt");
        if (!el) return;

        var text  = el.dataset.text || "";
        var delay = 900; // ms before start
        var speed = 45;  // ms per char

        el.textContent = "";
        var i = 0;

        setTimeout(function () {
            var timer = setInterval(function () {
                if (i < text.length) {
                    el.textContent += text[i++];
                } else {
                    clearInterval(timer);
                }
            }, speed);
        }, delay);
    }

    /* ── Focus dimming: un-hovered siblings fade back ── */
    function initFocusDim() {
        var groups = document.querySelectorAll("[data-stagger-group]");
        groups.forEach(function (group) {
            var items = Array.from(group.children);

            group.addEventListener("mouseover", function (e) {
                var card = e.target.closest("[data-glow]");
                if (!card) return;
                items.forEach(function (item) {
                    item.style.transition = "opacity 200ms ease";
                    item.style.opacity    = item === card ? "1" : "0.45";
                });
            });

            group.addEventListener("mouseleave", function () {
                items.forEach(function (item) {
                    item.style.opacity = "";
                });
            });
        });
    }

    /* ── Chain step hover ripple ── */
    function initChain() {
        document.querySelectorAll(".sec-chain-step").forEach(function (step, i) {
            step.addEventListener("mouseenter", function () {
                step.style.setProperty("--chain-i", i);
            });
        });
    }

    /* ── Boot ── */
    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", boot);
    } else {
        boot();
    }

    function boot() {
        initGlow();
        initStagger();
        initTyping();
        initFocusDim();
        initChain();
    }
})();
