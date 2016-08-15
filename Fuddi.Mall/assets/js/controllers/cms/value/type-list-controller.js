'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    var _queryRst = Utils.queryRst;

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('删除该类型会同时删除与之相对应的商品关联信息，确定要删除该数据吗？')) {
        var $this = $(this);
        var api = Main.API.valuetype.delete;
        var data = {
          id: $this.data('id')
        };

        var content = Utils.opTipsContent;
        Utils.showModal(Utils.commonModalID, content, function () {
          $('#btn-refresh').click();
        });

        var request = Main.request(api, data);
        request.then(function (rst) {

          var content = Utils.buildQueryRstMsg(rst);

          Utils.setModalContent(Utils.commonModalID, content);
        });
      }
    });

    $('#btn-refresh').off('click').on('click', function () {
      window.location.reload();
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
      var api = Main.API.valuetype.edit;
      var id = Number($this.data('id'));
      var $container = id === 0 ? $this.closest('.condition-container') : $this.closest('tr');
      var $cancelBtn = $this.siblings('.edit-cancel');
      if (id > 0) {
        $container = $this.closest('tr');
        $cancelBtn = $container.find('.edit-cancel-dr');
      }
      var data = {
        id: id,
        name: $container.find('.name-ctrl').val(),
        value: $container.find('.value-ctrl').val()
      };

      var request = Main.request(api, data);
      request.then(function (rst) {

        var content = Utils.buildQueryRstMsg(rst);

        Utils.showModal(Utils.commonModalID, content);
        $cancelBtn.click();
        if (id > 0) {
          $container.find('.value-elm:eq(0)').html(data.name);
          $container.find('.value-elm:eq(1)').html(data.value);
        }
      });
    });

    $('.edit-dr').off('click').on('click', function () {
      $(this).hide();
      $(this).closest('tr').find('.edit-elm').show();
      $(this).closest('tr').find('.value-elm').hide();
    });

    $('.edit-cancel-dr').off('click').on('click', function () {
      $(this).closest('tr').find('.edit-elm').hide();
      $(this).closest('tr').find('.value-elm,.edit-dr').show();
    });

  });

});