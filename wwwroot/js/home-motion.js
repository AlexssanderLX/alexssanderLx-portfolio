(function () {
    document.addEventListener("DOMContentLoaded", () => {
        const root = document.documentElement;
        const motionMode = root.dataset.motionMode || "full";
        const identity = document.querySelector(".home-identity");

        if (!identity || motionMode !== "full" || window.matchMedia("(max-width: 900px)").matches) {
            return;
        }

        let ticking = false;

        const updateIdentity = () => {
            const rect = identity.getBoundingClientRect();
            const progress = Math.min(Math.max((window.innerHeight - rect.top) / (window.innerHeight + rect.height), 0), 1);
            const lift = (progress - 0.5) * -18;
            const scale = 1 + progress * 0.018;
            identity.style.transform = `translate3d(0, ${lift}px, 0) scale(${scale})`;
            ticking = false;
        };

        const requestUpdate = () => {
            if (ticking || document.hidden) {
                return;
            }

            ticking = true;
            window.requestAnimationFrame(updateIdentity);
        };

        updateIdentity();
        window.addEventListener("scroll", requestUpdate, { passive: true });
        window.addEventListener("resize", requestUpdate);
        document.addEventListener("visibilitychange", requestUpdate);
    });
})();
