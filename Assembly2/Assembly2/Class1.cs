using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: System.Reflection.AssemblyKeyFile("C:\\Keys\\assemblykey1.snk")]
[assembly: System.Reflection.AssemblyKeyFile("C:\\Keys\\AssemblyKey2.snk")]
namespace Assembly2
{
    public class AssemblyClass2
    {
        public static void openPage()
        {
            Process.Start("www.odu.edu");
        }
    }
}
