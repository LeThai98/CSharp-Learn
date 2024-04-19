using CSharp_Learn.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Learn.Services
{
    internal class ClassA : IClassA
    {
        private  string _message;
        private  IClassB _classB;
        public ClassA(IClassB classB, string message) 
        {
            this._message = message;
            this._classB = classB;
        }
        public void ActionA()
        {
            this._classB.ActionB();
            Console.WriteLine($"{this._message}");
            Console.WriteLine("Action A Completed");
        }
    }
}
