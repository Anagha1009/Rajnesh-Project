!function (s) { s.fn.menumaker = function (n) { var i = s(this), e = s.extend({ title: "Menu", format: "dropdown", sticky: !1 }, n); return this.each(function () { return i.prepend('<div id="menu-button">' + e.title + "</div>"), s(this).find("#menu-button").on("click", function () { s(this).toggleClass("menu-opened"); var n = s(this).next("ul"); n.hasClass("open") ? n.hide().removeClass("open") : (n.show().addClass("open"), "dropdown" === e.format && n.find("ul").show()) }), i.find("li ul").parent().addClass("has-sub"), multiTg = function () { i.find(".has-sub").prepend('<span class="submenu-button"></span>'), i.find(".submenu-button").on("click", function () { s(this).toggleClass("submenu-opened"), s(this).siblings("ul").hasClass("open") ? s(this).siblings("ul").removeClass("open").hide() : s(this).siblings("ul").addClass("open").show() }) }, "multitoggle" === e.format ? multiTg() : i.addClass("dropdown"), e.sticky === !0 && i.css("position", "fixed"), resizeFix = function () { s(window).width() > 980 && i.find("ul").show() }, resizeFix(), s(window).on("resize", resizeFix) }) } }(jQuery), function (s) { s(document).ready(function () { s(document).ready(function () { s("#cssmenu").menumaker({ title: "Menu", format: "multitoggle" }), s("#cssmenu").prepend("<div id='menu-line'></div>"); var n, i, e, t, u = !1, o = 0, l = s("#cssmenu #menu-line"); s("#cssmenu > ul > li").each(function () { s(this).hasClass("active") && (n = s(this), u = !0) }), u === !1 && (n = s("#cssmenu > ul > li").first()), t = i = n.width(), e = o = n.position().left, l.css("width", i), l.css("left", o), s("#cssmenu > ul > li").hover(function () { n = s(this), i = n.width(), o = n.position().left, l.css("width", i), l.css("left", o) }, function () { l.css("left", e), l.css("width", t) }) }) }) }(jQuery);