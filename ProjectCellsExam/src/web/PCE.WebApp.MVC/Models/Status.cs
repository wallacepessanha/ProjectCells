namespace PCE.WebApp.MVC.Models
{
    public class Status
    {
        public int IdStatus { get; set; }
        public string Description { get; set; }

        public static List<Status> ListComboStatus()
        {
            var listStatus = new List<Status> {
                new Status { IdStatus = 1, Description = "Válido" },
                new Status { IdStatus = 0, Description = "Inválido"}
                };

            return listStatus;
        }
    }
}
