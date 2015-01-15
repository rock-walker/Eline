var CalendarView = new Backbone.View.extend({
    /*template: elapp.renderTmpl('baseTemplates', "#dlg-calendar", {}),*/

    render: function (event) {
        console.log('[CalendarView]: render template');
        Calendar.init();
    }
})