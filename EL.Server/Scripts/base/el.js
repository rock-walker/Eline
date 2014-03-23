Array.prototype.remove = function (el) {
    var ret = [];
    for (var i = 0; i < this.length; i++)
        if (this[i] !== el)
            ret.push(this[i]);

    return ret;
};

Array.prototype.indexOf = function(predicate, startIndex) {
    for (var i = (startIndex || 0), n = this.length; i < n; i++) {
        if (typeof (predicate) == 'function') {
            if (predicate(this[i], i) == true) return i;
        } else if (this[i] == predicate) return i;
    }
    return -1;
};

Array.prototype.getString = function() {
    var result = '';
    for (var i = 0; i < this.length; i++) {
        result += String.fromCharCode(parseInt(this[i], 10));
    }
    return result;
};

Array.prototype.find = function(p) {
    for (var i = 0, n = this.length; i < n; i++) {
        var item = this[i];
        if (p(item)) return item;
    };
};

if (typeof(Array.prototype.First) == 'undefined') {
    Array.prototype.First = function(predicate, defValue) {
        if (predicate == null) {
            return this.length > 0 ? this[0] : defValue;
        }
        for (var i = 0; i < this.length; i++) {
            if (predicate(this[i], i) == true)
                return this[i];
        }
        return defValue;
    };
};

if (typeof(Array.prototype.Select) == 'undefined') {
    Array.prototype.Select = function(selector, startIndex) {
        var res = [];
        for (var i = (startIndex || 0); i < this.length; i++) {
            res.push(selector(this[i], i));
        }
        return res;
    };
}

if (Array.prototype.Where == undefined) {
    Array.prototype.Where = function(predicate, startIndex) {
        var res = [];
        for (var i = (startIndex || 0); i < this.length; i++) {
            if (predicate(this[i], i) == true)
                res.push(this[i]);
        }
        return res;
    };
}
if (Array.prototype.Count == undefined) {
    Array.prototype.Count = function(predicate, startIndex) {
        var res = 0;
        for (var i = (startIndex || 0); i < this.length; i++) {
            if (predicate(this[i], i) == true)
                res++;
        }
        return res;
    };
}
if (Array.prototype.IndexOf == undefined) {
    Array.prototype.IndexOf = function(predicate, startIndex) {

        for (var i = (startIndex || 0); i < this.length; i++) {
            if (typeof predicate == 'function') {
                if (predicate(this[i], i) == true)
                    return i;
            } else {
                if (this[i] == predicate)
                    return i;
            }
        }
        return -1;
    };
}
if (Array.prototype.Union == undefined) {
    Array.prototype.Union = function(second) {
        var res = this.slice(0);
        for (var i = 0, l = second.length; i < l; i++) {
            if (res.IndexOf(second[i]) == -1)
                res.push(second[i]);
        }
        return res;
    };
}
if (Array.prototype.InsertAt == undefined) {
    Array.prototype.InsertAt = function(second, index) {
        return [].concat(this.splice(0, (index || 0)), second, this);
    };
}

if (Array.prototype.Distinct == undefined) {
    Array.prototype.Distinct = function(second, predicate) {

        var res = [];

        var s1 = this.slice(0);
        var s2 = second.slice(0);

        for (var i = s1.length - 1; i >= 0; i--) {

            var v = s1[i];
            var found = false;

            for (var j = s2.length - 1; j >= 0; j--) {
                if (typeof predicate == 'function') {
                    if (predicate(v, s2[j]) == true) {
                        found = true;
                        s2.splice(j, 1);
                        break;
                    }
                } else {
                    if (v == s2[j]) {
                        found = true;
                        s2.splice(j, 1);
                        break;
                    }
                }
            }
            if (found)
                s1.splice(i, 1);
        }
        return res.concat(s1, s2);
    };
}
if (Array.prototype.DeleteIf == undefined) {
    Array.prototype.DeleteIf = function(predicate, startIndex) {
        for (var i = this.length - 1; i >= (startIndex || 0); i--) {
            if (predicate(this[i], i) == true)
                this.splice(i, 1);
        }
    };
}
if (Array.prototype.ForEach == undefined) {
    Array.prototype.ForEach = function(selector, startIndex) {
        for (var i = (startIndex || 0); i < this.length; i++) {
            selector(this[i], i);
        }
    };
}

