using FluentValidation;
using Paradigmi.Lib.App.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Lib.App.Validatori
{
    public class EliminaCategoriaRequestValidatore : AbstractValidator<EliminaCategoriaRequest>
    {
        public EliminaCategoriaRequestValidatore()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo");
        }
    }
}
