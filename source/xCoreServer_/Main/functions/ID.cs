using CitizenFX.Core;
using System;

namespace xCoreServer.main.functions
{
    class ID : BaseScript
    {
        public static int GetPLayerId(Player player)
        {
            int id = Convert.ToInt32(player.Handle);
            Debug.WriteLine("======== ID: " + id);
            return id;
        }
    }
}
