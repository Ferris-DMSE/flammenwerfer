﻿using System;
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
            CommandInput input = new CommandInput();
            input.InputReader();
        }
        public void Restart_Point()
        {
            CommandInput input = new CommandInput();
            input.InputReader();
        }
    }
}
