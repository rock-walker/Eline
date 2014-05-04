var movableView = Backbone.View.extend({
    tagName: "div",
    className: "row",

    template: elapp.renderTmpl('homeTemplates', '#movable-item'),

    events: {
        'click': '_selectMovable'
    },

    initialize: function (options) {
        console.log('[Movable Model]: init ' + this.model.get('Id'));
        this.listenTo(this.model, 'destroy', this.clear);
    },

    render: function() {
        this.$el.html(this.template(this.model.toJSON()));
        return this;
    },

    _selectMovable: function(event) {
        
    },

    clear: function() {
        this.remove();
        this.unbind();
        console.log('[Movable Model]: clear id: ' + this.model.get('Id'));
    }
})