using System;
using ViewHandler;

namespace CNAB_Sync
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Class_ViewHandler.Start();
        }
    }
}