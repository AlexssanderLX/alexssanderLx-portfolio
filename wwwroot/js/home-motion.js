(function () {
    const root = document.documentElement;
    const home = document.querySelector(".home-cinematic");

    if (!home) {
        return;
    }

    const motionMode = root.dataset.motionMode || "full";
    const isNoMotion = motionMode === "none";
    const isReduced = motionMode === "reduced";
    const hasFinePointer = root.dataset.pointer === "fine" && window.matchMedia("(hover: hover)").matches;
    const canObserve = "IntersectionObserver" in window;
    const canAnimate = typeof Element !== "undefined" && Element.prototype.animate;

    const safeSession = {
        get(key) {
            try {
                return window.sessionStorage.getItem(key);
            } catch {
                return null;
            }
        },
        set(key, value) {
            try {
                window.sessionStorage.setItem(key, value);
            } catch {
                // Motion must never depend on storage support.
            }
        }
    };

    const setDelay = element => {
        const delay = Number(element.dataset.motionDelay || 0);
        element.style.setProperty("--motion-delay", `${Math.max(delay, 0)}ms`);
    };

    const revealImmediately = () => {
        home.querySelectorAll("[data-motion-origin], [data-hero-step]").forEach(element => {
            element.classList.add("is-cinematic-visible", "is-hero-visible");
            element.style.removeProperty("will-change");
        });

        home.querySelectorAll("[data-pipeline-step]").forEach(element => {
            element.classList.add("is-pipeline-lit");
        });

        home.querySelectorAll("[data-motion-sequence='pipeline']").forEach(element => {
            element.classList.add("is-pipeline-active");
        });
    };

    const runIntro = () => {
        const intro = home.querySelector("[data-home-intro]");
        const hasSeenIntro = safeSession.get("alexlx-home-intro") === "seen";

        if (!intro || isNoMotion || isReduced || hasSeenIntro || !canAnimate) {
            safeSession.set("alexlx-home-intro", "seen");
            return Promise.resolve();
        }

        const bar = intro.querySelector(".home-intro__mark i");
        const mark = intro.querySelector(".home-intro__mark");

        root.dataset.homeIntroActive = "true";

        const introTimeline = [
            mark.animate([
                { opacity: 0, transform: "translate3d(0, 18px, 0) scale(0.96)" },
                { opacity: 1, transform: "translate3d(0, 0, 0) scale(1)" }
            ], { duration: 620, easing: "cubic-bezier(0.22, 1, 0.36, 1)", fill: "forwards" }).finished
        ];

        if (bar) {
            introTimeline.push(bar.animate([
                { transform: "scaleX(0)" },
                { transform: "scaleX(1)" }
            ], { duration: 1350, delay: 220, easing: "cubic-bezier(0.22, 1, 0.36, 1)", fill: "forwards" }).finished);
        }

        return Promise.allSettled(introTimeline)
            .then(() => new Promise(resolve => window.setTimeout(resolve, 180)))
            .then(() => intro.animate([
                { opacity: 1, clipPath: "inset(0 0 0 0)" },
                { opacity: 0.98, clipPath: "inset(0 0 100% 0)" }
            ], { duration: 620, easing: "cubic-bezier(0.65, 0, 0.35, 1)", fill: "forwards" }).finished)
            .catch(() => undefined)
            .finally(() => {
                root.removeAttribute("data-home-intro-active");
                safeSession.set("alexlx-home-intro", "seen");
            });
    };

    const revealHero = () => {
        home.querySelectorAll("[data-hero-step]").forEach(element => {
            setDelay(element);
            element.classList.add("is-hero-visible");
        });

        const copy = home.querySelector(".home-hero__copy");
        const identity = home.querySelector(".home-identity");

        [copy, identity].filter(Boolean).forEach((element, index) => {
            element.style.setProperty("--motion-delay", `${index * 180}ms`);
            element.classList.add("is-cinematic-visible");
        });
    };

    const setupDirectionalReveals = () => {
        const items = Array.from(home.querySelectorAll("[data-motion-origin]"));

        if (!items.length) {
            return;
        }

        items.forEach(setDelay);

        if (!canObserve || isNoMotion) {
            items.forEach(item => item.classList.add("is-cinematic-visible"));
            return;
        }

        const observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) {
                    return;
                }

                entry.target.classList.add("is-cinematic-visible");
                window.setTimeout(() => {
                    entry.target.style.removeProperty("will-change");
                }, isReduced ? 420 : 900);
                observer.unobserve(entry.target);
            });
        }, {
            threshold: isReduced ? 0.12 : 0.2,
            rootMargin: isReduced ? "0px 0px -4% 0px" : "0px 0px -12% 0px"
        });

        items.forEach(item => observer.observe(item));
    };

    const setupPipeline = () => {
        const pipeline = home.querySelector("[data-motion-sequence='pipeline']");

        if (!pipeline) {
            return;
        }

        const steps = Array.from(pipeline.querySelectorAll("[data-pipeline-step]"));
        const activate = () => {
            pipeline.classList.add("is-pipeline-active");
            steps.forEach((step, index) => {
                window.setTimeout(() => step.classList.add("is-pipeline-lit"), isReduced ? index * 55 : index * 120);
            });
        };

        if (!canObserve || isNoMotion) {
            activate();
            return;
        }

        const observer = new IntersectionObserver(entries => {
            entries.forEach(entry => {
                if (!entry.isIntersecting) {
                    return;
                }

                activate();
                observer.unobserve(entry.target);
            });
        }, { threshold: 0.34 });

        observer.observe(pipeline);
    };

    const setupScrollProgress = () => {
        if (isNoMotion || isReduced) {
            return;
        }

        const chapters = Array.from(home.querySelectorAll("[data-home-chapter]"));
        const identity = home.querySelector(".home-identity");
        let ticking = false;

        const update = () => {
            const viewportCenter = window.innerHeight * 0.5;
            let strongest = 0;

            chapters.forEach(chapter => {
                const rect = chapter.getBoundingClientRect();
                const distance = Math.abs((rect.top + rect.height * 0.35) - viewportCenter);
                const weight = Math.max(0, 1 - distance / window.innerHeight);
                strongest = Math.max(strongest, weight);
            });

            home.style.setProperty("--home-chapter-light", strongest.toFixed(3));

            if (identity && hasFinePointer) {
                const rect = identity.getBoundingClientRect();
                const progress = Math.min(Math.max((window.innerHeight - rect.top) / (window.innerHeight + rect.height), 0), 1);
                identity.style.setProperty("--motion-y", `${((progress - 0.5) * -18).toFixed(2)}px`);
            }

            ticking = false;
        };

        const request = () => {
            if (ticking || document.hidden) {
                return;
            }

            ticking = true;
            window.requestAnimationFrame(update);
        };

        update();
        window.addEventListener("scroll", request, { passive: true });
        window.addEventListener("resize", request);
        document.addEventListener("visibilitychange", request);
    };

    const setupPointerDepth = () => {
        if (!hasFinePointer || isNoMotion || isReduced) {
            return;
        }

        const panels = Array.from(home.querySelectorAll("[data-depth-panel]"));
        let activePanel = null;
        let pointerX = 0;
        let pointerY = 0;
        let ticking = false;

        const update = () => {
            if (!activePanel || document.hidden) {
                ticking = false;
                return;
            }

            const rect = activePanel.getBoundingClientRect();
            const x = (pointerX - rect.left) / rect.width;
            const y = (pointerY - rect.top) / rect.height;
            const strengthMap = {
                hero: 1.85,
                craft: 1.18,
                infra: 1.28,
                "infra-copy": 1.12,
                final: 1.35
            };
            const moveMap = {
                hero: 13,
                craft: 9,
                infra: 10,
                "infra-copy": 8,
                final: 11
            };
            const strength = strengthMap[activePanel.dataset.depthStrength] || 1;
            const tiltX = (0.5 - y) * 6 * strength;
            const tiltY = (x - 0.5) * 7 * strength;
            const move = moveMap[activePanel.dataset.depthStrength] || 8;

            activePanel.style.setProperty("--pointer-x", `${(x * 100).toFixed(2)}%`);
            activePanel.style.setProperty("--pointer-y", `${(y * 100).toFixed(2)}%`);
            activePanel.style.setProperty("--motion-x", `${((x - 0.5) * move).toFixed(2)}px`);
            activePanel.style.setProperty("--motion-y", `${((y - 0.5) * move).toFixed(2)}px`);
            activePanel.style.transform = `perspective(900px) rotateX(${tiltX.toFixed(2)}deg) rotateY(${tiltY.toFixed(2)}deg) translate3d(var(--motion-x, 0), var(--motion-y, 0), 0)`;
            ticking = false;
        };

        panels.forEach(panel => {
            panel.addEventListener("pointerenter", event => {
                activePanel = panel;
                pointerX = event.clientX;
                pointerY = event.clientY;
            });

            panel.addEventListener("pointermove", event => {
                pointerX = event.clientX;
                pointerY = event.clientY;

                if (!ticking) {
                    ticking = true;
                    window.requestAnimationFrame(update);
                }
            });

            panel.addEventListener("pointerleave", () => {
                panel.style.removeProperty("--pointer-x");
                panel.style.removeProperty("--pointer-y");
                panel.style.removeProperty("--motion-x");
                panel.style.removeProperty("--motion-y");
                panel.style.transform = "";
                activePanel = null;
            });
        });
    };

    document.addEventListener("DOMContentLoaded", () => {
        if (isNoMotion) {
            revealImmediately();
            return;
        }

        root.dataset.homeMotionReady = "true";
        setupDirectionalReveals();
        setupPipeline();
        setupScrollProgress();
        setupPointerDepth();

        runIntro().then(revealHero);
    });
})();
