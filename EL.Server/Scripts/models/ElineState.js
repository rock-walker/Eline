var ElineState = Backbone.Model.extend({
    defaults: function() {
        return {
            'currentCategory': 0
        };
    },

    initialize: function() {
        this.on('change:currentCategory', this._reactOnCategory);
    },

    _reactOnCategory: function() {
        this._getServiceMarkers();
        this._getMovables();
    },

    _getServiceMarkers: function() {
        var serviceMap = App.getServiceMap();

        if (serviceMap && serviceMap.getGmap().markers.length > 0)
            serviceMap.getGmap().removeMarkers();

        serviceMarkers.fetch(
            {
                success: this._apiMarkersSuccess,
                onerror: this._apiMarkersError
            }
        );
    },

    _getMovables: function() {
        var movableServices = App.getMovableServices();
        if (!movableServices)
            return;

        movableServices.resetAll();
        movables.fetch(
            {
                success: this._getMovablesSuccess,
                onerror: this._getMovablesError
            }
        );
    },

    _apiMarkersSuccess: function(xhr) {
        console.log('[GMap]: GET Api markers status: SUCCESS');
    },
    _apiMarkersError: function(xhr) {
        console.log('[GMap]: GET Api markers status: FAILED');
    },

    _getMovablesSuccess: function(xhr) {
        console.log('[Movable]: GET movables by category id: SUCCESS]');
    },

    _getMovablesError: function(xhr) {
        console.log('[Movable]: GET movables by category id: FAILED');
    }
});

var appState = new ElineState;
var serviceMarkers;