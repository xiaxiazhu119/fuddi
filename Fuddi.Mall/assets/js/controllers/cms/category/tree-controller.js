'use strict';

require(['/assets/js/app.js'], function () {

  require(['config', 'utils'], function (config, utils) {

    var offsetHorizontalValue = 100,
      offsetVerticalValue = 40;

    $('.category-tree-item').each(function (k, v) {
      var $this = $(this);

      var offsetHorizontal = $this.data('offset-horizontal'),
        offsetVertical = $this.data('offset-vertical');

      $this.css({ 'left': offsetHorizontal * offsetHorizontalValue + 'px', 'top': offsetVerticalValue * offsetVertical + 'px' });

    });

    $('#tree-container').fadeIn();

  });

});