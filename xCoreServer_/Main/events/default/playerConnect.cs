using CitizenFX.Core;

namespace xCoreServer.main.events
{
    class playerConnect : BaseScript
    {
        [EventHandler("playerConnecting")]
        public static void OnPlayerConnecting([FromSource]Player player, string playerName, dynamic setKickReason, dynamic deferrals)
        {
            Debug.WriteLine($"Player {player.Name} has connected to the server!");
        }
    }
}
