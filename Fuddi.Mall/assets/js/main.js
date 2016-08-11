'use strict';


define([], function () {
  var Main = {
    API: {
      editCategory: '/_cms/api/editcategory',
      editCategoryGroup: '/_cms/api/editcategorygroup',
      clearCategoryCache: '/_cms/api/clearcategorycache'
    },
    request: function (api, data) {
      var opt = {
        method: 'POST',
        url: api
      }
      if (data) {
        opt.data = data
      };
      var q = $.ajax(opt);
      return q;
    }
  };
  return Main;
});