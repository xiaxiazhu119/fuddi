'use strict';

define([], function () {
  var Config = {
    secretKey: '__fuddiabcdefg12345678',
    pagination: {
      text: {
        /*
         previous:'&lsaquo;',
         next:'&rsaquo;',
         first:'&laquo;',
         last:'&raquo;'
         */
        previous: '‹',
        next: '›',
        first: '«',
        last: '»'
      },
      default: {
        pageIndex: 1,
        pageSize: 10,
        maxSize: 5,
        totalItem: 999999   //to fix angularjs ui-bootstrap pagination problem: can't customer
      }
    },
    API: {
      domain: '//localhost:22380/api/',
      apis: {
        demo: {
          index: 'demo/index'
        },
        _: ''
      },
      queryMethod: {
        POST: 'POST',
        GET: 'GET'
      }
    },
    modalCategory: {
      loading: {
        name: 'loading',
        templateUrl: '/assets/partials/modal/loading.html'
      },
      dialog: {
        name: 'dialog',
        templateUrl: '/assets/partials/modal/dialog.html'
      }
    },
    defaultSEOData: {
      title: '',
      keywords: '',
      description: ''
    },
    siteInfo: {
      domain: 'fuddi.jp',

      _ver: '0.17.3',
      _release: false
    },
    siteMap: {
    },
    cookies: {
      keys: {
      }
    },
    rstEnum: {
      requestErr: {
        code: '0x90000101re',
        msg: '请求错误'
      },
      requestTimeout: {
        code: '0x90000102ne',
        msg: '请求超时'
      },
      netErr: {
        code: '0x90000103ne',
        msg: '网络错误'
      },
      sysErr: {
        code: '0x90000201se',
        msg: '系统错误'
      }
    },
    timeout: {
      common: 1000,
      common_2: 1000,
      loadingBar: 0,
      data: 500,
      callback: 500,
      fade: 0,
      imgVcode: 1000,
      countdown: 60,
      queryRst: 3000
    },
    CDN: {
    },
    regex: {
      number: {
        only: /^\d+$/,
        twoDecimal: /^[0-9]+(\.[0-9]{1,2})?$/
      }
    },
    __: {}

  };
  return Config;
});
