using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows; //because of Clipboard (Windows.PresentationCore)


namespace ProjectEulerCsharp
{
    class Program
    {
        [STAThread] 
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            var result = Problems._6();
            var duration = DateTime.Now - start;

            Console.WriteLine("result is: " + result);
            Console.WriteLine("took {0} seconds to compute", duration.TotalSeconds);
            Clipboard.SetData(DataFormats.Text, (Object)result); //copy to clipboard
            Console.Read();
            

        }
    }
}
