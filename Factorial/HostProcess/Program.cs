using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain Domain = AppDomain.CreateDomain("Domain new");
            Assembly asmEnterFactorial = Domain.Load(AssemblyName.GetAssemblyName("Factorial.exe"));
         //   Assembly asmResultFactorial = Domain.Load(AssemblyName.GetAssemblyName("Result.exe"));
      //      Module module = asmEnterFactorial.GetModule("Factorial.exe");
         //   Type type = module.GetType("Factorial.MainWindow");
        
                Window DrawerWindow = Activator.CreateInstance(asmEnterFactorial.GetType("Factorial.MainWindow")) as Window;
            
            //DrawerWindow = Activator.CreateInstance(asmEnterFactorial.GetType("Factorial.MainWindow"),
            //    new object[]
            //    {
            //        asmEnterFactorial.GetModule("Factorial.exe"),
            //        DrawerWindow
            //    }) as Window;

         //   MethodInfo method = type.GetMethod("");
         ///   method.Invoke(null, null);
       //     asmEnterFactorial.GetModule("Factorial.exe").GetType("Factorial.MainWindow").GetMethod("MainWindow").Invoke(null, null);
            AppDomain.Unload(Domain);
           
        }
    }
}
