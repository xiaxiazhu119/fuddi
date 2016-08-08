'use strict';

require(['/assets/js/app.js'], function () {

  require(['bootstrap'], function () {

    var $windowHeight = $(window).height(),
      $documentHeight = $(document).height(),
      $bodyHeight = $('body').height(),
      $footerHeight = $('#footer').height(),
      $footerOffset = 40,
      $navHeight = ($('#top-nav').height());

    console.log('$windowHeight:', $windowHeight, '$documentHeight:', $documentHeight, '$bodyHeight:', $bodyHeight, '$navHeight:', $navHeight);

    //$('#menu-container').height($documentHeight - $navHeight);
    $('#content-container').height($windowHeight - ($navHeight + $footerHeight + $footerOffset));

    var menuOpenStatusCls = {
      close: 'glyphicon-menu-down',
      open: 'glyphicon-menu-up'
    };
    $('.menu-switcher').off('click').on('click', function () {
      var $this = $(this);
      var addCls = menuOpenStatusCls.open, removeCls = menuOpenStatusCls.close;
      if ($this.hasClass(addCls)) {
        var b = addCls;
        addCls = removeCls;
        removeCls = b;
      }
      $this.parent().nextAll('ul').slideToggle();
      $this.removeClass(removeCls).addClass(addCls);
    })

  });

});