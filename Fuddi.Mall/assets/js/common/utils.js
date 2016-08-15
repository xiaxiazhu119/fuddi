'use strict';

define([], function () {
  String.prototype.customReplace = function (index, len, str, repeat, repeatTimes) {
    var _defaultStr = '*';
    str = typeof str === 'undefined' ? _defaultStr : (typeof str === 'bool' ? _defaultStr : str);
    repeat = typeof repeat === 'undefined' ? true : (typeof str === 'bool' ? str : repeat);
    repeatTimes = typeof repeatTimes === 'undefined' ? (repeat ? len : 0) : repeatTimes;
    var _str = '';
    if (repeat)
      for (var i = 0; i < repeatTimes; i++)
        _str += str;
    return _self.substr(0, index) + _str + _self.substr(len + repeatTimes, _self.length);
  };
  var Utils = function () {
    var _self = this;

    var _vTag = '[v]';

    var _modelEvent = {
      show: 'show',
      hide: 'hide',
      onShow: 'show.bs.modal',
      onHide: 'hide.bs.modal'
    };

    var _getTimestamp = function () {
      return (new Date()).getTime();
    };

    var _getSiteProtocol = function () {
      return window.location.protocol;
    };

    var _getTs = function (ts, ver) {
      var _ts = '';
      if (typeof ts === 'undefined' || ts === true)
        _ts = _self.getTimestamp();
      if (ts === false)
        _ts = ver;

      return ('?' + _self.vTag + '=' + _ts);
    };

    var _formatNumber = function (value, decimal) {
      if (typeof decimal === 'undefined')
        decimal = 2;
      //console.log('value:', value);
      if (value === '' || isNaN(Number(value)) || value.indexOf('0') === 0) return '';

      if (value.indexOf('.') !== -1) {
        var arr = value.split('.');
        value = arr[0] + (decimal > 0 ? ('.' + arr[1].substr(0, decimal)) : '');
      }

      //var dotIndex = value.indexOf('.');
      //if (dotIndex !== -1 && value.substring(dotIndex).length > 2) {
      //  value  = value.substr(0, dotIndex + 3);
      //}

      return value;
    };

    var _validateIDCard = function (value) {
      //身份证的地区代码对照
      var aCity = {
        11: "北京",
        12: "天津",
        13: "河北",
        14: "山西",
        15: "内蒙古",
        21: "辽宁",
        22: "吉林",
        23: "黑龙江",
        31: "上海",
        32: "江苏",
        33: "浙江",
        34: "安徽",
        35: "福建",
        36: "江西",
        37: "山东",
        41: "河南",
        42: "湖北",
        43: "湖南",
        44: "广东",
        45: "广西",
        46: "海南",
        50: "重庆",
        51: "四川",
        52: "贵州",
        53: "云南",
        54: "西藏",
        61: "陕西",
        62: "甘肃",
        63: "青海",
        64: "宁夏",
        65: "新疆",
        71: "台湾",
        81: "香港",
        82: "澳门",
        91: "国外"
      };
      //获取证件号码
      var person_id = value;
      //合法性验证
      var sum = 0;
      //出生日期
      var birthday;
      //验证长度与格式规范性的正则
      var pattern = new RegExp(/(^\d{15}$)|(^\d{17}(\d|x|X)$)/i);
      if (!pattern.exec(person_id))
        return false;

      //验证身份证的合法性的正则
      pattern = new RegExp(/^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/);
      if (pattern.exec(person_id)) {
        //获取15位证件号中的出生日期并转位正常日期
        birthday = "19" + person_id.substring(6, 8) + "-" + person_id.substring(8, 10) + "-" + person_id.substring(10, 12);
      } else {
        person_id = person_id.replace(/x|X$/i, "a");
        //获取18位证件号中的出生日期
        birthday = person_id.substring(6, 10) + "-" + person_id.substring(10, 12) + "-" + person_id.substring(12, 14);

        //校验18位身份证号码的合法性
        for (var i = 17; i >= 0; i--) {
          sum += (Math.pow(2, i) % 11) * parseInt(person_id.charAt(17 - i), 11);
        }
        if (sum % 11 != 1) {
          return false;
        }
      }
      //检测证件地区的合法性
      if (aCity[parseInt(person_id.substring(0, 2))] == null) {
        return false;
      }
      var dateStr = new Date(birthday.replace(/-/g, "/"));

      if (birthday != (dateStr.getFullYear() + "-" + _self.appendZero(dateStr.getMonth() + 1) + "-" + _self.appendZero(dateStr.getDate()))) {
        return false;
      }

      return true;
    };

    var _appendZero = function (temp) {
      if (temp < 10) {
        return "0" + temp;
      } else {
        return temp;
      }
    };

    var _adjustParentIframeHeight = function (iframeTagId, offset) {
      offset = offset || 30;
      var theFrame = $(iframeTagId, parent.document.body);
      if (AdjustParentIframeHeight.arguments[1])
        theFrame.height(parseInt(AdjustParentIframeHeight.arguments[1]) + offset);
      else
        theFrame.height($(document.body).height() + offset);
    };

    var _getItemIndex = function (elm, item) {
      return $(elm).index(item);
    };

    var _setModalContent = function (modalID, content) {
      $(modalID).find('.modal-body').html(content);
    };

    var _showModal = function (modalID, onShow, onHide) {
      $(modalID).unbind()
      .on(_modelEvent.onShow, function (e) {
        var type = typeof onShow;
        if (type !== 'undefined') {
          switch (type) {
            case 'function':
              onShow();
              break;
            case 'string':
              _setModalContent(modalID, onShow);
              break;
          }
        }
      })
      .on(_modelEvent.onHide, function (e) {
        if (typeof onHide !== 'undefined')
          onHide();
      })
      .modal(_modelEvent.show);
    };

    var _hideModal = function (modalID, onHide) {
      $(modalID)
        .on(_modelEvent.onHide, function (e) {
          if (typeof onHide !== 'undefined')
            onHide();
        })
        .modal(_modelEvent.hide);
    };

    var _bindModalEvent = function (modalID, event, func) {
      var e = '';
      switch (event) {
        case modelEvent.show:
          e = _modelEvent.onShow;
          break;
        case modelEvent.hide:
          e = _modelEvent.onHide;
          break;
      }
      if (e != '' && typeof func !== 'undefined') {
        $(modalID).off(e)
        .on(e, func());
      }
    };

    var _showCommonModal = function (content) {
      var modalID = '#common-modal';
      _setModalContent(modalID, content);
      _showModal(modalID);
    };

    var _opTipsContent = '<p></p><p class="text-center text-warning"><i class="glyphicon glyphicon-info-sign"></i>&nbsp;&nbsp;处理中，请稍后。请勿关闭窗口。</p>';

    var _queryRst = {
      icon: {
        success: 'glyphicon-ok',
        failed: 'glyphicon-remove'
      },
      style: {
        success: 'text-success',
        failed: 'text-danger'
      },
      tmpl: {
        icon: '{{icon}}',
        style: '{{style}}',
        msg: '{{msg}}',
        getTmpl: function () {
          return '<p></p><p class="text-center ' + this.style + '"><i class="glyphicon ' + this.icon + '"></i>&nbsp;&nbsp;' + this.msg + '</p>';
        }
      }
    };

    var _commonModalID = '#common-modal';

    this.vTag = _vTag;
    this.modelEvent = _modelEvent;
    this.opTipsContent = _opTipsContent;
    this.queryRst = _queryRst;
    this.commonModalID = _commonModalID;

    this.getTimestamp = function () {
      return _getTimestamp();
    };
    this.getSiteProtocol = function () {
      return _getSiteProtocol();
    };
    this.getTs = function (ts, ver) {
      return _getTs(ts, ver);
    };
    this.formatNumber = function (value, decimal) {
      return _formatNumber(value, decimal);
    };
    this.validateIDCard = function (value) {
      return _validateIDCard(value);
    };
    this.appendZero = function (temp) {
      return _appendZero(temp);
    };
    this.adjustParentIframeHeight = function (iframeTagId, offset) {
      return _adjustParentIframeHeight(iframeTagId, offset);
    };
    this.getItemIndex = function (elm, item) {
      return _getItemIndex(elm, item);
    };
    this.setModalContent = function (modalID, content) {
      return _setModalContent(modalID, content);
    };
    this.showModal = function (modalID, onShow, onHide) {
      return _showModal(modalID, onShow, onHide);
    };
    this.hideModal = function (modalID, onHide) {
      return _hideModal(modalID, onHide);
    };
    this.bindModalEvent = function (modalID, event, func) {
      return _bindModalEvent(modalID, event, func);
    };
    this.showCommonModal = function (content) {
      return _showCommonModal(content);
    };

    this.buildQueryRstMsg = function (rst) {
      var style = this.queryRst.style,
        icon = this.queryRst.icon,
        tmpl = this.queryRst.tmpl;

      var cls1 = style.success, cls2 = icon.success;
      if (rst.Code < 0) {
        cls1 = style.failed;
        cls2 = icon.failed;
      }
      var _t = tmpl.getTmpl();
      var content = _t.replace(tmpl.style, cls1).replace(tmpl.icon, cls2).replace(tmpl.msg, rst.Msg);
      return content;
    };

    this.showCommonQueryRstModal = function (rst, callback) {
      var content = this.buildQueryRstMsg(rst);
      this.showModal(this.commonModalID, content);
      if (typeof callback === 'function')
        callback();
    };

  };

  return new Utils();
});
