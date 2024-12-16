using Microsoft.AspNetCore.Mvc;
using Paradigmi.Lib.App.Models.Response;

namespace Paradigmi.Lib.Web.Risultati
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
        {
            // ogni chiave non validata correttamente viene aggiunta al model state 
            var retErrors = new List<string>();
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for (var i = 0; i < errors.Count; i++)
                    retErrors.Add(errors[i].ErrorMessage);
            }

            BadResponse response = (BadResponse)Value;
            response.Errors = retErrors;
        }
    }
}
