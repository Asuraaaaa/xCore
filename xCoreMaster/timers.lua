Citizen.CreateThread(function()
	while true do
		Citizen.Wait(50)
		
		local ped = PlayerPedId()
		local pos = GetEntityCoords(ped)
		
		SendNUIMessage(
		{
            status = "position",
            x = pos.x,
            y = pos.y,
            z = pos.z,
		})
	end
end)