using ActividadScaffold.Entities;
using FluentValidation;

namespace ActividadScaffold.utils
{
    public class MatriculaValidator : AbstractValidator<Matricula>
    {
        public MatriculaValidator()
        {
            RuleFor(m => m.Numero).NotNull().NotEmpty().WithMessage("Número Requerido")
                .Length(6, 20).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(m => m.FechaExpedicion).NotNull().WithMessage("Fecha de Expedición Requerida");

            RuleFor(m => m.ValidaHasta).NotNull().WithMessage("Fecha de Vigencia Requerida");

            RuleFor(m => m.Activo).NotNull();
        }

    }
}
