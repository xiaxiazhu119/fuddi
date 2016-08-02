'use strict';

define(['config', 'utils'], function (config, utils) {
  
  var ajaxService = function () {

    var _defaults = {
      api: '',
      data: {},
      method: config.API.queryMethod.POST
    };

    var _getApi = function (opts) {

      var _protocol = utils.getSiteProtocol();

      return $.ajax({
        type: opts.method,
        url: config.API.domain + opts.api,
        data: opts.data
      });

    }

    this.getApi = function (api, data) {

      var opts = {
        api: api,
        data: data || {}
      };
      var o = $.extend(_defaults, opts);
      return _getApi(o);
    };
  };

  return new ajaxService();

});
