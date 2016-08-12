'use strict';

require(['/assets/js/app.js'], function () {

  require(['bootstrap'], function () {

    var $windowHeight = $(window).height(),
      $documentHeight = $(document).height(),
      $bodyHeight = $('body').height(),
      $footerHeight = $('#footer').height(),
      $footerOffset = 40,
      $navHeight = ($('#top-nav').height());

    //console.log('$windowHeight:', $windowHeight, '$documentHeight:', $documentHeight, '$bodyHeight:', $bodyHeight, '$navHeight:', $navHeight);

    //$('#menu-container').height($documentHeight - $navHeight);
    $('#content-container').height($windowHeight - ($navHeight + $footerHeight + $footerOffset));

    var menuOpenStatusCls = {
      close: 'glyphicon-menu-down',
      open: 'glyphicon-menu-up'
    };
    $('.menu-switcher').off('click').on('click', function () {
      var $this = $(this);
      var $switchIcon = $(this).find('.switcher-icon');
      var addCls = menuOpenStatusCls.open, removeCls = menuOpenStatusCls.close;
      if ($switchIcon.hasClass(addCls)) {
        var b = addCls;
        addCls = removeCls;
        removeCls = b;
      }
      $this.toggleClass('open');
      $this.nextAll('ul').slideToggle();
      $switchIcon.removeClass(removeCls).addClass(addCls);
    })

  });

});