using CitizenFX.Core;
namespace xCoreClient.events
{
    class PlayerJobLoaded : BaseScript
    {
        [EventHandler("xCore:client:LoadJob")]
        public void playerJobLoaded(string name,string grade)
        {
            Debug.WriteLine($"Nacetl jsem te! Prace: {name}:{grade}");
        }
    }
}
