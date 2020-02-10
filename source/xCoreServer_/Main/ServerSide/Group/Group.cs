using CitizenFX.Core;
using System.Collections.Generic;

namespace xCoreServer.main.ServerSide.Group
{
    public class Group : BaseScript
    {
        public static List<string> groups = new List<string>();

        public static void add(string group)
        {
            if(!contains(group))
            {
                groups.Add(group);
                Debug.WriteLine("Creating new group: " + group);
            }
        }

        public List<string> getGroups() => groups;

        public static bool contains(string group)
        {
            if (groups.Contains(group)) return true;
            return false;
        }

        public static bool exists(string group)
        {
            if (groups.Contains(group)) return true;
            return false;
        }
    }
}
