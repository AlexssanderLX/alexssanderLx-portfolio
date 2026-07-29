# Frontend foundation - AlexssanderLX Portfolio

This document defines the first shared visual and technical foundation for the portfolio.
Future agents should extend pages without redesigning the global foundation unless explicitly assigned to do so.

## Architecture

The project remains ASP.NET Core MVC/Razor with vanilla CSS and JavaScript.

Shared files:

- `Views/Shared/_Layout.cshtml`
- `wwwroot/css/tokens.css`
- `wwwroot/css/base.css`
- `wwwroot/css/layout.css`
- `wwwroot/css/components.css`
- `wwwroot/css/motion.css`
- `wwwroot/js/capabilities.js`
- `wwwroot/js/navigation.js`
- `wwwroot/js/reveal.js`
- `wwwroot/js/ambient.js`
- `wwwroot/js/site.js`

Homepage-only files:

- `Views/Home/Index.cshtml`
- `wwwroot/css/pages/home.css`
- `wwwroot/js/home-motion.js`

Legacy support:

- `wwwroot/css/site.css` still carries existing global and project-page styles.
- Existing Razor scoped CSS still compiles into `ClientBlog.styles.css`.
- Do not delete legacy CSS until each internal page has been migrated safely.

## Tokens

Tokens live in `wwwroot/css/tokens.css`.

Main groups:

- Colors: `--color-bg`, `--color-surface`, `--color-text`, `--color-muted`, `--color-accent`, `--color-cyan`.
- Borders: `--color-border`, `--color-border-strong`.
- Glow/shadow: `--glow-accent`, `--glow-cyan`, `--shadow-soft`, `--shadow-strong`.
- Layout: `--container-main`, `--container-wide`, `--readable`.
- Spacing: `--space-*`.
- Radius: `--radius-*`.
- Typography: `--font-body`, `--font-display`, `--font-mono`, `--step-*`.
- Motion: `--motion-fast`, `--motion-base`, `--motion-slow`, `--ease-out`, `--ease-in-out`.
- Z-index: `--z-*`.

Use these tokens instead of hardcoded colors and spacing when creating new pages.

## CSS convention

Use page-prefixed classes for page-specific UI:

- Homepage: `home-*`.
- Future development page: `dev-*` or `development-*`.
- Future infrastructure page: `infra-*`.
- Future security page: `security-*`.
- Future music page: `music-*`.

Use shared `ui-*` classes for reusable components:

- `ui-kicker`
- `ui-title`
- `ui-title--hero`
- `ui-gradient-text`
- `ui-description`
- `ui-actions`
- `ui-button`
- `ui-button--primary`
- `ui-button--ghost`
- `ui-card`
- `ui-panel`
- `ui-badge`
- `ui-section-heading`

Avoid adding homepage-specific styles to global CSS files.

## JavaScript convention

Global scripts:

- `capabilities.js`: defines `data-motion-mode` and `data-pointer` on `<html>`.
- `navigation.js`: owns global navbar behavior.
- `reveal.js`: owns `[data-reveal]`.
- `ambient.js`: owns binary background.
- `site.js`: owns legacy tabs, terminal tabs and copy buttons.

Page-specific scripts should be loaded with Razor `@section Scripts`.
The homepage loads `home-motion.js` only on the homepage.

Do not add page-specific cinematic behavior to `site.js`.

## Motion rules

Motion modes:

- `full`: desktop-capable experience.
- `reduced`: smaller/coarse/low-resource experience.
- `none`: `prefers-reduced-motion: reduce`.

Rules:

- Animate only `transform` and `opacity` whenever possible.
- No autoplay audio.
- No WebGL or Three.js in this foundation.
- No GSAP in this foundation.
- No Lenis in this foundation.
- Mobile should use natural vertical scroll, not long pinning.
- Content must remain visible without JavaScript-enhanced motion.

## Breakpoints

Current practical breakpoints:

- `1060px`: homepage two-column layouts collapse.
- `1040px`: global navbar switches to mobile.
- `860px`: shared grids collapse.
- `700px`: motion and homepage layout reduce.
- `640px`: compact navigation and buttons.

Test new pages at 320, 360, 390, 412, 768, 1024, 1366 and 1920px.

## Navigation and CTA pattern

Global navbar is intentionally small:

- Início
- Perfil
- Contato
- Iniciar projeto

Specific professional paths are presented inside the homepage and footer, not all in the navbar.

Valid current destinations:

- `/Home/Projects`
- `/Home/Projects#dev`
- `/Home/Projects#pentest`
- `/Home/Projects#music`
- `/Home/About`
- `/Home/Contact`
- `/Home/Rights`

Do not expose CTAs to routes that do not exist.
If a future page is not ready, link to a valid existing page or contact.

## Homepage structure

The new homepage presents:

1. Hero with positioning.
2. Professional paths.
3. Product previews.
4. Infrastructure/automation visual flow.
5. Security and music transition.
6. Final CTA.

Confirmed projects used on the homepage:

- ZeroPaper
- LedgerFlow
- StoreFlow
- CTF/security track
- Music compositions via existing music project page

Absent or not confirmed in this repository:

- Your Rhythm Studio
- Job Radar
- Piano virtual
- Audio experience

Do not invent details for absent projects.

## Accessibility rules

- Keep one H1 per page.
- Preserve keyboard focus states.
- Use real buttons for interactive controls.
- Use `aria-hidden="true"` for decorative elements.
- Avoid corrupted icon text.
- Do not make motion required for understanding content.
- Do not autoplay audio.
- Maintain minimum touch targets around 44px.

## Files future agents should not edit without coordination

- `Views/Shared/_Layout.cshtml`
- `wwwroot/css/tokens.css`
- `wwwroot/css/base.css`
- `wwwroot/css/layout.css`
- `wwwroot/css/components.css`
- `wwwroot/css/motion.css`
- `wwwroot/js/capabilities.js`
- `wwwroot/js/navigation.js`
- `wwwroot/js/reveal.js`
- `wwwroot/js/ambient.js`
- `wwwroot/js/site.js`
- `Views/Home/Index.cshtml`
- `wwwroot/css/pages/home.css`
- `wwwroot/js/home-motion.js`

## How to create new internal pages

1. Add or reuse a `HomeController` action only if the route is ready to display useful content.
2. Create a Razor View for the page.
3. Create page-specific CSS under `wwwroot/css/pages/{page}.css`.
4. Load page CSS via `@section Styles`.
5. Create page-specific JS under `wwwroot/js/{page}.js` only when needed.
6. Load page JS via `@section Scripts`.
7. Use shared `ui-*` classes for cards, buttons, badges and headings.
8. Do not edit the homepage to add deep content; add only valid links when the page is ready.

## Pending destinations

Future internal pages can be created later for:

- Development and SaaS products.
- Infrastructure, cloud and automations.
- Security, DevSecOps and pentest.
- Music, piano, composition and lessons.

Until those pages exist, homepage CTAs must point to valid current pages or contact.
