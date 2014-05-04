var Movables = Backbone.View.extend({
    el: "#movables",

    initialize: function() {
        this.render();
        this.listenTo(movables, 'add', this._addMovable);
    },

    render: function() {
        return this;
    },

    _addMovable: function(movable) {
        var view = new movableView({ model: movable });
        this.$el.append(view.render().el);
        this.$el.append("<hr class='blog-post-sep'>");
    },

    resetAll: function () {
        console.log('[Movable View]: clear all');
        _.invoke(movables.models, 'destroy');
        this.$el.empty();
        movables.reset();
    }
})