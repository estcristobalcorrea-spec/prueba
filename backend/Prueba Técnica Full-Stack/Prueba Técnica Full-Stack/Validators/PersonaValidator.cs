using FluentValidation;
using Prueba_Técnica.Models;

namespace Prueba_Técnica.Validators
{
    public class PersonaValidator : AbstractValidator<Persona>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.Correo)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Correo))
                .WithMessage("Correo inválido");
        }
    }
}

