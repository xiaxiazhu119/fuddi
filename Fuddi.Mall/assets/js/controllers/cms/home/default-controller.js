'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils'], function (Config, Utils) {

    var signinRspMsg = $('#_signin-rsp-msg').val();
    console.log('signinRspMsg', signinRspMsg);
    console.log('utils', Utils);

    if (signinRspMsg !== '') {
      Utils.showCommonModal(signinRspMsg);
    }

  });

});