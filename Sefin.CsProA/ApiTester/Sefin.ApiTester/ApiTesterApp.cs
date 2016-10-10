using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sefin.ApiTester
{
    public partial class ApiTesterApp : Form
    {
        private AppStatus _currentStatus;

        public ApiTesterApp()
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            InitApp();

            Trace.WriteLine("Ready...");
        }

        private void InitApp()
        {
            SetStatus(AppStatus.NotReady);

            AppContext.Instance.TraceListener.Logger = msg => this.TxtLog.AppendText(msg);
            Trace.Listeners.Add(AppContext.Instance.TraceListener);
            AppContext.Instance.Runner.Init();

            var methods = AppContext.Instance.Runner.Methods
                                        .OrderBy(m => m.Method.DeclaringType.Name)
                                        .ThenBy(m => m.Label);
            foreach (var method in methods) CmbMethods.Items.Add(method);

            if (CmbMethods.Items.Count > 0)
            {
                for (int i = 0; i < CmbMethods.Items.Count; i++) {
                    if (CmbMethods.Items[i].ToString() == Properties.Settings.Default.LastMethod) {
                        CmbMethods.SelectedIndex = i;
                        break;
                    }
                }

                if (CmbMethods.SelectedItem == null)
                        CmbMethods.SelectedIndex = 0;
                SetStatus(AppStatus.Wait);
            }

        }

        private void SetStatus(AppStatus status)
        {
            _currentStatus = status;
            if (status == AppStatus.NotReady) {
                BtnExecute.Enabled = false;
            }

            if (status == AppStatus.Wait)
            {
                BtnExecute.Enabled = true;
            }

            if (status == AppStatus.Running)
            {
                BtnExecute.Enabled = false;
            }

            BtnLoadDll.Enabled = false;
        }

        private void BtnLoadDll_Click(object sender, EventArgs e)
        {
            //Trace.Write("Load dll");
        }

        private void BtnClearLogs_Click(object sender, EventArgs e)
        {
            CleatLogs();
        }

        private void CleatLogs()
        {
            TxtLog.Text = String.Empty;
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            var method = CmbMethods.SelectedItem as RunnableMethod;
            if (method == null) return;
            SetStatus(AppStatus.Running);
            if (ChkClearLogs.Checked) CleatLogs();
            TablOutput.SelectTab(TabLog);
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem(_ => {
                    try
                    {
                        Properties.Settings.Default.LastMethod = method.Label;
                        Properties.Settings.Default.Save();

                        method.Execute();
                    }
                    catch (Exception ex)
                    {
                        Trace.Write("Error starting method " + CmbMethods.SelectedText);
                        Trace.WriteLine(ex.ToString());
                    }
                    finally {
                        SetStatus(AppStatus.Wait);
                    }
                },null);
            }
            catch (Exception ex) {
                Trace.Write("Error starting method " + CmbMethods.SelectedText);
                Trace.WriteLine(ex.ToString());
                SetStatus(AppStatus.Wait);
            }
        }

        public enum AppStatus {
            NotReady,
            Wait,
            Running,
        }
    }
}
