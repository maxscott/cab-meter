App.ApplicationRoute = Ember.Route.extend
	model: () -> App.Trip.createRecord()
	events:
		getFare: -> @get("controller.content").save()