String.prototype.replaceAll = function(search, replace) {
    return this.split(search).join(replace);
};

String.prototype.width = function(font) {
    var f = font || '16px helvetica',
        o = $('<div>' + this + '</div>')
            .css({ 'position': 'absolute', 'float': 'left', 'white-space': 'nowrap', 'visibility': 'hidden', 'font': f })
            .appendTo($('body')),
        w = o.width();

    o.remove();

    return w;
};

String.prototype.format = function(args) {
    var formatted = this;
    for (var i = 0; i < args.length; i++) {
        formatted = formatted.replace('{' + i + '}', args[i]);
    }
    return formatted;
};

if (typeof(String.prototype.netFormat) == 'undefined') {
    String.prototype.netFormat = function() {
        var args = arguments;
        return this.replace(/\{(\d+)\}/g, function(m, n) {
            return args[(n | 0)];
        });
    };
}

if (String.prototype.EqualsNoCase == undefined) {
    String.prototype.EqualsNoCase = function(s) {
        return this.toUpperCase() === s.toUpperCase();
    };
}
if (String.prototype.StartsWith == undefined) {
    String.prototype.StartsWith = function(s, ignoreCase) {

        var s1 = this;
        var s2 = s;

        if (ignoreCase == true) {
            s1 = s1.toUpperCase();
            s2 = s2.toUpperCase();
        }

        if (s2.length > s1.length)
            return false;

        for (var i = 0, l = s2.length; i < l; i++) {
            if (s1.charAt(i) != s2.charAt(i))
                return false;
        }
        return true;
    };
}
if (String.prototype.EndsWith == undefined) {
    String.prototype.EndsWith = function(s, ignoreCase) {

        var s1 = this;
        var s2 = s;

        if (ignoreCase == true) {
            s1 = s1.toUpperCase();
            s2 = s2.toUpperCase();
        }

        if (s2.length > s1.length)
            return false;

        for (var i = s2.length - 1; i >= 0; i--) {
            if (s1.charAt(i) != s2.charAt(i))
                return false;
        }
        return true;
    };
}
if (String.prototype.TrimLeft == undefined) {
    String.prototype.TrimLeft = function(predicate) {

        for (var i = 0, l = this.length; i < l; i++) {
            if (typeof predicate == 'function') {
                if (predicate(this.charAt(i)) == false)
                    return this.substr(i);
            } else {
                if (this.charAt(i) != predicate)
                    return this.substr(i);
            }
        }
        return "";
    };
}

if (String.prototype.TrimRight == undefined) {
    String.prototype.TrimRight = function(predicate) {

        for (var i = this.length - 1; i >= 0; i--) {
            if (typeof predicate == 'function') {
                if (predicate(this.charAt(i)) == false)
                    return this.substr(0, i + 1);
            } else {
                if (this.charAt(i) != predicate)
                    return this.substr(0, i + 1);
            }
        }
        return "";
    };
}
if (String.prototype.RemoveDuplicates == undefined) {
    String.prototype.RemoveDuplicates = function(predicate) {

        var s = this.substr(0);

        for (var i = s.length - 1; i > 0; i--) {
            if (typeof predicate == 'function') {
                if (predicate(s.charAt(i - 1), i - 1, s.charAt(i), i) == true)
                    s = s.substr(0, i) + s.substr(i + 1);
            } else {
                if (s.charAt(i) == predicate && s.charAt(i - 1) == predicate)
                    s = s.substr(0, i) + s.substr(i + 1);
            }
        }

        return s;
    };
}

