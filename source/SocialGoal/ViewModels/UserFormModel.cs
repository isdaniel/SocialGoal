using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SocialGoal.Web.ViewModels
{
    public class UserFormModel
    {
        public UserFormModel()
        {
            Login = new LoginFormModel();
            Register = new RegisterFormModel();
        }
        public LoginFormModel Login { get; set; }

        public RegisterFormModel Register { get; set; }
    }
    public class RegisterFormModel
    {
            [Required(ErrorMessage = "*")]
            [Display(Name = "姓")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "名")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "*")]
            [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "密碼")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "確認密碼")]
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "確認密碼和密碼不符")]
            public string ConfirmPassword { get; set; }

            public bool RememberMe { get; set; }
    }

    public class LoginFormModel
    {
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "請確認Email格式")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住帳號密碼")]
        public bool RememberMe { get; set; }
    }
}