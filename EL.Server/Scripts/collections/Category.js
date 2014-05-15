var CategoryList = Backbone.Collection.extend({
    model: CategoryItem,
    url: elapp.urls.baseUrl + 'api/category/hierarchical',
    
    initialize: function () {

    },
    /* very interesting using of without: need additional experience
    remaining: function () {
        return this.without.apply(this, this.done());
    },*/

    singleActive: function () {
        return this.first.apply(this, this.active());
    }

});

var Categories = new CategoryList;