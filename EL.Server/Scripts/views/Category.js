var CategoryView = Backbone.View.extend({
    tagName: "li",
    className: "dropdown",

    categoryLevel0: elapp.renderTmpl('homeTemplates', "#category-zero-level-template"),
    categoryLevel1: elapp.renderTmpl('homeTemplates', "#category-first-level-template"),

    events: {
        'click': '_selectCategory'
    },
    stationeryObjects: null,

    initialize: function(options) {
        this.isActive = options.isActive;

        _.bindAll(this, 'render');
        //this.listenTo(this.model, 'change', this.render);
        this.listenTo(this.model, 'destroy', this.remove);
    },

    render: function (subModel) {

        var renderNavModel = subModel || this.model;
        var level = renderNavModel.get('Parent');

        if (level === 0) {
            this.$el.html(this.categoryLevel0(renderNavModel.toJSON()));
            this.$el.toggleClass('active', this.isActive);
            if (this.isActive)
                this._selectCategory();
        } else {
            this.$("ul.dropdown-menu").append(this.categoryLevel1(renderNavModel.toJSON()));
        }

        var subCategories = renderNavModel.get("SubCategories");
        if (subCategories != null) {
            this.$el.append("<ul class='dropdown-menu'></ul>");
            $.each(subCategories, $.proxy(function(i, item) {
                this.render(new CategoryItem(item));
            }, this));
        }

        return this;
    },

    _selectCategory: function (event) {
        this.model.set('isActive', true);
        this._setCurrentCategory();
        return false;
    },

    _setCurrentCategory: function (id) {
        var serviceId = id || this.model.get('Id');
        appState.set('currentCategory', serviceId);
    },

    clear: function() {
        this.model.destroy();
    }
})