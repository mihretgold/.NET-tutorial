using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        ILogin _loginUser = null;
        public IFieldValidator FieldValidator => null;
        
        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email Addreess");

            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password");

            string password = Console.ReadLine();

            User user = _loginUser.Login(emailAddress, password);

            if(user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();  

            }
            else
            {
                Console.Clear();
                CommonOutputFormat1.changeFontColor(FontTheme.Danger);
                Console.WriteLine("The Credentials that you entered do not match our records");
                CommonOutputFormat1.changeFontColor(FontTheme.Default);
                Console.ReadKey();

            }
        }
    }
}
