'use strict';

var __Config = function () {
  var c = this;
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
  this.ver = __c.ver;
  this.cdn = __c.cdn;
  this.minify = __c.minify;
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
    bxSlider: _c.cdn + 'bxslider/4.2.5/jquery.bxslider' + _c.minify,
    flexSlider: _c.cdn + 'flexslider/2.6.1/jquery.flexslider' + _c.minify,
    slick: _c.cdn + 'slick-carousel/1.6.0/slick' + _c.minify,
    jcarousel: _c.cdn + 'jcarousel/0.3.4/jquery.jcarousel' + _c.minify,

    app: 'app',
    main: 'main',
    config: 'common/config',
    utils: 'common/utils',
    ajax: 'services/ajax-service',
    vertical_carousel_service: 'services/vertical-carousel-service',
    jcarousellite: 'services/jquery.jcarousellite',

    _: ''

  },
  shim: {
    bootstrap: {
      deps: ['jquery']
    },
    swiper: {
      deps: ['jquery']
    },
    bxSlider: {
      deps: ['jquery'],
      exports: '$.fn.bxSlider'
    },
    flexSlider: {
      deps: ['jquery'],
      exports: '$.fn.flexSlider'
    },
    slick: {
      deps: ['jquery'],
      exports: '$.fn.slick'
    },
    jcarousel: {
      deps: ['jquery'],
      exports: '$.jCarousel'
    },
    jcarousellite: {
      deps: ['jquery'],
      exports: '$.fn.jCarouselLite'
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
    vertical_carousel_service: {
      deps: ['jquery'],
      exports: '$.fn.carousel'
    },
    _: {}
  },
  debug: false
});

