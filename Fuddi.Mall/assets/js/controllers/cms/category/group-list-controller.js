'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('确定要删除该数据吗？')) {
        var $this = $(this);
        var api = Main.API.categoryGroup.delete;
        var data = {
          id: $this.data('id')
        };

        var content = Utils.opTipsContent;
        Utils.showModal('#common-modal', content, function () {
          $('#btn-refresh').click();
        });

        var request = Main.request(api, data);
        request.then(function (rst) {

          var content = Utils.buildQueryRstMsg(rst);

          Utils.setModalContent('#common-modal', content);
        });
      }
    });

    $('#btn-refresh').off('click').on('click', function () {
      var request = Main.request(Main.API.category.clearCache);
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
      var api = Main.API.categoryGroup.edit;
      var v = $this.siblings('input');
      var type = $this.data('type');
      var data = {
        id: v.data('id'),
        name: v.val()
      };
      var cancelElm = typeof type === 'undefined' ? '.edit-cancel' : '.edit-cancel-dr';

      var request = Main.request(api, data);
      request.then(function (rst) {

        var content = Utils.buildQueryRstMsg(rst);

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