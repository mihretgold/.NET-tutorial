// See https://aka.ms/new-console-template for more information
using ClubMembershipApplication.Views;


class Program
{
    static void Main(string[] args)
    {
        IView mainView = Factory.GetMainObject();
        mainView.RunView();

        Console.ReadKey();
    }
}