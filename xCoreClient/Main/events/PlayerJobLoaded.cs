using CitizenFX.Core;
namespace xCoreClient.events
{
    class PlayerJobLoaded : BaseScript
    {
        public static void playerJobLoaded(string name,string grade)
        {
            Debug.WriteLine($"Načetl jsem tě! Prace: {name}:{grade}");
        }
    }
}
