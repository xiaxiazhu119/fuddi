'use strict';


define([], function () {
  var _apiBasePath = '/_cms/api/';
  var Main = {
    API: {
      category: {
        edit: _apiBasePath + 'editcategory',
        delete: _apiBasePath + 'deletecategory',
        clearCache: _apiBasePath + 'clearcategorycache'
      },
      categoryGroup: {
        edit: _apiBasePath + 'editcategorygroup',
        delete: _apiBasePath + 'deletecategorygroup'
      },
      valueType: {
        edit: _apiBasePath + 'editvaluetype',
        delete: _apiBasePath + 'deletevaluetype',
        deleteRelation: _apiBasePath + 'deletevalueproductrelation'
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