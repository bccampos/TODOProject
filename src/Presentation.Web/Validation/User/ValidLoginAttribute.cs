using System.ComponentModel.DataAnnotations;
using Core.Domain.Model;
using CoreUsers = Core.Domain.Model.Users;
using Ninject;
using Presentation.Web.Models.Input;
using Core.Interface;
using System.Threading.Tasks;

namespace Presentation.Web.Validation.User
{
    public class ValidLoginAttribute : UserValidationAttributeBase
    {
        //[Inject]
        //public override IUserTaskService _service { get; set; }

        //public ValidLoginAttribute(string message = "") : base(message)
        //{
            
        //}

        //public ValidLoginAttribute()
        //    : this("Invalid Email or Password.")
        //{

        //}

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    return GetValidationResult((string)value, validationContext);
        //}

        //protected Task<ValidationResult> GetValidationResult(string email, ValidationContext context)
        //{
        //    if (string.IsNullOrEmpty(email)) return null;

        //    var user = await _service.GetUserByCredentials(email, "123");
        //    var input = context.ObjectInstance as LoginInput;
        //    if(user == null || ! user.IsAuthenticated(input.Password))
        //        return new ValidationResult(Message);

        //    return null;
        //}

        
    }
}