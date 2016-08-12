'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    $('.remove-btn').off('click').on('click', function () {
      if (confirm('确定要删除该数据吗？')) {
        var $this = $(this);
        var api = Main.API.deleteCategory;
        var data = {
          id: $this.data('id')
        };

        var content = '<p></p><p class="text-center text-warning"><i class="glyphicon glyphicon-info-sign"></i>&nbsp;&nbsp;处理中，请稍后。请勿关闭窗口。</p>';
        Utils.showModal('#common-modal', content, function () {
          var request = Main.request(Main.API.clearCategoryCache);
          request.then(function (rst) {
            window.location.reload();
          });
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
    });


  });

});