using FluentValidation;
using Paradigmi.Lib.App.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Validatori
{
    public class EliminaLibroValidatore : AbstractValidator<EliminaLibroRequest>
    {
        public EliminaLibroValidatore()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Il campo Id non pò essere vuoto")
                .GreaterThan(0)
                .WithMessage("Il campo Id deve essere maggiore di 0");
        }
    }
}
