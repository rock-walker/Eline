var TimeRangesAggregator = function() {
    var fullCldSlots;

    function _setupRangeStatus(status) {
        var color = "green";

        for (var slot in elapp.SLOTS) {
            if (slot.value == status) {
                color = slot.color;
                break;
            }
        }
        return App.getLayoutColorCode(color);
    };

    function _convertToFulCldEvents(date) {
        if (!date)
            date = new Date();

        var d = date.getDay()+1;
        var m = date.getMonth();
        var y = date.getFullYear();

        fullCldSlots = $.map(srvTimeRanges.models, $.proxy(function (item) {
            var reservation = item.attributes;
            return {
                title: 'txt',
                start: new Date(y, m, d, reservation.StartH, reservation.StartM),
                end: new Date(y, m, d, reservation.EndH, reservation.EndM),
                backgroundColor: _setupRangeStatus(reservation.Status),
                allDay: false
            };
        }, this));
    };

    return {
        collect: function(type, id, date) {

            var deferred = $.Deferred();

            console.log("[ServiceType]: " + type + " Id:" + id);
            console.log("[Full Calendar]: get results from server");
            srvTimeRanges.setupUrl(type, id);
            srvTimeRanges.fetch(
            {
                success: function () {
                    _convertToFulCldEvents(date);
                    deferred.resolve();
                },
                error: function () { 'err'; }
            });

            return deferred;
        },

        getSlots: function() {
            return fullCldSlots;
        }
    };
}();