'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    $('.search-btn').off('click').on('click', function () {
      var v = $('#v-t-list').val();
      if (v != '0') {
        window.location = '/_cms/_value/relationlist?vid=' + v;
      }
    });

    var _queryRst = Utils.queryRst;

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('确定要删除该数据吗？')) {
        var $this = $(this);
        var api = Main.API.valueType.deleteRelation;
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

  });

});