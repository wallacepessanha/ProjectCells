namespace PCE.WebApp.MVC.Models
{
    public class Operation
    {
        public int IdOperation { get; set; }
        public string Description { get; set; }


        public static List<Operation> ListComboOperation()
        {
            var listOperations = new List<Operation> {                
                new Operation { IdOperation = 1, Description = "Teste Operação"},
                new Operation { IdOperation = 2, Description = "Teste Célula" }
                };

            return listOperations;
        }
    }
}
