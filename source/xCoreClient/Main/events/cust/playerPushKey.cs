using CitizenFX.Core;

namespace xCoreClient.main.events
{
    class playerPushKey : BaseScript
    {
        [EventHandler("xCore:client:keyEvent")]
        public static void playerKeyEvent(int key)
        {
            Debug.WriteLine("Klic: " + key);
        }
    }
}
