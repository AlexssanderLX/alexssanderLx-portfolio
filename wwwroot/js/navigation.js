(function () {
    document.addEventListener("DOMContentLoaded", () => {
        const navToggle = document.querySelector("[data-nav-toggle]");
        const mobileMenu = document.querySelector("[data-mobile-menu]");
        const desktopQuery = window.matchMedia("(min-width: 1041px)");

        if (!navToggle || !mobileMenu) {
            return;
        }

        const closeMenu = () => {
            mobileMenu.classList.remove("is-open");
            navToggle.setAttribute("aria-expanded", "false");
            navToggle.setAttribute("aria-label", "Open navigation menu");
        };

        const toggleMenu = () => {
            const isOpen = mobileMenu.classList.toggle("is-open");
            navToggle.setAttribute("aria-expanded", String(isOpen));
            navToggle.setAttribute("aria-label", isOpen ? "Close navigation menu" : "Open navigation menu");
        };

        navToggle.addEventListener("click", toggleMenu);

        mobileMenu.querySelectorAll("a").forEach(link => {
            link.addEventListener("click", closeMenu);
        });

        document.addEventListener("keydown", event => {
            if (event.key === "Escape") {
                closeMenu();
                navToggle.focus();
            }
        });

        desktopQuery.addEventListener("change", event => {
            if (event.matches) {
                closeMenu();
            }
        });
    });
})();
