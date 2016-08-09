﻿'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils'], function (config, utils) {

    var signinRspMsg = $('#_signin-rsp-msg').val();
    console.log('signinRspMsg', signinRspMsg);
    console.log('utils', utils);

    if (signinRspMsg !== '') {
      utils.showCommonModal(signinRspMsg);
    }

  });

});