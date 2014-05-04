var movableItem = Backbone.Model.extend({
    defaults: function() {
        return {
            First: 'Samantha',
            Last: 'Brown',
            Middle: '',
            Details: {
                Experience: ''
            },
            Gallery: {
                Avatar: '',
                FolderId: ''
            },
        };
    },

    initialize: function() {
        
    },
})