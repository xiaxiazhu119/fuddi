'use strict';
require(['/assets/js/app.js'], function () {

  require(['config', 'ajax'], function (config, ajaxService) {

    console.log(ajaxService);
    console.log(config);

    var rst = ajaxService.getApi(config.API.apis.demo.index);

    rst.done(function (data) {
      console.log(data);
    });

    console.log(rst);

  });

});