(function ($, undefined) {

    window.el = $.extend(window.el, {
        '_typeRegistrations': {},
        '_typeRegistrationsParams': {},
        '_singletons': {},
        '_logs': [],
        '_logsMaxCount': 500,

        'declare': function( /*String*/name, /*Object*/obj) {

            /// <summary>Declares namespace for object. If specified namespace doesn't exist it is created</summary>
            /// <param name="name" type="String">Class name like el.ResearchMap.Node</param>
            /// <param name="obj" type="Object">Object ro registed in namespace, can be null for empty hash registration</param>
            /// <returns type="Object">Created object in namespace</returns>
            var tokens = name.split(".");
            var target = window;
            for (var i = 0; i < tokens.length - 1; i++) {
                var ns = tokens[i];
                var targetCandidate = target[ns];
                if (!targetCandidate) {
                    targetCandidate = target[ns] = {};
                }
                target = targetCandidate;
            }
            if (target) {
                var name1 = tokens[tokens.length - 1];
                target[name1] = obj || {};
                return target[name1];
            }
            return null;
        },

        'define': function( /*String*/className, /*Object*/options, /*Object*/classDefinition, /*Object*/staticMembers) {

            /// <summary>Registers class and its members in the namespace provided</summary>
            /// <param name="className" type="String">New class name including namespace, like 'el.ResearchMap.ViewModelBase'</param>
            /// <param name="options" type="Object">Set of options for class declaration. Now only the value 'baseClass' is supported. Type {'baseClass' : el.YourBaseClassInstance} to specify base class or null otherwise.</param>
            /// <param name="classDefinition" type="Object">JSON used as instance members declaration.</param>
            /// <param name="staticMembers" type="Object">JSON used to specify static members declaration. Type {'static' : {add members here}} to define static members. Can be omitted.</param>
            var baseClass = options && options.baseClass;
            var newClass = function(id, params, initAfterCreation) {
                this._id = id || '';
                this._params = params || {};
                this._className = className || '';
                if (!!initAfterCreation && typeof (this.init) === 'function') {
                    this.init();
                }
            };
            try {
                if (baseClass && baseClass.prototype) {
                    var f = function() {};
                    f.prototype = baseClass.prototype;
                    newClass.prototype = new f();
                    newClass.prototype.constructor = newClass;
                }
                $.extend(newClass.prototype, classDefinition);
                if (staticMembers && staticMembers.static) {
                    $.extend(newClass, staticMembers.static);
                }
            } catch (e) {
                el.trace('Error extending class ' + className);
            }
            newClass.superclass = baseClass && baseClass.prototype;
            el.declare(className, newClass);
        },

        'register': function( /*String*/alias, /*Function*/type, /*String*/lifetimeManager, /*Object*/params) {
            if (typeof (type) == 'function') {
                el._typeRegistrations[alias] = type;
                el._typeRegistrationsParams[alias] = params;
                if (lifetimeManager === 'singleton') {
                    el._singletons[alias] = null;
                }
                //el.trace('"' + alias + '" successfully registered in container');
            } else {
                el.trace('Wrong type provided for alias "' + alias + '"');
            }
        },

        'unregister': function( /*String*/alias) {
            if (el._typeRegistrations[alias]) {
                delete el._typeRegistrations[alias];
            }
            if (el._typeRegistrationsParams[alias]) {
                delete el._typeRegistrationsParams[alias];
            }
            if (el._singletons[alias]) {
                delete el._singletons[alias];
            }
        },

        'isRegistered': function( /*String*/alias) {
            return !!el._typeRegistrations[alias];
        },

        'resolve': function( /*String*/alias, /*String*/id, /*Object*/parameters) {
            var singleton = el._singletons[alias];
            if (singleton) {
                //el.trace('"' + alias + '" singleton found in container');
                return singleton;
            }
            var constructor = el._typeRegistrations[alias];
            if (!constructor) return null;
            var obj = null;
            try {
                obj = new constructor(id, $.extend(null, el._typeRegistrationsParams[alias] || {}, parameters || {}));
                if (obj != null) {
                    //el.trace('"' + alias + '" successfully resolved from container');
                    obj.alias = alias;
                }
            } catch (e) {
                el.trace(e.message);
            }
            if (obj && typeof (obj.init) == 'function') {
                obj.init();
            }
            if (singleton === null) {
                el._singletons[alias] = obj;
            }
            return obj;
        },

        'getRegistrationParams': function( /*String*/alias) {
            return el._typeRegistrationsParams[alias];
        },

        'parseJSON': function( /*String*/json, /*Hash*/exclude) {

            /// <summary>Converts json to object and inserts live instances if an object has _className defined</summary>
            /// <param name="json" type="String">Json string</param>
            var o = $.parseJSON(json);
            if (o && typeof (o) === 'object') {
                var predicate = function(x) {
                    for (var i in x) {
                        var p = x[i];
                        if (p && typeof (p) === 'object') {
                            if (p._className && !exclude[p._className]) {
                                var names = p._className.split('.');
                                var className = window;
                                for (var j = 0, n = names.length; j < n; j++) {
                                    if (!className) break;
                                    className = className[names[j]];
                                }
                                if (className && !(p instanceof className)) {

                                    // Make live objects after deserialization from JSON
                                    delete p._className; // Avoid recursion
                                    x[i] = new className(p._id || null, p, true);
                                }
                            }
                            predicate(x[i]);
                        }
                    }
                };
                predicate(o);
            }
            return o;
        },

        'trace': function( /*String*/message) {
            if (window.console && typeof (console.log) == 'function') { // Firebug, Chrome
                console.log(message);
            } else {
                //IE
                try {
                    console.log(message);
                } catch (e) {
                }
            }
            if (el._logsMaxCount <= el._logs.length) {
                el._logs.splice(0, 1);
            }
            el._logs.push(message);
        },

        'showTrace': function() {
            var s = el.ViewModelBase.viewPort();
            var obj = document.createElement('div');
            $(obj).html(el._logs.join('<br/>'));
            el.Dialog.show(obj, {
                'width': s.w * 0.9,
                'title': 'Trace log',
                'height': s.h * 0.9,
                'dialogClass': 'imcon-dlg no-radius2',
                'modal': false
            });
        },

        'getInjectedData': function(dom) {
            /// <summary>Retrieves JS data object injected in comment node inside specific DOM node</summary>
            /// <param name="dom" type="Object">DOM object which presumably contains injected data</param>
            var q = $(dom).find("script[type='text/js-data']");
            var dataNode = q.text() || q.html();
            if (dataNode)
                return $.parseJSON(dataNode);
            else {
                dataNode = $(dom).find("[role='data-object']").contents().filter(function() {
                    return this.nodeType == 8; /*comment nodes*/
                }).first();
                if (dataNode.length > 0)
                    return $.parseJSON(dataNode[0].nodeValue);
                else
                    return {};
            }
        },

        'jsonp': function(url, data, success, error, exOptions) {
            var options = {
                url: url,
                dataType: 'json',
                data: JSON.stringify(data),
                type: 'POST',
                success: success,
                error: error,
                contentType: 'application/json'
            };
            if (exOptions)
                $.extend(options, exOptions);
            return $.ajax(options);
        },
        'jsong': function(url, data, success, error, contentType, dataType, cache) {
            if (!contentType) {
                contentType = 'application/json';
            }
            if (!dataType) {
                dataType = 'json';
            }
            if (!(cache === true || cache === false)) {
                cache = true;
            }
            return $.ajax({
                cache: cache,
                url: url,
                dataType: dataType,
                data: data,
                type: 'GET',
                success: success,
                error: error,
                contentType: contentType
            });
        },

        _htmlEncodeDecodeDIV: null,
        htmlEncodeDecodeDIV: function() {
            if (el._htmlEncodeDecodeDIV == null)
                el._htmlEncodeDecodeDIV = $("<div/>");
            return el._htmlEncodeDecodeDIV;
        },

        'htmlEncode': function(value) {
            if (value != null)
                return el.htmlEncodeDecodeDIV().text(value).html();

            return "";
        },

        'htmlDecode': function(value) {
            if (value != null)
                return el.htmlEncodeDecodeDIV().html(value).text();

            return "";
        },

        'format': function(format) {
            var result = format;
            for (var i = 1; i < arguments.length; ++i) {
                result = result.replace("{" + (i - 1) + "}", arguments[i]);
            }
            return result;
        },

        'escapeRegExp': function(str) {
            return str.replace(el._regexEsc, "\\$&");
        },

        'copyObject': function(obj) {
            if (obj == undefined) return undefined;
            try {
                var oS = JSON.stringify(obj);
                return $.parseJSON(oS);
            } catch (e) {
                el.trace("el.copyObject(): Error: " + e);
            }
            throw "el.copyObject() failed!";
        },

        'doFormPost': function(url, target) {
            if (!document.forms["uniFormPost"]) // form does not exist
            {
                alert("Form 'uniFormPost' is not defined on page");
                return;
            }
            //clear form
            while (document.forms["uniFormPost"].childNodes.length > 0)
                document.forms["uniFormPost"].removeChild(document.forms["uniFormPost"].childNodes[0]);
            document.forms["uniFormPost"].action = url;
            document.forms["uniFormPost"].target = target;
            if (arguments.length > 2) {
                for (var n = 2; n < arguments.length;) {
                    if ((arguments.length - n) >= 2) {

                        var inp = $("<input>")[0];
                        inp.type = "hidden";
                        inp.name = arguments[n++];
                        var val = arguments[n++];
                        if (val || val === 0) {
                            inp.value = val;

                            document.forms["uniFormPost"].appendChild(inp);
                        }
                    } else
                        break;
                }
            }

            document.forms["uniFormPost"].submit();
        },

        'prop': function(getter, setter) {
            return function() {
                if (arguments.length > 0)
                    setter.apply(this, arguments);
                else
                    return getter.apply(this, arguments);
            };
        },

        'autoProp': function(field) {
            return function() {
                if (arguments.length > 0)
                    this[field] = arguments[0];
                else
                    return this[field];
            };
        },

        'chainCheck': function(base, child) {
            var childIds = child.split('.');
            for (var i = 0; i < childIds.length && base; base = base[childIds[i]], ++i);

            return base;
        },

        'extractSubObject': function(obj, memberList, copy) {
            var result = {};
            if (obj && memberList) {
                var members = memberList.split(',');
                for (var i = 0; i < members.length; ++i) {
                    var mn = members[i].replace(/^\s+/, "").replace(/\s+$/, "");
                    var val = obj[mn];
                    if (val != undefined) {
                        result[mn] = copy ? el.copyObject(val) : val;
                    } else {
                        // check if this is nested member path like xx.yy.zz
                        var path = mn.split('.');
                        if (path.length > 1) {
                            var baseSrc = obj;
                            var baseDest = result;
                            for (var j = 0; j < path.length; ++j) {
                                var pn = path[j];
                                val = baseSrc[pn];
                                if (val != undefined) {
                                    if (i == (path.length - 1)) {
                                        baseDest[pn] = copy ? el.copyObject(val) : val;
                                    } else {
                                        if (baseDest[pn] == undefined) // intermediate object not defined yet
                                        {
                                            baseDest[pn] = {};
                                        }
                                    }
                                } else
                                    break; // not exist in sourse object
                            }
                        }

                    }
                }
            }
            return result;
        },

        stopEvent: function(e) {

            if (e.preventDefault)
                e.preventDefault();

            if (e.stopImmediatePropagation)
                e.stopImmediatePropagation();

            if (e.stopPropagation)
                e.stopPropagation();

            e.cancelBubble = true;
            return false;
        },

        //for debug only
        'profile': function( /*String*/action, /*String*/name) {
            var started = "profileVar_start_" + name;
            var finished = "profileVar_end_" + name;
            switch (action) {
            case "start":
                window[started] = new Date();
                break;
            case "end":
                window[finished] = new Date();
                var diff = window[finished] - window[started];
                var result = "profiling " + name + "... Time: " + diff;
                el.trace(result);
            default:
                break;
            }

        }
    });
})(jQuery);

