using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Projas.Service.Helper;
namespace Projas.WinServices
{
    public partial class ProjasServices : ServiceBase
    {

        private string CurrentProjectName = "Projas-Service";

        public ProjasServices()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.WriteLog(CurrentProjectName, string.Format("Service {0} starting now...", CurrentProjectName));
            timerRunJob.Interval = 60000;//1 menit
            timerRunJob.Enabled = true;
        }

        protected override void OnStop()
        {
            Log.WriteLog(CurrentProjectName, string.Format("Service {0} stopping now...", CurrentProjectName));
            timerRunJob.Enabled = false;
        }

        private void timerRunJob_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerRunJob.Enabled = false;

            Log.WriteLog(CurrentProjectName, "Start run services.");
            try
            {
                APIHelper.GetApiData();
                ReadWriteTextFile.ExportKotaToDB("DaftarKota.txt");
                ReadWriteTextFile.ExportJadwalKotaToDB();

            }
            catch (Exception ex)
            {
                Log.WriteLog(CurrentProjectName, $"Error  {ex.Message}");
            }
            finally
            {
                timerRunJob.Enabled = false;
            }


            Log.WriteLog(CurrentProjectName, "End run services.");
        }

    }
}
