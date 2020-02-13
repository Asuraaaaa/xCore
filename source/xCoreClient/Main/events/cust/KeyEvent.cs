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
    }
}
