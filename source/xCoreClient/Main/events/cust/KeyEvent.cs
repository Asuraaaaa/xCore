using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace xCoreClient
{
    class KeyEvent : BaseScript
    {
        public static async Task IsAnyControlJustPressed()
        {
            List<int> keys = new List<int>();

            foreach (Control item in Enum.GetValues(typeof(Control)))
            {
                keys.Add((int)item);
            }
            int key = 0;
            while (true)
            {
                await Delay(0);
                for (int i = 0; i < keys.Count; i++)
                {
                    key = keys[i];
                    if (Game.IsControlJustPressed(0, (Control)key))
                    {
                        TriggerEvent("xCore:client:keyEvent", key);
                        break;
                    }
                }
            }
        }
    }
}
