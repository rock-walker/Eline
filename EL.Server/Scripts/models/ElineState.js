var ElineState = Backbone.Model.extend({
    defaults: function() {
        return {
            'currentCategory': 0
        };
    },

    initialize: function() {
        this.on('change:currentCategory', this._getServiceMarkers);
    },

    _getServiceMarkers: function () {
        var serviceMap = App.getServiceMap();

        if (serviceMap && serviceMap.getGmap().markers.length > 0)
            serviceMap.getGmap().removeMarkers();
            //App.getServiceMap().getGmap().clearMarkers();//$el.gmap('clearMarkers');

        serviceMarkers.fetch(
            {
                success: this._apiMarkersSuccess,
                onerror: this._apiMarkersError
            }
        );
    },

    _apiMarkersSuccess: function(xhr) {
        console.log('[GMap]: GET Api markers status: SUCCESS');
    },
    _apiMarkersError: function(xhr) {
        console.log('[GMap]: GET Api markers status: FAILED');
    },
});

var appState = new ElineState;
var serviceMarkers;