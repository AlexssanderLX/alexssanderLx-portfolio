(function () {
    const root = document.documentElement;
    const reduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
    const coarsePointer = window.matchMedia("(pointer: coarse)").matches;
    const compactViewport = window.matchMedia("(max-width: 700px)").matches;
    const saveData = Boolean(navigator.connection && navigator.connection.saveData);
    const lowMemory = typeof navigator.deviceMemory === "number" && navigator.deviceMemory <= 4;
    const lowCpu = typeof navigator.hardwareConcurrency === "number" && navigator.hardwareConcurrency <= 4;

    let motionMode = "full";

    if (reduceMotion) {
        motionMode = "none";
    } else if (saveData || lowMemory || lowCpu || coarsePointer || compactViewport) {
        motionMode = "reduced";
    }

    root.dataset.motionMode = motionMode;
    root.dataset.pointer = coarsePointer ? "coarse" : "fine";
})();
