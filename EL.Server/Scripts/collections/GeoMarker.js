var MarkerCollection = Backbone.Collection.extend({
    model: geoMarker,
    url: function() {
        return '/api/map/' + appState.get('currentCategory');
    },

    initialize: function (params) {
        console.log('[Map: Collection]: initialize, state: ' + appState.get('currentCategory'));
    }
});

var serviceMarkers = new MarkerCollection;