// <reference path="el.js" />

// Connect client Date format support

//0 	MM/dd/yyyy 						08/22/2006
//1 	dddd, dd MMMM yyyy 				Tuesday, 22 August 2006
//2 	dddd, dd MMMM yyyy HH:mm		Tuesday, 22 August 2006 06:30
//3 	dddd, dd MMMM yyyy hh:mm tt		Tuesday, 22 August 2006 06:30 AM
//4 	dddd, dd MMMM yyyy H:mm			Tuesday, 22 August 2006 6:30
//5 	dddd, dd MMMM yyyy h:mm tt		Tuesday, 22 August 2006 6:30 AM
//6 	dddd, dd MMMM yyyy HH:mm:ss 	Tuesday, 22 August 2006 06:30:07
//7 	MM/dd/yyyy HH:mm 				08/22/2006 06:30
//8 	MM/dd/yyyy hh:mm tt 			08/22/2006 06:30 AM
//9 	MM/dd/yyyy H:mm 				08/22/2006 6:30
//10 	MM/dd/yyyy h:mm tt 				08/22/2006 6:30 AM
//10 	MM/dd/yyyy h:mm tt 				08/22/2006 6:30 AM
//10 	MM/dd/yyyy h:mm tt 				08/22/2006 6:30 AM
//11 	MM/dd/yyyy HH:mm:ss 			08/22/2006 06:30:07
//12 	MMMM dd 						August 22
//13 	MMMM dd 						August 22
//18 	yyyy'-'MM'-'dd'T'HH':'mm':'ss 	2006-08-22T06:30:07
//19 	HH:mm 							06:30
//20 	hh:mm tt 						06:30 AM
//21 	H:mm 							6:30
//22 	h:mm tt 						6:30 AM
//23 	HH:mm:ss 						06:30:07
//24 	yyyy'-'MM'-'dd HH':'mm':'ss'Z' 	2006-08-22 06:30:07Z
//25 	dddd, dd MMMM yyyy HH:mm:ss 	Tuesday, 22 August 2006 06:30:07
//26 	yyyy MMMM 						2006 August
//27 	yyyy MMMM 						2006 August

if (window.el == undefined) {
    console.log('el is undefined in date.js');
} else
    el.define("el.Date", null, {
        'days': '',
        'months': '',
        'daysMin': '',
        'monthsMin': '',
        '_days': null,
        '_months': null,
        '_daysMin': null,
        '_monthsMin': null,
        'template': '',

        'format': function( /*String, Date*/date, /*String*/template) {

            /// <summary>Contains initialization logic of class. Base realization maps parameters from constructor argument to the class's members</summary>
            /// <param name="date" type="String, Date">Date object to format. If string is entered, standard Date.parse is used to convert it to Date object</param>
            /// <param name="template" type="String">Date and time format template (optional). If no format entered the default one is used.</param>
            /// <returns type="String">Formatted date object</returns>
            template = template || this.template || 'MM/dd/yyyy';
            if (typeof (date) === 'string' || typeof (date) === 'number') {
                var dateObj = null;
                try {
                    return this._format(new Date(date), template);
                } catch (e) {
                    el.trace(e.message);
                }
            } else if (date instanceof Date) {
                try {
                    return this._format(date, template);
                } catch (e) {
                    el.trace(e.message);
                }
            } else {
                el.trace('Invalid date object');
            }
            return '';
        },

        '_format': function( /*Date*/dt, /*String*/template) {
            var y = dt.getFullYear();
            var m = dt.getMonth();
            var d = dt.getDay();
            var dm = dt.getDate();
            var h = dt.getHours();
            var min = dt.getMinutes();
            var s = dt.getSeconds();
            var istt = template.indexOf('tt') > -1;
            var tt = 'AM';
            if (istt) { // http://en.wikipedia.org/wiki/12-hour_clock
                if (h >= 12) {
                    h -= 12;
                    tt = 'PM';
                }
                if (h == 0) h = 12;
            }
            var ret = template.replace(/y{3,}/ig, y);
            ret = ret.replace(/y{1,2}/ig, this._stringify(y % 100));
            ret = ret.replace(/h{2,}/ig, this._stringify(h));
            ret = ret.replace(/h/i, h);
            ret = ret.replace(/m+/g, this._stringify(min));
            ret = ret.replace(/s+/g, this._stringify(s));
            var o = this;
            ret = ret.replace(/(M{1,4}|d{1,4}|t{1,2})/ig, function(mt) {
                if (mt.match(/M{4}/ig)) return o._take('months', m);
                if (mt.match(/M{3}/ig)) return o._take('monthsMin', m);
                if (mt.match(/M{2}/ig)) return o._stringify(m + 1);
                if (mt.match(/M/i)) return (m + 1);
                if (mt.match(/d{4}/ig)) return o._take('days', d);
                if (mt.match(/d{3}/ig)) return o._take('daysMin', d);
                if (mt.match(/d{2}/ig)) return o._stringify(dm);
                if (mt.match(/d/i)) return dm;
                if (mt.match(/t{1,2}/ig)) return tt;
                return mt;
            });
            return ret;
        },

        '_take': function(array, index) {
            var a = [];
            var name = '_' + array;
            var selector = this[name];
            if (selector) {
                a = selector;
            }
            selector = this[array];
            if (selector && selector.split) {
                this[name] = selector.split(',');
            }
            a = this[name];
            if (a && a.length > index && index > -1) {
                return a[index];
            }
            return '';
        },

        '_stringify': function( /*Numeric*/n) {
            var prefix = '';
            if (n < 10) {
                prefix = '0';
            }
            return prefix + n; // String is returned
        },

        'parseDate': function(val, checkTimeZone) {

            if (val.indexOf("/Date(") == 0) //  JSON format.
            {
                var sval = val.substr(6);
                var numVal = parseInt(sval);
                if (checkTimeZone) {

                    var indexTZ = sval.indexOf('+') + 1;
                    if (indexTZ > 0)
                        numVal += (parseInt(sval.substr(indexTZ, 2)) * 60 + parseInt(sval.substr(indexTZ + 2))) * 60 * 1000;
                    else {
                        indexTZ = sval.indexOf('-') + 1;
                        if (indexTZ > 0)
                            numVal -= (parseInt(sval.substr(indexTZ, 2)) * 60 + parseInt(sval.substr(indexTZ + 2))) * 60 * 1000;
                    }
                    numVal += new Date(numVal).getTimezoneOffset() * 60 * 1000;
                }
                return new Date(numVal);
            } else //  ISO format.
                return $.datepicker.parseDate("yy-mm-dd", val);
        },

        'init': function() {

            /// <summary>Contains initialization logic of class. Base realization maps parameters from constructor argument to the class's members</summary>
            var p = this._params;
            for (var i in p) {
                if (typeof (this[i]) !== 'undefined') {
                    this[i] = p[i];
                }
            }
        }
    });