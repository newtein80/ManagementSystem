using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Infra.Injections.InjectionTest
{
    public class DependencyTest : IDependencyTest
    {
        public void Test()
        {
            Console.WriteLine("Dependenty Injection Test!");
        }
    }
}
