namespace JoolServerApp.Web.ViewModels
{
    //Joins must be done to get city and state for project
    public class ProjectVM
    {
        public int? Project_ID { get; set; }
        public string Project_Name { get; set; }
        public string Project_Address1 { get; set; }
        public string Project_Address2 { get; set; }
        public string Project_City { get; set; }
        //Insert city value here from city table
        public string Project_State { get; set; }
        //Insert State value here from state table
        public int? Project_Size { get; set; }
        public string Client_Name { get; set; }

    }
}