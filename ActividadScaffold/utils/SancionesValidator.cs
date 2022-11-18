using ActividadScaffold.DTOs;
using FluentValidation;

namespace ActividadScaffold.utils
{
    public class SancionesValidator : AbstractValidator<SancionesDTO>
    {
        public SancionesValidator()
        {
            RuleFor(s => s.FechaActual).NotNull().NotEmpty().WithMessage("Fecha es Requerido");

            RuleFor(s => s.Sancion).NotNull().WithMessage("Sancion Requerida")
                .Length(10, 100).WithMessage("{PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres."); ;

            RuleFor(s => s.Valor).NotNull().WithMessage("Valor Requerido");
        }

    }
}
