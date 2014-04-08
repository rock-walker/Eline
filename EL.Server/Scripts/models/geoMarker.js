var geoMarker = Backbone.Model.extend({
    defaults: function () {
        return {
            Lat: 0.0001,
            Lng: 0.0001,
            title: "empty marker"
        };
    },

    /*validate: function(attributes) {
        if ((attributes.Lat.indexOf(',') > -1) ||
        (attributes.Lng.indexOf(',') > -1)) {
            return '[Marker model]: coord contains unacceptable symbol \",\"';
        }
    },*/

    initialize: function () {
        /*this.validate(this.attributes);
        this.on('invalid', this._fixApiCoords);
        */
    },

    _fixApiCoords: function () {
        var lat = this.model.get('lat');
        var lng = this.model.get('lng');

        var coords = this.model.attributes;

        this.model.attributes('Lat', lat.replace(',', '.'));
        this.model.attributes('Lng', lng.replace(',', '.'));
    }
})