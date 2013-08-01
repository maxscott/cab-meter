Handlebars.registerHelper 'date', (property, options) ->
        date = Ember.Handlebars.get(this, property, options)
        dateString = moment(date).format("MMM Do YYYY") if date != ""
        dateString ||= ""
        new Handlebars.SafeString(dateString)