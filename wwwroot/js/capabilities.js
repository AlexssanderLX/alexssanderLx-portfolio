(function () {
    const root = document.documentElement;
    const startedAt = performance.now();
    const reduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
    const coarsePointer = window.matchMedia("(pointer: coarse)").matches;
    const compactViewport = window.matchMedia("(max-width: 760px)").matches;
    const midViewport = window.matchMedia("(max-width: 1120px)").matches;
    const saveData = Boolean(navigator.connection && navigator.connection.saveData);
    const slowConnection = Boolean(navigator.connection && /(^2g$|^3g$|slow-2g)/i.test(navigator.connection.effectiveType || ""));
    const memory = typeof navigator.deviceMemory === "number" ? navigator.deviceMemory : 8;
    const cores = typeof navigator.hardwareConcurrency === "number" ? navigator.hardwareConcurrency : 8;
    const lowMemory = memory <= 4;
    const lowCpu = cores <= 4;

    let performanceTier = "high";
    let motionMode = "full";
    let effectsBudget = "full";

    if (reduceMotion || saveData || slowConnection || memory <= 2 || cores <= 2) {
        performanceTier = "low";
        motionMode = reduceMotion ? "none" : "reduced";
        effectsBudget = "minimal";
    } else if (compactViewport || coarsePointer || lowMemory || lowCpu) {
        performanceTier = "low";
        motionMode = "reduced";
        effectsBudget = "minimal";
    } else if (midViewport) {
        performanceTier = "mid";
        motionMode = "reduced";
        effectsBudget = "light";
    }

    root.dataset.performanceTier = performanceTier;
    root.dataset.motionMode = motionMode;
    root.dataset.effectsBudget = effectsBudget;
    root.dataset.pointer = coarsePointer ? "coarse" : "fine";
    root.dataset.bootState = "booting";

    const markReady = () => {
        const minimumBootTime = effectsBudget === "full" ? 720 : 460;
        const elapsed = performance.now() - startedAt;
        const wait = Math.max(minimumBootTime - elapsed, 0);

        window.setTimeout(() => {
            root.dataset.bootState = "ready";
        }, wait);
    };

    if (document.readyState === "complete") {
        markReady();
    } else {
        window.addEventListener("load", markReady, { once: true });
        window.setTimeout(markReady, 1400);
    }
})();
