var TimeRange = Backbone.Model.extend({
    defaults: function () {
        return {
            StartH: 0,
            StartM: 0,
            EndH: 0,
            EndM: 0,
            Status: 0
        };
    },

    initialize: function() {
        
    }
})