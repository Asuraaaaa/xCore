using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;
using System.Threading.Tasks;
using xCoreClient.Main.Player.SoundSystem;

namespace xCoreClient
{
    class ClientMain : BaseScript
    {      
        public ClientMain()
        {          

        }
        int npc_seller = 0;
        public async Task spawnNpcAsync()
        {
            Vector3 seller = Game.Player.Character.Position;
            uint hash = (uint)API.GetHashKey("s_m_m_hairdress_01");
            while (!API.HasModelLoaded(hash))
            {
                API.RequestModel(hash);
                await Delay(200);
            }

            npc_seller = API.CreatePed(2, hash, seller.X, seller.Y, seller.Z, 0f, false, true);
        }

        [Command("npcspawn")]
        void npc()
        {
            spawnNpcAsync();
        }

        [Tick]
        async Task oko()
        {
            await Delay(33);
            if(npc_seller != 0)
            {
                Vector3 pos = API.GetEntityCoords(npc_seller, true);
                PlayerSound.Position("clap", pos.X, pos.Y, pos.Z);
            }
        }

        [Command("soundthree")]
        void tffffest()
        {
            Vector3 pos = Game.Player.Character.Position;

            PlayerSound.Play("test", 1f, pos.X, pos.Y, pos.Z);
        }

        [Command("soundtwo")]
        void thhhhest()
        {
            Vector3 pos = Game.Player.Character.Position;

            PlayerSound.Play("clap", 0.5f, pos.X, pos.Y, pos.Z);
        }

        [Command("sound")]
        void test(string[] args)
        {
            Vector3 pos = Game.Player.Character.Position;

            PlayerSound.PLayUrl("custom", "http://relisoft.cz/assets/gta.mp3", 0.5f);
        }

        [Command("stopsound")]
        void asdasd()
        {
            PlayerSound.Stop("clap");
        }
    }
}
