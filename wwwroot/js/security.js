/* AlexssanderLX - Security page interactions.
   Heavy pointer effects only run when the global performance gate allows them. */
(function () {
    "use strict";

    var root = document.documentElement;
    var motionMode = root.dataset.motionMode || "full";
    var effectsBudget = root.dataset.effectsBudget || "full";
    var coarsePointer = window.matchMedia("(pointer: coarse)").matches;
    var fullEffects = motionMode === "full" && effectsBudget === "full" && !coarsePointer;

    function initGlow() {
        if (!fullEffects) return;

        document.querySelectorAll("[data-glow]").forEach(function (card) {
            card.addEventListener("mousemove", function (event) {
                var rect = card.getBoundingClientRect();
                card.style.setProperty("--mx", (event.clientX - rect.left) + "px");
                card.style.setProperty("--my", (event.clientY - rect.top) + "px");
            });

            card.addEventListener("mouseleave", function () {
                card.style.removeProperty("--mx");
                card.style.removeProperty("--my");
            });
        });
    }

    function initStagger() {
        if (effectsBudget === "minimal") return;

        document.querySelectorAll("[data-stagger-group]").forEach(function (group) {
            Array.from(group.children).forEach(function (child, index) {
                child.style.setProperty("--stagger-i", index);
            });
        });
    }

    function initTyping() {
        var el = document.getElementById("secTerminalPrompt");
        if (!el) return;

        var text = el.dataset.text || "";
        if (!fullEffects) {
            el.textContent = text;
            return;
        }

        var delay = 900;
        var speed = 45;
        var index = 0;
        el.textContent = "";

        window.setTimeout(function () {
            var timer = window.setInterval(function () {
                if (index < text.length) {
                    el.textContent += text[index];
                    index += 1;
                } else {
                    window.clearInterval(timer);
                }
            }, speed);
        }, delay);
    }

    function initFocusDim() {
        if (!fullEffects) return;

        document.querySelectorAll("[data-stagger-group]").forEach(function (group) {
            var items = Array.from(group.children);

            group.addEventListener("mouseover", function (event) {
                var card = event.target.closest("[data-glow]");
                if (!card) return;

                items.forEach(function (item) {
                    item.style.transition = "opacity 200ms ease";
                    item.style.opacity = item === card ? "1" : "0.45";
                });
            });

            group.addEventListener("mouseleave", function () {
                items.forEach(function (item) {
                    item.style.opacity = "";
                });
            });
        });
    }

    function initChain() {
        if (!fullEffects) return;

        document.querySelectorAll(".sec-chain-step").forEach(function (step, index) {
            step.addEventListener("mouseenter", function () {
                step.style.setProperty("--chain-i", index);
            });
        });
    }

    function boot() {
        initGlow();
        initStagger();
        initTyping();
        initFocusDim();
        initChain();
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", boot);
    } else {
        boot();
    }
})();
