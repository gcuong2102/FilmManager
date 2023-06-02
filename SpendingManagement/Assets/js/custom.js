$(".image-slide").each(function (index, value) {
    $(value).css('min-height', '700px')
    $(value).css('max-height', '700px')
    $(value).css('filter', 'brightness(70%)')
})
var nav_menu = $(".container-fluid.sticky-top.bg-light");
var nav_logo = $("#nav_logo");
$(window).scroll(function () {
    var scroll = parseFloat($(window).scrollTop());
    var max = $(document).height() - $(window).height();
    if (scroll == 0) {
        if (nav_menu.hasClass('bg-light')) {
            nav_menu.removeClass('transparent-menu');
            setHeightLogo(60);
            return;
        }
        else {
            nav_menu.removeClass('transparent-menu');
            nav_menu.addClass('bg-light');
            setHeightLogo(60);
        }
    }
    else {
        setHeightLogo(0)
        nav_menu.removeClass('bg-light');
        nav_menu.addClass('transparent-menu');
    }
})
function setHeightLogo(height) {
    nav_logo.height(height);
}

