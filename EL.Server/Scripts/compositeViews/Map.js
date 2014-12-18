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
        console.log('[GMap]:finish rendering');
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

            var options = {
                enableHighAccuracy: true,
                timeout: 5000,
                maximumAge: 60000
            };

            var locationTimeout = setTimeout($.proxy(function () {
                this.handleNoGeolocation(true);
            }, this), 10000);

            navigator.geolocation.getCurrentPosition(
                //success
                $.proxy(function (position) {
                    console.log('[GMap]: <start>: define position of person');
                    if (position && position.coords) {
                        clearTimeout(locationTimeout);
                        var pos = new google.maps.LatLng(position.coords.latitude,
                            position.coords.longitude);

                        this.gmap.addMarker({
                            lat: pos.k,
                            lng: pos.D,
                            title: 'You!'
                        });
                        /*
                    var infowindow = new google.maps.InfoWindow({
                        map: this.gmap,
                        position: pos,
                        content: 'Location found using HTML5.'
                    });
                    */
                        this.gmap.setCenter(pos.k, pos.D);
                    } else {
                        console.log('[GMap]: user geo-position wasn\'t defined');
                    }
                    console.log('[GMap]: <end>: person position has defined');
                }, this),
                //error
                $.proxy(function () {
                    this.handleNoGeolocation(true);
                }, this),
                //options
                options);
            console.log('[GMap]: success browser geolocation');
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

        //var infowindow = new google.maps.InfoWindow(options);
        this.gmap.setCenter(options.position.k, options.position.D);
    }
})