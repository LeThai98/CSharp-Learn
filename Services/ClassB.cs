using CSharp_Learn.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Learn.Services
{
    internal class ClassB : IClassB
    {
        public void ActionB()
        {
            Console.WriteLine("Action B completed");
        }
    }
}
