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
    return this.substr(0, index) + _str + this.substr(len + repeatTimes, this.length);
  };

  var Utils = {
    this: this,

    getTimestamp: function () {
      return (new Date()).getTime();
    },
    vTag: '[v]',
    getSiteProtocol: function () {
      return window.location.protocol;
    },
    getTs: function (ts, ver) {
      var _ts = '';
      if (typeof ts === 'undefined' || ts === true)
        _ts = this.getTimestamp();
      if (ts === false)
        _ts = ver;

      return ('?' + this.vTag + '=' + _ts);
    },
    Svg: function (width, height) {
      var that = this;
      this.createSVG = ~function () {
        var s = document.createElement('svg');
        s.setAttribute("xmlns", "http://www.w3.org/2000/svg");
        s.setAttribute("width", width);
        s.setAttribute("height", height);
        s.setAttribute("viewBox", "0 0 " + width + " " + height);
        that.s = s;
      }();

      this.appendItem = function (item) {
        that.s.appendChild(item);
        return that;
      };
      this.appendCircleArc = function (circle, angel, attrs) {
        circle = circle || { cx: 100, cy: 100, r: 100 },
          angel = angel || { start: 0, end: 90 };
        attrs = attrs || { fill: "none" };
        var largeArcFlag = Number(angel > 180);
        var circleArc = that.arc({
          largeArcFlag: largeArcFlag,
          rx: circle.r,
          ry: circle.r,
          startX: circle.cx - circle.r * Math.sin(angel.start / 180 * Math.PI),
          startY: circle.cy - circle.r * Math.cos(angel.start / 180 * Math.PI),
          endX: circle.cx - circle.r * Math.sin(angel.end / 180 * Math.PI),
          endY: circle.cy - circle.r * Math.cos(angel.end / 180 * Math.PI)
        }, attrs);
        that.s.appendChild(circleArc);
        return that;
      };
      this.render = function () {
        return that.s;
      };
      this.renderTo = function (DOM) {
        DOM = DOM || document.body;
        DOM.innerHTML = that.s.outerHTML;
        return that;
      };
      this.arc = function (config, attrs) {
        var def = {
          rx: 50,
          ry: 50,
          xAxisRotation: 0,
          largeArcFlag: 1,
          sweepFlag: 0,
          startX: 0,
          startY: 0,
          endX: 0,
          endY: 0
        }, config = config || {}, attrs = attrs || {};
        Object.keys(def).forEach(function (k) {
          config[k] = config[k] || def[k];
        });

        console.log(config);

        attrs.d = "";
        ~function calcPath() {
          var d = "M {{startX}},{{startY}} A {{rx}} {{ry}} {{xAxisRotation}} {{largeArcFlag}} {{sweepFlag}} {{endX}},{{endY}}";
          attrs.d = d.replace(/{{(.+?)}}/g, function (match, key) {
            return config[key];
          })
        }();

        var path = document.createElement('path');
        for (var i in attrs) {
          path.setAttribute(i.replace(/[A-Z]/g, function (o) {
            return '-' + o
          }), attrs[i]);
        }
        return path;
      }
    },
    formatNumber: function (value, decimal) {
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
    },
    validateIDCard: function (value) {
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

      if (birthday != (dateStr.getFullYear() + "-" + this.appendZero(dateStr.getMonth() + 1) + "-" + this.appendZero(dateStr.getDate()))) {
        return false;
      }

      return true;
    },
    appendZero: function (temp) {
      if (temp < 10) {
        return "0" + temp;
      } else {
        return temp;
      }
    }
  };
  return Utils;
});
