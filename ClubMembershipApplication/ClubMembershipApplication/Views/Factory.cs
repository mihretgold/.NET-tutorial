using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public static class Factory
    {
        public static IView GetMainObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator userRegistrationValidator = new UserRegistratioValidator(register);
            userRegistrationValidator.InitliseValidatorDelegates();

            IView registerView = new UserRegistrationView(register, userRegistrationValidator);
            IView loginView = new UserLoginView(login);
            IView mainView = new MainView(registerView, loginView);

            return mainView;



        }
    }
}
