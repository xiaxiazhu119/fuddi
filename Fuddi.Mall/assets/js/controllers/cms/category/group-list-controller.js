﻿'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('确定要删除该数据吗？')) {
        var $this = $(this);
        var api = Main.API.deleteCategoryGroup;
        var data = {
          id: $this.data('id')
        };

        var content = '<p></p><p class="text-center text-warning"><i class="glyphicon glyphicon-info-sign"></i>&nbsp;&nbsp;处理中，请稍后。请勿关闭窗口。</p>';
        Utils.showModal('#common-modal', content, function () {
          $('#btn-refresh').click();
        });

        var request = Main.request(api, data);
        request.then(function (rst) {
          var cls1 = 'text-success', cls2 = 'glyphicon-ok';
          if (rst.Code < 0) {
            cls1 = 'text-danger';
            cls2 = 'glyphicon-remove';
          }
          var c2 = '<p></p><p class="text-center ' + cls1 + '"><i class="glyphicon ' + cls2 + '"></i>&nbsp;&nbsp;' + rst.Msg + '</p>';
          Utils.setModalContent('#common-modal', c2);
        });
      }
    });

    $('#btn-refresh').off('click').on('click', function () {
      var request = Main.request(Main.API.clearCategoryCache);
      request.then(function (rst) {
        window.location.reload();
      });
    });

    $('.search-btn').off('click').on('click', function () {
      var v = $.trim($('#name').val());
      if (v !== '') {
        window.location = '/_cms/category/grouplist?name=' + encodeURIComponent(v);
      }
    });

    $('#quick-add-btn').off('click').on('click', function () {
      var $this = $(this);
      $this.hide();
      $this.siblings('.condition-container').removeClass('hidden').show();
    });

    $('.edit-cancel').off('click').on('click', function () {
      var $this = $(this);
      $this.parent().hide();
      $this.parent().siblings('#quick-add-btn').show();
    });

    $('.edit-confirm').off('click').on('click', function () {
      var $this = $(this);
      var api = Main.API.editCategoryGroup;
      var v = $this.siblings('input');
      var type = $this.data('type');
      var data = {
        id: v.data('id'),
        name: v.val()
      };
      var cancelElm = typeof type === 'undefined' ? '.edit-cancel' : '.edit-cancel-dr';

      var request = Main.request(api, data);
      request.then(function (rst) {
        var content = '<p></p><p class="text-center text-success"><i class="glyphicon glyphicon-ok"></i>&nbsp;&nbsp;' + rst.Msg + '</p>';
        Utils.showModal('#common-modal', content);
        $this.siblings(cancelElm).click();
        if (typeof type !== 'undefined') {
          $this.siblings('span').html(data.name);
        }
      });
    });

    $('.edit-dr').off('click').on('click', function () {
      $(this).hide();
      var editRow = $(this).parent().siblings('.edit-td');
      editRow.find('.edit-elm').show();
      editRow.find('.value-elm').hide();
    });

    $('.edit-cancel-dr').off('click').on('click', function () {
      var $this = $(this);
      var $td = $this.parent();
      $td.find('.edit-elm').hide();
      $td.find('.value-elm').show();
      $td.siblings('.op-td').find('.edit-dr').show();
    });

  });

});