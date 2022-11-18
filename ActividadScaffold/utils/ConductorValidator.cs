using ActividadScaffold.Entities;
using FluentValidation;

namespace ActividadScaffold.utils
{
    public class ConductorValidator : AbstractValidator<Conductor>
    {
        public ConductorValidator()
        {
            RuleFor(c => c.Identificacion).NotNull().NotEmpty().WithMessage("Identificación Requerida")
                .Length(7, 15).WithMessage("{PropertyName} tiene {TotalLength} dígitos. Debe tener una longitud entre {MinLength} y {MaxLength} dígitos.");

            RuleFor(c => c.Nombre).NotNull().NotNull().NotEmpty().WithMessage("Nombre Requerido")
                .Length(2, 20).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(c => c.Apellido).NotNull().NotNull().NotEmpty().WithMessage("Apellido Requerido")
                .Length(2, 20).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");

            RuleFor(c => c.Telefono).NotNull().NotNull().NotEmpty().WithMessage("Teléfono Requerido")
                .Length(10, 15).WithMessage("{PropertyName} tiene {TotalLength} dígitos. Debe tener una longitud entre {MinLength} y {MaxLength} dígitos.");

            RuleFor(c => c.Email).NotNull().NotNull().NotEmpty().WithMessage("Email Requerido")
                .Length(8, 30).WithMessage("{PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres.");

            RuleFor(c => c.Activo).NotNull();
        }
    }
}
