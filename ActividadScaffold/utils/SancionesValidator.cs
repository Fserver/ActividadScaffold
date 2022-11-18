using ActividadScaffold.DTOs;
using ActividadScaffold.Entities;
using FluentValidation;

namespace ActividadScaffold.utils
{
    public class SancionesValidator : AbstractValidator<SancionesDTO>
    {
        public SancionesValidator()
        {
            //RuleFor(s => s.FechaActual).NotNull().NotEmpty().WithMessage("Fecha es Requerido");

            RuleFor(s => s.Sancion).NotNull().WithMessage("Sancion Requerida")
                .Length(3, 100).WithMessage("{PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres."); ;

            RuleFor(s => s.Valor).NotNull().WithMessage("Valor Requerido");
        }

    }public class SancionesValidator2 : AbstractValidator<Sancione>
    {
        public SancionesValidator2()
        {
            //RuleFor(s => s.FechaActual).NotNull().NotEmpty().WithMessage("Fecha es Requerido");

            RuleFor(s => s.Sancion).NotNull().WithMessage("Sancion Requerida")
                .Length(3, 100).WithMessage("{PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres."); ;

            RuleFor(s => s.Valor).NotNull().WithMessage("Valor Requerido");
        }

    }
}
