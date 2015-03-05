var movableItem = Backbone.Model.extend({
    defaults: function() {
        return {
            Id: 0,
            First: 'Samantha',
            Last: 'Brown',
            Middle: '',
            Details: {
                Experience: ''
            },
            Gallery: {
                Thumbnail: '',
                FolderId: ''
            },
        };
    },

    initialize: function() {
        
    },
})