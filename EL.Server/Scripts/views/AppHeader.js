var AppHeader = Backbone.View.extend({

    el: $("div.navbar-collapse"),
    searchTemplate: elapp.renderTmpl('homeTemplates', '#search-template', {}),

    isFirstNav: false,

    initialize: function() {
        this.listenTo(Categories, 'add', this.addCategory);
        this.listenTo(Categories, 'reset', this.addAll);
        this.listenTo(Categories, 'all', this.render);
        Categories.fetch();
    },

    render: function(event) {
        if (Categories.length) {
            this.isFirstNav = false;

            if (event === 'sync') {
                Backbone.trigger('menu:built');
                this.addSearch();
            }

        } else {
            this.isFirstNav = true;
        }
    },

    addCategory: function (category) {
        var view = new CategoryView({
            model: category,
            'isActive': this.isFirstNav
        });
        this.$("ul.nav").append(view.render().el);
    },

    addSearch: function () {
        this.$("ul.nav").append(this.searchTemplate);
        App.initSearch();
    },

    // Add all items in the **Todos** collection at once.
    addAll: function () {
        Categories.each(this.addCategory, this);
    },
})