using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstitutoApi.Validations
{
    public class FechaNacimientoValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (DateTime.TryParse(value.ToString(), out DateTime fecha))
            {
                if (fecha.Date >= DateTime.Now.Date)
                    return new ValidationResult($"El campo {validationContext.DisplayName} no puede ser mayor o igual a la fecha {DateTime.Now.Date}. ");

                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"El campo {validationContext.DisplayName} no presenta el formato correcto.");
            }

            //  string codigoAgente = validationContext.ObjectInstance.GetType().GetProperty(_codigoAgenteProperty).GetValue(validationContext.ObjectInstance, null)?.ToString();
            //   var tenantProvider = validationContext.GetService(typeof(ITenantProvider)) as ITenantProvider;

        }
    }
}
