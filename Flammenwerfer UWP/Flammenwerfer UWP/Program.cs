using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            CommandInput input = new CommandInput();
            input.InputReader();
        }

        public void Restart_Point()
        {
            CommandInput input = new CommandInput();
            input.InputReader();
        }
    }

    class XMLPATH
    {
        public string Path = "../../UserData.xml";
    }
}
