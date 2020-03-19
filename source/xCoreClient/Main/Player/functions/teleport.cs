using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;

namespace xCoreClient.Main.Player.teleport
{
    public class teleport : BaseScript
    {
        [EventHandler("xCore:Client:teleport")]
        public static void tele(int entity, Vector3 vec, float heading = -999)
        {
            teleportPlayer(entity, vec, heading);
        }

        public static async Task teleportPlayer(int entity,Vector3 vec,float heading = -999)
        {
            if(API.DoesEntityExist(entity))
            {
                API.RequestCollisionAtCoord(vec.X,vec.Y,vec.Z);
                while(!API.HasCollisionLoadedAroundEntity(entity))
                {
                    await Delay(50);
                }
                API.SetEntityCoords(entity, vec.X, vec.Y, vec.Z, false, false, false, false);



                if (heading == -999) API.SetEntityHeading(entity, API.GetEntityHeading(entity));
                else API.SetEntityHeading(entity, heading);
            }
        }
    }
}
