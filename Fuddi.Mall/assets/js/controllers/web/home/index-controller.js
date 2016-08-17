'use strict';
require(['/assets/js/app.js'], function () {

  require(['config', 'ajax', 'swiper'], function (config, ajaxService, swiper) {

    var bannerSwiper = new swiper('#banner-container>.swiper-container', {
      autoplay: 5000,
      loop: true,
      autoplayDisableOnInteraction: false,
      pagination: '#banner-swiper-pagination',
      prevButton: '#banner-swiper-button-prev',
      nextButton: '#banner-swiper-button-next',
      paginationClickable: true
    });

    var latestSwiper = new swiper('#new-reveal-container>.swiper-container', {
      autoplay: 0,
      loop: true,
      autoplayDisableOnInteraction: false,
      pagination: '#new-reveal-swiper-pagination',
      prevButton: '#new-reveal-swiper-button-prev',
      nextButton: '#new-reveal-swiper-button-next',
      paginationClickable: true
    });

    var recommendSwiper = new swiper('#recommend-2-container>.swiper-container', {
      autoplay: 0,
      loop: true,
      autoplayDisableOnInteraction: false,
      prevButton: '#recommend-2-swiper-button-prev',
      nextButton: '#recommend-2-swiper-button-next'
    });

    /*
     console.log(ajaxService);
     console.log(config);

     var rst = ajaxService.getApi(config.API.apis.demo.index);

     rst.done(function (data) {
     console.log(data);
     });

     console.log(rst);
     */

  });

});