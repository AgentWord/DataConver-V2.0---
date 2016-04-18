using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace DataConver
{
    public abstract class SplashScreenApplicationContext : ApplicationContext
    {

        private Form _SplashScreenForm;//�������� 

        private Form _PrimaryForm;//������ 

        private System.Timers.Timer _SplashScreenTimer;

        private int _SplashScreenTimerInterVal = 5000;//Ĭ��������������ʾ5�� 

        private bool _bSplashScreenClosed = false;
        private delegate void DisposeDelegate();
        public SplashScreenApplicationContext()
        {

            this.ShowSplashScreen();//���ﴴ������ʾ�������� 

            this.MainFormLoad();//���ﴴ������ʾ���������� 

        }
        protected abstract void OnCreateSplashScreenForm();
        protected abstract void OnCreateMainForm();
        protected abstract void SetSeconds();
        protected Form SplashScreenForm
        {
            set
            {

                this._SplashScreenForm = value;

            }

        }
        protected Form PrimaryForm
        {
            set
            {

                this._PrimaryForm = value;

            }
        }
        protected int SecondsShow
        {
            set
            {

                if (value != 0)
                {

                    this._SplashScreenTimerInterVal = 1000 * value;

                }

            }
        }

        private void ShowSplashScreen()
        {

            this.SetSeconds();

            this.OnCreateSplashScreenForm();

            this._SplashScreenTimer = new System.Timers.Timer(((double)(this._SplashScreenTimerInterVal)));

            _SplashScreenTimer.Elapsed += new System.Timers.ElapsedEventHandler(new System.Timers.ElapsedEventHandler(this.SplashScreenDisplayTimeUp));



            this._SplashScreenTimer.AutoReset = false;

            Thread DisplaySpashScreenThread = new Thread(new ThreadStart(DisplaySplashScreen));



            DisplaySpashScreenThread.Start();

        }
        private void DisplaySplashScreen()
        {

            this._SplashScreenTimer.Enabled = true;

            Application.Run(this._SplashScreenForm);

        }
        private void SplashScreenDisplayTimeUp(object sender, System.Timers.ElapsedEventArgs e)
        {

            this._SplashScreenTimer.Dispose();

            this._SplashScreenTimer = null;

            this._bSplashScreenClosed = true;

        }
        private void MainFormLoad()
        {

            this.OnCreateMainForm();



            while (!(this._bSplashScreenClosed))
            {

                Application.DoEvents();

            }


            DisposeDelegate SplashScreenFormDisposeDelegate = new DisposeDelegate(this._SplashScreenForm.Dispose);

            this._SplashScreenForm.Invoke(SplashScreenFormDisposeDelegate);

            this._SplashScreenForm = null;

            //��������ʾ���ټ�����������岻��������������ʧ����� 

            this._PrimaryForm.Show();

            this._PrimaryForm.Activate();



            this._PrimaryForm.Closed += new EventHandler(_PrimaryForm_Closed);
        }
        private void _PrimaryForm_Closed(object sender, EventArgs e)
        {

            base.ExitThread();

        }
    }
}
