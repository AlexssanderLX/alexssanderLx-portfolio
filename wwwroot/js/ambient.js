(function () {
    document.addEventListener("DOMContentLoaded", () => {
        if (document.querySelector(".binary-rain")) {
            return;
        }

        const motionMode = document.documentElement.dataset.motionMode || "full";
        if (motionMode === "none") {
            return;
        }

        const layer = document.createElement("div");
        layer.className = "binary-rain";
        layer.setAttribute("aria-hidden", "true");

        const bitCount = motionMode === "full" ? 72 : 18;

        for (let index = 0; index < bitCount; index += 1) {
            const bit = document.createElement("span");
            bit.className = `binary-bit${index % 7 === 0 ? " cyan" : ""}`;
            bit.textContent = Math.random() > 0.5 ? "1" : "0";
            bit.style.left = `${Math.random() * 100}%`;
            bit.style.setProperty("--bit-size", `${0.72 + Math.random() * 0.72}rem`);
            bit.style.setProperty("--bit-duration", `${8 + Math.random() * 10}s`);
            bit.style.setProperty("--bit-delay", `${Math.random() * -14}s`);
            bit.style.setProperty("--bit-opacity", `${0.2 + Math.random() * 0.38}`);
            bit.style.setProperty("--bit-drift", `${-22 + Math.random() * 44}px`);
            layer.appendChild(bit);
        }

        document.body.prepend(layer);
    });
})();
