'use strict';
require(['/assets/js/app.js'], function () {

  require(['config', 'utils', 'ajax'], function (Config, Utils, ajaxService) {

    var urlPath = window.location.pathname.toLowerCase();
    // console.log(urlPath)
    if (urlPath !== '/' && urlPath !== '/home/index') {
      var $cateList = $('#main-category-nav-container>#main-list');
      $cateList.hide();
      var $menuIcon = $('#main-category-nav-container>#cate-all>i>i');
      $menuIcon.show();
      // var duration = 200;
      // var bo = '=14px';
      // console.log($menuIcon);
      $('#main-category-nav-container').hover(function () {
        // Utils.animate($menuIcon, { top: '+' + bo }, duration);
        $cateList.slideDown(300);
      }, function () {
        // Utils.animate($menuIcon, { top: '-' + bo }, duration);
        $cateList.slideUp(300);
      });
    }


  });

});