/* ==========================================================================
   Anchor IT — layout.js
   Loads the shared header / sidenav / footer partials into any page that
   has the matching placeholders, then wires up the interactive bits
   (sidebar collapse, mobile drawer, active nav highlighting).

   Usage in a page:
     <div id="appHeader"></div>
     <div id="appSidenav"></div>
     ... page content ...
     <div id="appFooter"></div>
     <script>var ANCHOR_PAGE = "tickets";</script>   // matches data-page on a sidenav-link
     <script src="assets/js/layout.js"></script>
   ========================================================================== */

(function ($) {
  "use strict";

  var PARTIALS_PATH = "partials/";

  function loadPartials(done) {
    var pending = 0;
    var targets = [
      { sel: "#appHeader", file: "header.html" },
      { sel: "#appSidenav", file: "sidenav.html" },
      { sel: "#appFooter", file: "footer.html" }
    ];

    targets.forEach(function (t) {
      var $el = $(t.sel);
      if ($el.length === 0) return;
      pending++;
      $el.load(PARTIALS_PATH + t.file, function () {
        pending--;
        if (pending === 0 && typeof done === "function") done();
      });
    });

    if (pending === 0 && typeof done === "function") done();
  }

  function highlightActiveLink() {
    var page = window.ANCHOR_PAGE;
    if (!page) return;
    $(".sidenav-link[data-page='" + page + "']").addClass("active");
  }

  function wireSidenavToggle() {
    $(document).on("click", "#sidenavToggle", function () {
      if ($(window).width() < 992) {
        $("body").toggleClass("app-shell--mobile-open");
      } else {
        $("body").toggleClass("app-shell--collapsed");
      }
    });

    // Close the mobile drawer when a nav link is tapped
    $(document).on("click", ".sidenav-link", function () {
      if ($(window).width() < 992) {
        $("body").removeClass("app-shell--mobile-open");
      }
    });
  }

  function wireDropdowns() {
    // Bootstrap's own JS handles .dropdown-toggle; nothing extra needed here,
    // this hook exists so app-specific dropdown behaviour has a home later.
  }

  $(function () {
    loadPartials(function () {
      highlightActiveLink();
      wireSidenavToggle();
      wireDropdowns();
    });
  });
})(jQuery);
