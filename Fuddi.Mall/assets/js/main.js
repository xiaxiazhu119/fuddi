'use strict';


define([], function () {
  var Main = {
    API: {
      editCategory: '/_cms/api/editcategory',
      editCategoryGroup: '/_cms/api/editcategorygroup'
    },
    request: function (api, data) {
      var q = $.ajax({
        method: 'POST',
        url: api,
        data: data
      });
      return q;
    }
  };
  return Main;
});