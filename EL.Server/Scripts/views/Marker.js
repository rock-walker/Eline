var MarkerView = Backbone.View.extend({
    initialize: function() {
        
    },

    render: function() {
        return this;
    },

    clear: function() {
        this.model.destroy();
    }
})