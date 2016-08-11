'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (config, utils, Main) {

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

    $('.edit-confirm').off('click').on('click', function () {
      var $this = $(this);
      var type = $this.data('type');
      var api = Main.API.editCategoryGroup;
      var v = $this.siblings('input');
      var data = {
        id: v.data('id'),
        name: v.val()
      };
      if (type === 'c') {
        api = Main.API.editCategory;
        data.gid = v.data('gid');
      }

      var request = Main.request(api, data);
    });

    $('#tree-container').fadeIn();

  });

});