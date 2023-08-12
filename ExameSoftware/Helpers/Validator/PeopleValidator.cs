using System;
using ExameSoftware.Dtos;
using FluentValidation;

namespace ExameSoftware.Helpers.Validator
{
	public class PeopleValidator : AbstractValidator<PeopleRequest>
	{
		public PeopleValidator()
		{
			//Validators for name
			RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("El nombre no debe estar vacio");
            RuleFor(x => x.Name).Must(n => n.Length > 0 && n.Length <= 50).WithMessage("El nombre no debe ser mayor a 50 caracteres");


			//Validator for age
			RuleFor(x => x.Age).GreaterThan(0).WithMessage("La edad no tiene un formato correcto");

			//Validator for email
			RuleFor(x => x.Email).NotEmpty().WithMessage("El email no debe estar vacio");
			RuleFor(x => x.Email).EmailAddress().WithMessage("El email no tiene un formato correcto");
            RuleFor(x => x.Name).Must(n => n.Length > 0 && n.Length <= 150).WithMessage("El email no debe ser mayor a 50 caracteres");

        }
    }
}

