var CategoryItem = Backbone.Model.extend({
    defaults: function () {
        return {
            Title: "empty todo...",
            Link: "/",
            Parent: 0,
            SubCategories: null,
        };
    }
});

var CategoryList = Backbone.Collection.extend({
    model: CategoryItem,
    url: 'api/category/hierarchical'

    /* very interesting using of without: need additional experience
    remaining: function () {
        return this.without.apply(this, this.done());
    },*/
});

var Categories = new CategoryList;