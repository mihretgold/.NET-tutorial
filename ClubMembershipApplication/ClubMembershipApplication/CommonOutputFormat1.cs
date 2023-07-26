using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication
{
    public enum FontTheme
    {
        Default,
        Danger, 
        Success
    }
    public class CommonOutputFormat1
    {
        public static void changeFontColor(FontTheme fontTheme)
        {
            if (fontTheme == FontTheme.Danger) 
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(fontTheme == FontTheme.Success)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }   

        }
    }
}
