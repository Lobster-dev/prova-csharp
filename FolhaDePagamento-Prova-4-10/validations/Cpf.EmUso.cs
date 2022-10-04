

using System.ComponentModel.DataAnnotations;
using System.Linq;
using API.Models;

namespace API_Folha. Validations
{
    public class CpfEmUso : ValidationAttribute
    {

        // public CpfEmUso(string cpf)
        // {

        // }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);

            

            string cpf = (string)value;
            DataContext context = (DataContext)validationContext.GetService(typeof(DataContext));
            

            
            if (context.funcionarios.FirstOrDefault(
                f => f.Cpf.Equals(cpf)) != null)
            {
                return new ValidationResult("O CPF do funcionario já está cadastrado");    
            }
            
            return ValidationResult.Success;
        }

    }
}