using System.Collections.Generic;

namespace xCoreClient.Main.Player.Markers
{
    public class MarkerHolder
    {
        public static List<MarkClass> MarkerList = new List<MarkClass>();

        public static void saveMarket(MarkClass cl) => MarkerList.Add(cl);
        public static void deleteMarket(MarkClass cl) => MarkerList.Remove(cl);

        public static List<MarkClass> getMarkers() => MarkerList;
    }
}