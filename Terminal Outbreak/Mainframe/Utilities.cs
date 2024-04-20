using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Mainframe
{
    internal static class Utilities
    {
        public static bool PressEnter()
        {
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            return true;
        }
    }
}
