using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;

namespace xCoreClient.Main.Player.SoundSystem
{
    public class PlayerSound : BaseScript
    {
        public static void PLayUrl(string name_, string url_, float volume_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "url",
                name = name_,
                url = url_,
                x = 0,
                y = 0,
                z = 0,
                dynamic = false,
                volume = volume_,
            });
            API.SendNuiMessage(json);
        }
        public static void PLayUrl(string name_,string url_, float volume_, float x_, float y_, float z_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "url",
                name = name_,
                url = url_,
                x = x_,
                y = y_,
                z = z_,
                dynamic = true,
                volume = volume_,
            });
            API.SendNuiMessage(json);
        }

        public static void Play(string name_,float volume_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "play",
                name = name_,
                x = 0,
                y = 0,
                z = 0,
                dynamic = false,
                volume = volume_,
            });
            Debug.WriteLine(json);
            API.SendNuiMessage(json);
        }
        public static void Position(string name_, float x_, float y_, float z_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "soundPosition",
                name = name_,
                x = x_,
                y = y_,
                z = z_
            });
            API.SendNuiMessage(json);
        }

        public static void Play(string name_, float volume_, float x_, float y_, float z_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "play",
                name = name_,
                x = x_,
                y = y_,
                z = z_,
                dynamic = true,
                volume = volume_,
            });
            API.SendNuiMessage(json);
        }

        public static void Stop(string name_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "delete",
                name = name_
            });
            API.SendNuiMessage(json);
        }

        public static void Resume(string name_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "resume",
                name = name_,
            });
            API.SendNuiMessage(json);
        }

        public static void Pause(string name_)
        {
            string json = JsonConvert.SerializeObject(new
            {
                status = "pause",
                name = name_,
            });
            API.SendNuiMessage(json);
        }
    }
}
