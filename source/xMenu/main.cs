using CitizenFX.Core;
using System.Threading.Tasks;

namespace xMenuClient
{
    public class main : BaseScript
    {
        int i = 0;
        [Tick]
        async Task test()
        {
            i++;
            int b = i * 500;
            b %= 5;
            Debug.WriteLine("" + b);
        }

        public main()
        {

        }
    }
}
