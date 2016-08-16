'use strict';

var __Config = function () {
  var c   = this;
  var __c = {
    release: false,
    ver: '0.0.1',
    cdn: '//cdn.bootcss.com/',
    minify: '.min',
    init: function () {
      if (!this.release) this.minify = '';
    }
  };
  __c.init();
  this.release = __c.release;
  this.ver     = __c.ver;
  this.cdn     = __c.cdn;
  this.minify  = __c.minify;
};

var _c = new __Config();
//console.log(_c);

require.config({
  baseUrl: '/assets/js/',
  waitSeconds: 15,
  urlArgs: '[v]=' + (new Date()).getTime(),
  //urlArgs: '[v]=' + _c.ver,
  paths: {

    jquery: _c.cdn + 'jquery/3.1.0/jquery' + _c.minify,
    jquery_cookie: _c.cdn + 'jquery-cookie/1.4.1/jquery.cookie' + _c.minify,
    bootstrap: _c.cdn + 'bootstrap/3.3.7/js/bootstrap' + _c.minify,
    swiper: _c.cdn + 'Swiper/3.3.1/js/swiper.jquery' + _c.minify,

    app: 'app',
    main: 'main',
    config: 'common/config',
    utils: 'common/utils',
    ajax: 'services/ajax-service',

    _: ''

  },
  shim: {
    bootstrap: {
      deps: ['jquery']
    },
    swiper: {
      deps: ['jquery']
    },
    ajax: {
      deps: ['config', 'utils', 'jquery'],
      exports: 'ajax'
    },
    utils: {
      deps: ['bootstrap'],
      exports: 'utils'
    },
    main: {
      deps: ['jquery'],
      exports: 'main'
    },
    _: {}
  },
  debug: false
});

