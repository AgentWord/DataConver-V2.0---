using System;
using System.Collections.Generic;
using System.Linq;

namespace DataConver
{
    public class mycontext : SplashScreenApplicationContext
    {

        protected override void OnCreateSplashScreenForm()
        {

            this.SplashScreenForm = new FormStart();//�������� 

        }



        protected override void OnCreateMainForm()
        {

            this.PrimaryForm = new MainForm();//������ 

        }



        protected override void SetSeconds()
        {

            this.SecondsShow = 2;//����������ʾ��ʱ��(��) 

        }

    }
}
