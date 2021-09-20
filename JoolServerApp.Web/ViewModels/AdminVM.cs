namespace JoolServerApp.Web.ViewModels
{
    public class AdminVM
    {

        public int Manufacturer_ID { get; set; }
        public int Sales_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public string Product_Name { get; set; }
        public byte[] Product_Image { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Model_Year { get; set; }
        public string Series_Info { get; set; }
        public int Document_ID { get; set; }
        public string Featured { get; set; }
    }
}