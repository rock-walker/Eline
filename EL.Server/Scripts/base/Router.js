var AppRouter = Backbone.Router.extend({

    routes: {
        /*"": "list",*/
        "movable/:id": "movableDetails"
    },
    /*
    list: function () {
        this.wineList = new WineCollection();
        this.wineListView = new WineListView({ model: this.wineList });
        this.wineList.fetch();
        $('#sidebar').html(this.wineListView.render().el);
    },
    */
    movableDetails: function (id) {
        this.movable = this.movables.get(id);
        this.mView = new movableView({ model: this.movable });
        $('#content').html(this.mView.render().el);
    }
});

var router = new AppRouter();
Backbone.history.start();