if (!window.JSON) { // IE7
	window.JSON = {
		stringify: function (data) {
			return el.ViewModelBase.toJSON(data, null, true);
		}
	};
}

el.define("el.ViewModelBase", null, {

	'_model': null,
	'name': '',
	'_membersToExcludeForJson': '',
	'_excludeNameForJson': true,
	'_selector': '',
	'_context': null,

	'init': function () {

		/// <summary>Contains initialization logic of class. Base realization maps parameters from constructor argument to the class's members</summary>
		var p = this._params;
		for (var i in p) {
			if (typeof (this[i]) !== 'undefined') {
				this[i] = p[i];
			}
		}
		//el.trace('Object "' + this._id + '" [' + this._className + '] initialized');
	},

	'clear': function () {

		/// <summary>Contains instance clearing logic</summary>
		//el.trace('Object "' + this._id + '" [' + this._className + '] cleared');
	},

	'toString': function () {

		/// <summary>Returns object's name by default.</summary>
		return this.name;
	},

	'toJSON': function () {

		/// <summary>Serializes current object to JSON using following convention: private fields [which start from '_'] and methods are ignored. Name property is ignored because _excludeNameForJson is true by default. You can specify additional member names to exclude from JSON output in _membersToExcludeForJson field.</summary>
		/// <returns type="String">JSON</returns>
		return el.ViewModelBase.toJSON(this, (this._excludeNameForJson ? 'name,' : '') + (this._membersToExcludeForJson || '')) || '';
	},
	'showBusy': function (/*Boolean*/state) {

		/// <summary>Toggles busy state and UI indicator</summary>
		/// <param name="state" type="Boolean">True or false</param>
	},

	'getDom': function () {

		/// <summary>Returns DOM object or null. _id property is used to get a reference to DOM by default.</summary>
		if (this._selector && this._context) {
			return $(this._selector, this._context)[0];
		}
		if (this._id) {
			return document.getElementById(this._id);
		}
		return null;
	},

	'setModel': function (/*String, Object*/data) {

		/// <summary>Assigns a data model to the view model</summary>
		/// <param name="data" type="String, Object">Model in the form of JavaScript object or string value representing JSON or HTML</param>
		this._model = data;
	}
}, {
	'static': {

		'fromString': function (/*JSON String*/json) {
			try {
				return eval("(" + json + ")");
			}
			catch (e) {
				el.trace(e.message);
				return null;
			}
		},

		'viewPort': function () {
			return { 'w': window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth, 'h': window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight };
		},

		'toJSON': function (/*Object*/obj, /*String*/namesToExclude, /*Boolean*/private1) {

			/// <summary>Serializes object to JSON using following convention: private fields [which start from '_'] and methods are ignored.</summary>
			/// <param name="obj" type="Object">Object to serialize</param>
			/// <param name="namesToExclude" type="String">List of public member names to exclude from serializing to JSON</param>
			/// <returns type="String">JSON</returns>
			var json = [];
			namesToExclude = namesToExclude || '';
			if (typeof (obj) !== 'function' && typeof (obj) !== 'undefined') {
				if (obj === null) {
					json.push("null");
				}
				else if (typeof (obj) === 'object') {
					if (obj instanceof Array) {
						json.push('[');
						for (var i = 0, n = obj.length; i < n; i++) {
							var member = el.ViewModelBase.toJSON(obj[i], namesToExclude, private1);
							if (member) {
								if (isFirst === false) {
									json.push(',');
								}
								json.push(member);
								isFirst = false;
							}
						}
						json.push(']');
					}
					else {
						json.push('{');
						var isFirst = true;
						for (var i in obj) {
							if ((i.indexOf('_') != 0 || !!private1) && namesToExclude.indexOf(i) == -1) {
								var member1 = el.ViewModelBase.toJSON(obj[i], namesToExclude, private1);
								if (member1) {
									if (isFirst === false) {
										json.push(',');
									}
									json.push('"' + i + '"');
									json.push(':');
									json.push(member1);
									isFirst = false;
								}
							}
						}
						json.push('}');
					}
				}
				else {
					var v = 'undefined';
					switch (typeof (obj)) {
						case 'boolean':
						case 'number':
							v = obj;
							break;
						case 'string':
							v = '"' + el.ViewModelBase._escape(obj) + '"';
							break;
					}
					json.push(v);
				}
			}
			return json.join('');
		},

		'_escape': function (s) {
			return s.replace(/[\\"]/g, '\\$&')
					.replace(/[\f]/g, '\\f')
					.replace(/[\n]/g, '\\n')
					.replace(/[\r]/g, '\\r')
					.replace(/[\t]/g, '\\t');
		}
	}
});