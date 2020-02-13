using CitizenFX.Core;
using System;

namespace xCoreServer.main.functions
{
    class ID : BaseScript
    {
        public static int GetPLayerId(Player player) => Convert.ToInt32(player.Handle);
    }
}
