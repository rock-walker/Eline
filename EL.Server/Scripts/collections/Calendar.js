var bbCalendar = Backbone.Collection.extend({
    model: TimeRange,
    url: function () {
        return elapp.urls.baseUrl + 'api/calendar/gettodayreservations/'
                                  + this.srvType + '/' + this.srvId;
    },
    srvType: 0,
    srvId: 0,

    setupUrl: function(type, id) {
        this.srvType = type;
        this.srvId = id;
    },

    initialize: function() {
        
    },

});

var srvTimeRanges = new bbCalendar;