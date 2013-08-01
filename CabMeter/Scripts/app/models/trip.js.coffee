App.Trip = Emu.Model.extend
	minutesAbove6Mph : Emu.field("number")
	milesUnder6Mph : Emu.field("number")
	startDate : Emu.field("string")
	startTime : Emu.field("string")
	totalFare : Emu.field("number")