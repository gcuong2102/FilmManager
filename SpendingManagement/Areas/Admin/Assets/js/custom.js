function setActiveMenu() {
    let menu = $('.nav.navbar-nav');
    let listMenu = menu.find('li.menu-item-has-children');
    let currentLink = window.location.pathname;
    $.each(listMenu, function (index, value) {
        let menuZone = value;
        $.each($(value).find('li'), function (index, value) {
            let link = $(value).find('a').attr('href');
            if (currentLink.indexOf(link) != -1) {
                $(menuZone).addClass('show');
                $(menuZone).find('ul').addClass('show');
                $(value).find('a').css('color', '#007bff')
                $(value).find('i').css('color', '#007bff')
                $(menuZone).find('a').first().css('color', '#007bff')
                $(menuZone).find('a').first().find('i').css('color', '#007bff')
                return false;
            }
        })
        if ($(menuZone).hasClass('show')) {
            return false;
        }
    })
}
//Call Function
setActiveMenu()
