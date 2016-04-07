using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SuperMapTool;
using System.Threading;

namespace DataConver
{
    public class mycontext : SplashScreenApplicationContext
    {

        protected override void OnCreateSplashScreenForm()
        {

            this.SplashScreenForm = new FormStart();//启动窗体 

        }



        protected override void OnCreateMainForm()
        {

            this.PrimaryForm = new MainForm();//主窗体 

        }



        protected override void SetSeconds()
        {

            this.SecondsShow = 2;//启动窗体显示的时间(秒) 

        }

    }
}
