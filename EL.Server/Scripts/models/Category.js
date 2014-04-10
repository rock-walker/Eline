var CategoryItem = Backbone.Model.extend({
    defaults: function () {
        return {
            Title: "empty todo...",
            Link: "/",
            Parent: 0,
            SubCategories: null,
            Id: 0
        };
    },

    active: function() {
        return this.IsActive();
    }
});