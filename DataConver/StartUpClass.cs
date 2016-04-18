using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataConver
{
    public class StartUpClass
    {

        [STAThread]

        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            Application.Run(new mycontext());
        }

    }
}
