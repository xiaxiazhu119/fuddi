'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('确定要删除该数据吗？')) {
        var $this = $(this);
        var api = Main.API.category.delete;
        var data = {
          id: $this.data('id')
        };

        var content = Utils.opTipsContent;
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
      var request = Main.request(Main.API.category.clearCache);
      request.then(function (rst) {
        window.location.reload();
      });
    });

    $('.search-btn').off('click').on('click', function () {
      var v = $.trim($('#name').val());
      if (v !== '') {
        window.location = '/_cms/category/categorylist?name=' + encodeURIComponent(v);
      }
    });


  });

});