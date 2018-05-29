using CandyStore.Client.Extensions;
using CandyStore.Client.UnityIoC;
using System;
using System.Windows.Forms;
using Unity;

namespace CandyStore.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = SingletonUnity.Instance
                .RegisterForms()
                .RegisterServices()
                .RegisterDbContext();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // TODO: container.Resolve<IMainView> or MainForm and run app
            // note that using Unity must be included for generic container.Resolve to work
            Application.Run(new Main());
        }
    }
}
