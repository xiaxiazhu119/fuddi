'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'main'], function (Config, Utils, Main) {

    var rspMsg = $('#rsp-msg').val();

    if (rspMsg !== '') {

      var _a = {
        Code: parseInt($('#rst-code').val()),
        Msg: rspMsg
      };

      var content = Utils.buildQueryRstMsg(_a);

      //var cls1 = 'text-success', cls2 = 'glyphicon-ok';
      //var rst = parseInt($('#rst-code').val());
      //if (rst < 0) {
      //  cls1 = 'text-danger';
      //  cls2 = 'glyphicon-remove';
      //}
      //var content = '<p></p><p class="text-center ' + cls1 + '"><i class="glyphicon ' + cls2 + '"></i>&nbsp;&nbsp;' + rspMsg + '</p>';

      Utils.showCommonModal(content);
    }

    var _gs = $('#gs').val();
    if (_gs !== '') {
      var gsa = _gs.indexOf(',') === -1 ? [_gs] : _gs.split(',');
      $.each(gsa, function (n, v) {
        $('#cb-' + v).prop('checked', true);
      });
    }

    $('#submit-btn').off('click').on('click', function () {

      var name = $.trim($('#name').val());
      if (name === '') {
        alert('请输入类别名称');
        return;
      }

      var gs = $('.g-cb:checked').map(function () {
        return $(this).val();
      }).get().join(',');

      //console.log(gs);

      $('#gs').val(gs);

      document.forms[0].submit();

    });


  });

});