using CitizenFX.Core;
using System;
using System.Threading.Tasks;

namespace xCoreClient
{
    class KeyEvent : BaseScript
    {
        [Tick]
        public async Task IsAnyControlJustPressed()
        {
            foreach (Control item in Enum.GetValues(typeof(Control)))
            {
                if(Game.IsControlJustPressed(0, item))
                {
                    TriggerEvent("xCore:client:keyEvent", (int)item);
                    break;
                }
            }
        }

        /*
        [Command("object")]
        void cmd()
        {
            Vector3 vec = Game.Player.Character.Position;
            int obj = API.CreateObject(API.GetHashKey("prop_mk_boost"), vec.X, vec.Y, vec.Z, false, false, true);
            
        }
        */
    }
}
