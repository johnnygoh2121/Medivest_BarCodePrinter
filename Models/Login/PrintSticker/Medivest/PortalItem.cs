namespace Medivest_BarCodePrinter.Models.Login.PrintSticker.Medivest
{
    public class PortalItem
    {
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public double onhand { get; set; }
        public double onorder { get; set; }
        public double iscommited { get; set; }
        public double available { get; set; }
        public string uom { get; set; }
        public string brand { get; set; }
        public string model { get; set; }

        // for checkbox 
        public bool isprint { get; set; } = false;
    }
}
