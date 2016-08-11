'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils'], function (config, utils) {

    var categoryOpenStatusCls = {
      close: 'glyphicon-plus',
      open: 'glyphicon-minus'
    };

    $('.category-switcher').off('click').on('click', function () {
      var $this = $(this);
      var $icon = $(this).find('i');
      var addCls = categoryOpenStatusCls.open, removeCls = categoryOpenStatusCls.close;
      if ($icon.hasClass(addCls)) {
        var b = addCls;
        addCls = removeCls;
        removeCls = b;
      }
      $this.parent().nextAll('.category-container').slideToggle();
      $icon.removeClass(removeCls).addClass(addCls);
    });

    $('.edit').off('click').on('click', function () {
      var $this = $(this);
      $this.hide();
      $this.nextAll('.edit-container').css('display', 'inline-block');
    });

    $('.edit-cancel').off('click').on('click', function () {
      $(this).parent().hide();
      $(this).parent().parent().find('.edit').show();
    });

    $('#tree-container').fadeIn();

  });

});