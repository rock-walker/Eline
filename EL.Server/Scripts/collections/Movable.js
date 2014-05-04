MovableList = Backbone.Collection.extend({
    model: movableItem,
    url: function() {
        return 'api/movable/bycategory/' + appState.get('currentCategory');
    },

    initialize: function() {
        //console.log('[Movable:Collection] initialize, currentCategory' + appState.get('currentCategory'));
    },
    /*
    done: function() {
        return this.where({del: true});
    }*/
});

var movables = new MovableList;