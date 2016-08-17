'use strict';
require(['/assets/js/app.js'], function () {

  require(['config', 'ajax', 'swiper', 'jcarousellite'], function (config, ajaxService, swiper) {

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

    $("#legend-slide").jCarouselLite({
      vertical: true
    });

    // $('#legend-slide').jcarousel({
    //   animation: 'fast',
    //   list: '.jcarousel',
    //   items: '.slide-item',
    //   vertical: true
    // });

    // $('#legend-slide').slick({
    //   infinite: true,
    //   speed: 300,
    //   vertical: true,
    //   autoplay: true,
    //   autoplaySpeed: 2000,
    //   slidesToScroll:1
    // });
    // $('#legend-slide').bxSlider({
    //   mode: 'vertical',
    //   auto: true,
    //   pause: 1000,
    //   slideWidth: 228,
    //   moveSlides: 1,
    //   maxSlides: 12,
    //   slideMargin: 0
    // });

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