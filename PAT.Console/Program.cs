using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("File name: {0}", args[0]);
            ApplicationMain app = new ApplicationMain();
            app.readFile(args[0]);
            app.startVerify();
        }
    }
}
