window.App = Ember.Application.create()
App.Store = Emu.Store.extend 
  revision: 1
  adapter: Emu.RestAdapter.extend
    namespace: "api"