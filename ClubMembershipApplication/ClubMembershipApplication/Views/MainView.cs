using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class MainView : IView
    {
        public IFieldValidator FieldValidator => null;

        IView _registerView = null;
        IView _loginView = null;

        public MainView(IView registerView, IView loginView) 
        { 
            _registerView = registerView;
            _loginView = loginView;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or 'r' to register");

            //Is an enumeration that represents keys on keyboard 
            //With console.ReadKey() can be used to read input
            ConsoleKey key = Console.ReadKey().Key;

            if(key == ConsoleKey.R) 
            { 
                RunUserRegistrationView();
                RunLoginView();
            }
            else if( key == ConsoleKey.L) 
            {
                RunLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.ReadKey();
            }

        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();
        }
        private void RunLoginView()
        {
            _loginView.RunView();
        }
    }
}
