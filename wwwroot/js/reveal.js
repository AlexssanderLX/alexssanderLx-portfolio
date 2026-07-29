(function () {
    document.addEventListener("DOMContentLoaded", () => {
        const revealItems = Array.from(document.querySelectorAll("[data-reveal]"));
        const motionMode = document.documentElement.dataset.motionMode || "full";

        if (revealItems.length === 0) {
            return;
        }

        if (motionMode !== "full" || !("IntersectionObserver" in window)) {
            revealItems.forEach(item => item.classList.add("is-visible"));
            return;
        }

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
    });
})();
