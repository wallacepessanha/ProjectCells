using Microsoft.AspNetCore.Mvc.Razor;
using PCE.WebApp.MVC.Models;

namespace PCE.WebApp.MVC.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataOperationDescricao(this RazorPage page, int idOperation)
        {
            var operations = Operation.ListComboOperation();

            foreach (var operation in operations)
            {
                if (idOperation == operation.IdOperation)
                    return operation.Description;                
            }

            return "";
        }

        public static string FormataStatusDescricao(this RazorPage page, int idStatus)
        {
            var listStatus = Status.ListComboStatus();

            foreach (var status in listStatus)
            {
                if (idStatus == status.IdStatus)
                    return status.Description;
            }

            return "";
        }
    }
}
