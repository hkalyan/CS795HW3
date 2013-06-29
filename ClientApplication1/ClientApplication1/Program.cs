using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

using Assembly1;
using Assembly2;
using System.Reflection;

namespace ClientApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain apd = AppDomain.CreateDomain("HariCS795");
            Console.WriteLine("Loading Assembly 1");
            Program.loadAssembly1();
            Program.loadAssembly2();
        }

        static void loadAssembly1()
        {

            CodeAccessPermission permission = new DnsPermission(PermissionState.Unrestricted);
            try
            {
                permission.Demand();

                Assembly1.Class1.openPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Assembly assembly = Assembly.LoadFrom("assembly1.dll");
            Console.WriteLine("Strong Name : " + assembly.GetName());

        }

        static void loadAssembly2()
        {
            Assembly assembly = Assembly.LoadFrom("assembly2.dll");

            Console.WriteLine("Strong Name : " + assembly.GetName());
            try
            {
                PermissionSet perr = new PermissionSet(PermissionState.None);


                perr.AddPermission(new FileIOPermission(PermissionState.Unrestricted));

                perr.PermitOnly();
                perr.Demand();

                Assembly2.AssemblyClass2.openPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }


        }
    }
}
