using System;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.ExpressApp.Security;

namespace E968.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if EASYTEST
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            E968WindowsFormsApplication winApplication = new E968WindowsFormsApplication();
#if EASYTEST
			if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            //DevExpress.ExpressApp.InMemoryDataStoreProvider.Register();
            //winApplication.ConnectionString = DevExpress.ExpressApp.InMemoryDataStoreProvider.ConnectionString;
            try {
                // Uncomment this line when using the Middle Tier application server:
                // new DevExpress.ExpressApp.MiddleTier.MiddleTierClientApplicationConfigurator(winApplication);
                winApplication.Setup();
                winApplication.Start();
            } catch (Exception e) {
                winApplication.HandleException(e);
            }
        }
    }
}
