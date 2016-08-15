'use strict';


define([], function () {
  var Main = {
    API: {
      category: {
        edit: '/_cms/api/editcategory',
        delete: '/_cms/api/deletecategory',
        clearCache: '/_cms/api/clearcategorycache'
      },
      categoryGroup: {
        edit: '/_cms/api/editcategorygroup',
        delete: '/_cms/api/deletecategorygroup'
      },
      valuetype: {
        edit: '/_cms/api/editvaluetype',
        delete: '/_cms/api/deletevaluetype'
      }
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