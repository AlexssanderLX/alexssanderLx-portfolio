/* AlexssanderLX — Piano Virtual (adapted from YourRhythm Studio)
   Loaded only on /Home/Music via @section Scripts.
   Audio policy: AudioContext created on first user gesture only. */
(function () {
    "use strict";

    var audioCtx   = null;
    var masterGain = null;
    var active = {};

    function initAudio() {
        if (audioCtx) return true;
        var AC = window.AudioContext || window.webkitAudioContext;
        if (!AC) return false;
        try {
            audioCtx   = new AC();
            masterGain = audioCtx.createGain();
            masterGain.gain.value = parseFloat(
                (document.getElementById("pvVolume") || { value: "0.65" }).value
            );
            masterGain.connect(audioCtx.destination);
        } catch (e) { return false; }
        return true;
    }

    var SEMI = { C: 0, D: 2, E: 4, F: 5, G: 7, A: 9, B: 11 };

    function noteToFreq(name) {
        var m = /^([A-G])(#?)(\d)$/.exec(name || "");
        if (!m) return null;
        var midi = (parseInt(m[3], 10) + 1) * 12 + SEMI[m[1]] + (m[2] === "#" ? 1 : 0);
        return 440 * Math.pow(2, (midi - 69) / 12);
    }

    function noteOn(note) {
        if (!initAudio()) return;
        if (audioCtx.state === "suspended") audioCtx.resume().catch(function () {});
        if (active[note]) return;

        var freq = noteToFreq(note);
        if (!freq) return;

        var t   = audioCtx.currentTime;
        var env = audioCtx.createGain();
        env.gain.setValueAtTime(0.0001, t);
        env.gain.linearRampToValueAtTime(0.55, t + 0.012);

        var o1 = audioCtx.createOscillator();
        o1.type = "triangle";
        o1.frequency.value = freq;

        var o2 = audioCtx.createOscillator();
        o2.type = "sine";
        o2.frequency.value = freq * 2;
        var g2 = audioCtx.createGain();
        g2.gain.value = 0.22;
        o2.connect(g2);

        var lp = audioCtx.createBiquadFilter();
        lp.type = "lowpass";
        lp.frequency.value = 3200;

        o1.connect(env);
        g2.connect(env);
        env.connect(lp);
        lp.connect(masterGain);
        o1.start(t);
        o2.start(t);

        active[note] = { o1: o1, o2: o2, env: env };
    }

    function noteOff(note) {
        var n = active[note];
        if (!n) return;
        delete active[note];
        var t = audioCtx ? audioCtx.currentTime : 0;
        try {
            n.env.gain.setValueAtTime(n.env.gain.value, t);
            n.env.gain.exponentialRampToValueAtTime(0.0001, t + 0.45);
            var stop = t + 0.5;
            n.o1.stop(stop);
            n.o2.stop(stop);
        } catch (e) {}
    }

    var volInput = document.getElementById("pvVolume");
    if (volInput) {
        volInput.addEventListener("input", function () {
            if (masterGain) masterGain.gain.value = parseFloat(this.value);
        });
    }

    var piano = document.getElementById("pvPiano");
    if (!piano) return;

    function pressKey(el) {
        el.classList.add("pressed");
        el.setAttribute("aria-pressed", "true");
        noteOn(el.dataset.note);
    }

    function releaseKey(el) {
        el.classList.remove("pressed");
        el.setAttribute("aria-pressed", "false");
        noteOff(el.dataset.note);
    }

    var held = {};

    function topKey(x, y) {
        var hits = document.elementsFromPoint(x, y);
        for (var i = 0; i < hits.length; i++) {
            if (hits[i].classList.contains("pv-key") && piano.contains(hits[i])) {
                return hits[i];
            }
        }
        return null;
    }

    piano.addEventListener("pointerdown", function (e) {
        var key = topKey(e.clientX, e.clientY);
        if (!key) return;
        e.preventDefault();
        try { piano.setPointerCapture(e.pointerId); } catch (_) {}
        held[e.pointerId] = key.dataset.note;
        pressKey(key);
        var hint = document.getElementById("pvHint");
        if (hint) hint.classList.add("pv-hint-hide");
    });

    piano.addEventListener("pointermove", function (e) {
        var prev = held[e.pointerId];
        if (prev === undefined) return;
        var key  = topKey(e.clientX, e.clientY);
        var note = key ? key.dataset.note : null;
        if (note === prev) return;
        if (prev) {
            var oldEl = piano.querySelector('[data-note="' + prev + '"]');
            if (oldEl) releaseKey(oldEl);
        }
        if (key) {
            held[e.pointerId] = note;
            pressKey(key);
        } else {
            delete held[e.pointerId];
        }
    });

    function endPointer(e) {
        var note = held[e.pointerId];
        if (note === undefined) return;
        delete held[e.pointerId];
        var el = piano.querySelector('[data-note="' + note + '"]');
        if (el) releaseKey(el);
    }

    piano.addEventListener("pointerup",     endPointer);
    piano.addEventListener("pointercancel", endPointer);

    var KEY_MAP = {
        "a": "C4",  "w": "C#4", "s": "D4",  "e": "D#4", "d": "E4",
        "f": "F4",  "t": "F#4", "g": "G4",  "y": "G#4", "h": "A4",
        "u": "A#4", "j": "B4",
        "k": "C5",  "o": "C#5", "l": "D5",  "p": "D#5", ";": "E5",
        "z": "F5",  "x": "G5",  "c": "A5",  "v": "B5"
    };

    Object.keys(KEY_MAP).forEach(function (k) {
        var el = piano.querySelector('[data-note="' + KEY_MAP[k] + '"]');
        if (el) el.dataset.key = k.toUpperCase();
    });

    var kbHeld = {};

    document.addEventListener("keydown", function (e) {
        if (e.repeat) return;
        if (e.target.tagName === "INPUT" || e.target.tagName === "TEXTAREA") return;
        var note = KEY_MAP[e.key.toLowerCase()];
        if (!note || kbHeld[note]) return;
        kbHeld[note] = true;
        var el = piano.querySelector('[data-note="' + note + '"]');
        if (el) pressKey(el);
        var hint = document.getElementById("pvHint");
        if (hint) hint.classList.add("pv-hint-hide");
    });

    document.addEventListener("keyup", function (e) {
        var note = KEY_MAP[e.key.toLowerCase()];
        if (!note) return;
        delete kbHeld[note];
        var el = piano.querySelector('[data-note="' + note + '"]');
        if (el) releaseKey(el);
    });

    piano.addEventListener("keydown", function (e) {
        if (e.key !== " " && e.key !== "Enter") return;
        var el = e.target;
        if (!el.classList.contains("pv-key")) return;
        e.preventDefault();
        if (!kbHeld[el.dataset.note]) {
            kbHeld[el.dataset.note] = true;
            pressKey(el);
        }
    });

    piano.addEventListener("keyup", function (e) {
        if (e.key !== " " && e.key !== "Enter") return;
        var el = e.target;
        if (!el.classList.contains("pv-key")) return;
        e.preventDefault();
        delete kbHeld[el.dataset.note];
        releaseKey(el);
    });

    var labelsToggle = document.getElementById("pvLabels");
    if (labelsToggle) {
        labelsToggle.addEventListener("change", function () {
            piano.classList.toggle("show-labels", this.checked);
        });
    }

    // Audio track toggle (Beat_1_YR)
    var trackBtn = document.getElementById("musicTrackBtn");
    var trackAudio = null;

    if (trackBtn) {
        trackBtn.addEventListener("click", function () {
            if (!trackAudio) {
                trackAudio = new Audio("/audio/Beat_1_YR.mp3");
                trackAudio.loop = true;
                trackAudio.volume = 0.45;
            }
            if (trackAudio.paused) {
                trackAudio.play().catch(function () {});
                trackBtn.setAttribute("aria-pressed", "true");
                trackBtn.querySelector(".track-label").textContent = "Stop track";
                trackBtn.classList.add("track-active");
            } else {
                trackAudio.pause();
                trackAudio.currentTime = 0;
                trackBtn.setAttribute("aria-pressed", "false");
                trackBtn.querySelector(".track-label").textContent = "Enable track";
                trackBtn.classList.remove("track-active");
            }
        });
    }

    if (!window.AudioContext && !window.webkitAudioContext) {
        var hint = document.getElementById("pvHint");
        if (hint) {
            hint.textContent = "Your browser does not support Web Audio. The visual piano still works.";
            hint.classList.remove("pv-hint-hide");
        }
    }
})();
