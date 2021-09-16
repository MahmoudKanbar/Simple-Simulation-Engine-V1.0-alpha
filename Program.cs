using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Scientific_Calculations
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        [STAThread]
        private static void Main()
        {
            AllocConsole();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var simulationMainWindow = new SimulationMainWindow();
            Application.Run(simulationMainWindow);
        }
    }
}