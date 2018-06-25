using System;
using Xwt.Common;

namespace Xwt.Windows
{    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            XwtApp.Run(ToolkitType.Wpf);
        }
    }
}
