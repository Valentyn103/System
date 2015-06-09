using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain Domain = AppDomain.CreateDomain("Domain");
            Assembly asm = Domain.Load(AssemblyName.GetAssemblyName("ClassLibrary.dll"));
            Module module = asm.GetModule("ClassLibrary.dll");
            Type type = module.GetType("Library.SampleClass");
            MethodInfo method = type.GetMethod("DoSome");
            method.Invoke(null, null);
            asm.GetModule("ClassLibrary.dll").GetType("Library.SampleClass").GetMethod("DoSome").Invoke(null, null);
            AppDomain.Unload(Domain);
        }
    }
   
}
