var bbCalendar = new Backbone.Collection.extend({
    model: TimeRange,
    url: elapp.urls.baseUrl + 'api/reservations',

    initialize: function() {

    }
});

var timeRanges = new bbCalendar;