'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    var categoryOpenStatusCls = {
      close: 'glyphicon-plus',
      open: 'glyphicon-minus'
    };

    $('.category-switcher').off('click').on('click', function () {
      var $this = $(this);
      if ($this.hasClass('no-category')) return;
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

    $('.edit-btn').off('click').on('click', function () {
      var $this = $(this);
      $this.hide();
      $this.nextAll('.edit-container').css('display', 'inline-block');
    });

    $('.edit-cancel').off('click').on('click', function () {
      $(this).parent().hide();
      $(this).parent().parent().find('.edit-btn').show();
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
      request.then(function (rst) {
        var content = '<p></p><p class="text-center text-success"><i class="glyphicon glyphicon-ok"></i>&nbsp;&nbsp;' + rst.Msg + '</p>';
        Utils.showModal('#common-modal', content);
        $this.siblings('.edit-cancel').click();
        if (data.id != 0) {
          $this.parent().siblings('.item-txt-container').html(data.name + '&nbsp;&nbsp;');
        }
      });
    });

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('确定要删除该数据吗？')) {
        var $this = $(this);
        var type = $this.data('type');
        var api = Main.API.deleteCategoryGroup;
        var $container = $this.closest('li.group-item');
        var data = {
          id: $this.data('id')
        };
        if (type === 'c') {
          api = Main.API.deleteCategory;
          $container = $this.closest('li.category-item');
        }

        var request = Main.request(api, data);
        request.then(function (rst) {
          var content = '<p></p><p class="text-center text-success"><i class="glyphicon glyphicon-ok"></i>&nbsp;&nbsp;' + rst.Msg + '</p>';
          Utils.showModal('#common-modal', content);
          $container.remove();
        });
      }
    });

    $('#btn-refresh').off('click').on('click', function () {
      var request = Main.request(Main.API.clearCategoryCache);
      request.then(function (rst) {
        //var content = '<p></p><p class="text-center text-success"><i class="glyphicon glyphicon-ok"></i>  ' + rst.Msg + '</p>';
        //Utils.showModal('#common-modal', content, function () {
        window.location.reload();
        //});
      });
    });

    $('#tree-container').fadeIn();

  });

});