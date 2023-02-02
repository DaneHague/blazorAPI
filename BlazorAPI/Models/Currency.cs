using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorAPI.Models
{
   

    public class Currency
    {
        public bool verified { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public string icon { get; set; }
        public int stackSize { get; set; }
        public int maxStackSize { get; set; }
        public string league { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string typeLine { get; set; }
        public string baseType { get; set; }
        public bool identified { get; set; }
        public int ilvl { get; set; }
        public string rewardText { get; set; }
        public string cardText { get; set; }
        public int frameType { get; set; }
        public string artFilename { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string inventoryId { get; set; }
    }
}
