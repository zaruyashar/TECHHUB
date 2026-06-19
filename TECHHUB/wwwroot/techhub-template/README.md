# Anchor IT — admin template

IT Helpdesk &amp; Asset Tracker admin template. Plain HTML + Bootstrap 5 + jQuery —
no build step, no tag helpers. Theme: Navy &amp; Cyan Tech.

## Structure

```
anchor-it-template/
├── _layout-template.html   ← copy this for every new page
├── index.html              ← Dashboard (assembled example)
├── tickets.html             SupportTickets (user CRUD)
├── hardware.html             HardwareInventory (admin CRUD)
├── licenses.html             SoftwareLicenses (admin CRUD)
├── login.html
├── signup.html
├── partials/
│   ├── header.html          top navbar
│   ├── sidenav.html         left sidebar / nav
│   └── footer.html
└── assets/
    ├── css/theme.css         all design tokens + components
    └── js/layout.js          loads the partials, wires up the sidebar toggle
```

## How the shared layout works

There's no server-side templating here, so the "shared layout" is done the
jQuery way: every page that isn't a full-screen auth screen includes three
empty placeholder divs —

```html
<div id="appHeader"></div>
<div id="appSidenav"></div>
<!-- page content -->
<div id="appFooter"></div>
```

`assets/js/layout.js` runs on page load, does an `.load()` AJAX call for
each placeholder from `partials/`, then highlights the correct sidebar item
based on a `window.ANCHOR_PAGE` value you set per page (it matches a
`data-page` attribute in `partials/sidenav.html`).

To edit the navbar, sidebar, or footer everywhere at once, edit the one file
in `partials/` — every page picks up the change automatically next load.
No editing the markup on each page individually.

Note: because the partials load via `fetch`/AJAX, opening these files
directly as `file://` in some browsers will block the request (CORS on
local files). Serve the folder with any static server while developing,
e.g. `npx serve .` or VS Code's "Live Server" extension. Once this is
wired into a real backend this won't matter.

## Adding a new page

1. Copy `_layout-template.html`, rename it.
2. Update `<title>`.
3. Set `window.ANCHOR_PAGE` to a value that matches a `data-page` in
   `partials/sidenav.html` (add a new `<a class="sidenav-link" data-page="...">`
   there if it's a new section).
4. Replace the markup between the `PAGE CONTENT START/END` comments.

## Component reference

- Buttons: `.btn-primary`, `.btn-outline-primary`, `.btn-dark-navy`, `.btn-icon` (square icon-only button)
- Status pills: `.status-pill.urgency-low|medium|high|critical` (tickets), `.status-pill.state-active|expiring|expired` (hardware/licenses)
- Stat cards: `.stat-card` + `.stat-icon.icon-cyan|amber|orange|green|navy`
- Tables: standard `.table` inside a `.card.table-card`; pair with `.row-id` / `.row-serial` / `.row-key` on cells holding ticket IDs, serial numbers, or license keys (monospace)
- Sidebar collapses to an icon rail on desktop (toggle button) and a slide-out drawer on mobile, both via the same `#sidenavToggle` button

## Color tokens

See the top of `assets/css/theme.css` for the full token list. Quick reference:

| Token | Hex | Use |
|---|---|---|
| `--navy-900` | #0b1220 | topnav / sidenav background |
| `--cyan-500` | #0ea5e9 | primary buttons, links, active states |
| `--slate-50` | #f4f6f9 | page background |
| `--success-dot` | #10b981 | active / resolved |
| `--warning-dot` | #f59e0b | medium urgency / expiring soon |
| `--high-dot` | #f97316 | high urgency |
| `--danger-dot` | #ef4444 | critical urgency / expired |
