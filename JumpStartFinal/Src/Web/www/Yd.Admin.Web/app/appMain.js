$(function () {
    window.touch = $('html').hasClass('touch');
    window.media = $('hr:first').length != 0 ? $('hr:first').css('width').replace('px', '') : 0;

    if (window.touch) {
        $('[data-tooltip]').removeAttr('data-tooltip');
    }

    $(document).foundation();

    if (!window.touch) {
        $('html').niceScroll({
            cursorcolor: '#46bcec',
            cursorwidth: 6,
            cursorborder: '',
            cursorborderradius: 0,
            cursorfixedheight: 180,
            autohidemode: false,
            horizrailenabled: false,
            nativeparentscrolling: false,
            scrollspeed: 65
        });

        $('html').niceScroll().scrollstart(function (info) {
            $('.nicescroll-rails div').addClass('scrolling');
        });

        $('html').niceScroll().scrollend(function (info) {
            $('.nicescroll-rails div').removeClass('scrolling');
        });
    }

   
});