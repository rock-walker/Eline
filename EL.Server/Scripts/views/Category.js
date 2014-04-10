var CategoryView = Backbone.View.extend({
    tagName: "li",
    className: "dropdown",

    categoryLevel0: elapp.renderTmpl('homeTemplates', "#category-zero-level-template"),
    categoryLevel1: elapp.renderTmpl('homeTemplates', "#category-first-level-template"),
    
    events: {
        'click': '_selectCategory'
    },
    
    initialize: function(options) {
        this.isActive = options.isActive;

        _.bindAll(this, 'render');
        //this.listenTo(this.model, 'change', this.render);
        this.listenTo(this.model, 'destroy', this.remove);
    },

    render: function (subView) {

        var renderNavModel = subView ? subView.model : this.model;
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
            $.each(subCategories, $.proxy(function (i, item) {
                var innerView = new CategoryView({ model: new CategoryItem(item) });
                this.render(innerView);
            }, this));
        }

        return this;
    },

    _selectCategory: function (event) {
        this.model.set('isActive', true);
        var modelId = this.model.get('Id');
        if (event) {
            var target = $(event.target);
            if (target.data('id'))
                modelId = target.data('id');
        }
        this._setCurrentCategory(modelId);
        return false;
    },

    _setCurrentCategory: function (id) {
        //var serviceId = id || this.model.get('Id');
        appState.set('currentCategory', id);
    },

    clear: function() {
        this.model.destroy();
    }
})