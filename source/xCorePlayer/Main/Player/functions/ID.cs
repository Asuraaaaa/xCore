using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace xCoreClient.main.Player
{
    public class ID : BaseScript
    {
        public static int playerID()
        {
            return API.GetPlayerServerId(API.NetworkGetEntityOwner(API.PlayerPedId()));
        }
    }
}
