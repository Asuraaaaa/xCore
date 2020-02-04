using CitizenFX.Core;

namespace xCoreClient.main.events
{
    class playerPushKey : BaseScript
    {
        public static void playerKeyEvent(int key)
        {
            Debug.WriteLine("Klíč: " + key);
        }
    }
}
