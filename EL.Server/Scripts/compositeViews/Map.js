var Map = Backbone.View.extend({
    gmap: null,
    el: "#map",

    initialize: function () {
        this.render();
        this.listenTo(serviceMarkers, 'add', this.addMarker);
        //this.listenTo(serviceMarkers, 'sync', this._syncMarker);
        this.listenTo(serviceMarkers, 'all', this.anyMarkerEvent);
    },

    render: function () {
        this.gmap = new GMaps({
            div: this.el,
            lat: 53.9,
            lng: 27.55,
            zoom: 13
        });

        this.personGeoLocation();

        return this;
    },

    anyMarkerEvent: function(event) {
        console.log('[GMap]: markers event is: ' + event);
    },

    _syncMarker: function(markers) {
        console.log('[GMap]: sync markers: ' + markers);
        if (markers.length == 0) {
            //var marker =
                this.gmap.addMarker({
                lat: -13.004333,
                lng: -38.494333,
                title: 'Loop, Inc.',
                infoWindow: {
                    content: "<b>Loop, Inc.</b> 795 Park Ave, Suite 120<br>San <a href='tut.by'>Francisco</a>, CA 94107"
                }
            });

            //marker.infoWindow.open(this.gmap, marker);
        }
    },

    

    addMarker: function(marker) {
        this.gmap.addMarker({
            lat: marker.get('Lat'),
            lng: marker.get('Lng')
        });
    },

    getGmap: function() {
        return this.gmap;
    },

    personGeoLocation: function() {
        // Try HTML5 geolocation
        if (navigator.geolocation) {

            navigator.geolocation.getCurrentPosition($.proxy(function (position) {
                    console.log('[GMap]: define position of person');
                var pos = new google.maps.LatLng(position.coords.latitude,
                                                 position.coords.longitude);

                    this.gmap.addMarker({
                        lat: pos.k,
                        lng: pos.A,
                        title: 'You!'
                    });
                /*
                var infowindow = new google.maps.InfoWindow({
                    map: this.gmap,
                    position: pos,
                    content: 'Location found using HTML5.'
                });
                */
                this.gmap.setCenter(pos.k, pos.A);
            }, this),

            $.proxy(function () {
                this.handleNoGeolocation(true);
            }, this));
        } else {
            // Browser doesn't support Geolocation
            this.handleNoGeolocation(false);
        }
    },

    handleNoGeolocation: function(errorFlag) {
        var content;
        if (errorFlag) {
            content = 'Error: The Geolocation service failed.';
        } else {
            content = 'Error: Your browser doesn\'t support geolocation.';
        }

        var options = {
            map: this.gmap,
            position: new google.maps.LatLng(60, 105),
            content: content
        };

        var infowindow = new google.maps.InfoWindow(options);
        this.gmap.setCenter(options.position);
    }
})