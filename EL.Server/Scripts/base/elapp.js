(function ($, undefined) {
    window.elapp = $.extend(window.elapp, {
        'underscoreTmpls': {},

        'renderTmpl': function(tmplName, tmplId, tmplData) {

            if (!this.underscoreTmpls.tmpl_cache) {
                this.underscoreTmpls.tmpl_cache = {};
            }

            if (!this.underscoreTmpls.tmpl_cache[tmplId]) {
                var tmplDir = '/Scripts/views';
                var tmplUrl = tmplDir + '/' + tmplName + '.htm';

                var tmplString;

                if (!this.underscoreTmpls.file) {
                    this.underscoreTmpls.file = {};
                }

                if (!this.underscoreTmpls.file[tmplUrl]) {

                    $.ajax({
                        url: tmplUrl,
                        method: 'GET',
                        async: false,
                        success: function(data) {
                            tmplString = data;
                        }
                    });

                    this.underscoreTmpls.file[tmplUrl] = tmplString;
                } else
                    tmplString = this.underscoreTmpls.file[tmplUrl];

                var tmpl = $(tmplString).siblings(tmplId).html();
                this.underscoreTmpls.tmpl_cache[tmplId] = _.template(tmpl);
            }

            return (tmplData != undefined) ? this.underscoreTmpls.tmpl_cache[tmplId](tmplData)
                : this.underscoreTmpls.tmpl_cache[tmplId];
        }
    });
})(jQuery)