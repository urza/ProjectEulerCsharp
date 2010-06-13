using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace ProjectEulerCsharp
{
    class Program
    {
        [STAThread] 
        static void Main(string[] args)
        {
            var result = Problems._5();

            Console.WriteLine(result);
            Console.Read();
            Clipboard.SetData(DataFormats.Text, (Object)result);

        }
    }
}
