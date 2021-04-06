using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace CTechCore.Tools
{

    public class cLog : System.Diagnostics.EventLog
    {

        [Flags]
        private enum EventExportLogFlags
        {
            ChannelPath = 1,
            LogFilePath = 2,
            TolerateQueryErrors = 0x1000
        }

        public string LogFilePath
        {
            get
            {
                System.Diagnostics.EventLog log = System.Diagnostics.EventLog.GetEventLogs().Where(x => x.LogDisplayName == this.LogDisplayName).Select(x => x).First();

                RegistryKey regEventLog = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Services\\EventLog\\" + log.LogDisplayName);
                if (regEventLog != null)
                {
                    Object temp = regEventLog.GetValue("File");
                    return temp.ToString();
                }

                return string.Empty;
            }
        }

        public cLog()
        {
            if (!System.Diagnostics.EventLog.SourceExists(this.LogName))
            {
                //PJC dont log cuase user does not have permission to create eventlog
                System.Diagnostics.EventLog.CreateEventSource(this.LogName, this.LogName);
            }
            this.Source = this.LogName;
            this.Log = this.LogName;
        }

        public string LogName
        {
            get { return MyApp.Name + "Log"; }
        }



        [System.Runtime.InteropServices.DllImport("advapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        static extern IntPtr OpenEventLog(string UNCServerName, string sourceName);

        [System.Runtime.InteropServices.DllImport("advapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        static extern bool BackupEventLog(IntPtr hEventLog, string backupFile);

        [System.Runtime.InteropServices.DllImport("advapi32.dll", SetLastError = true)]
        static extern bool CloseEventLog(IntPtr hEventLog);

        public string Export()
        {
            string expPath = string.Empty;
            try
            {
                expPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.LogName + "_" + MyApp.ComputerName + ".evtx";

                if (System.IO.File.Exists(expPath)) System.IO.File.Delete(expPath);


                string exportedEventLogFileName = Path.Combine(System.IO.Path.GetDirectoryName(expPath), System.IO.Path.GetFileName(expPath));

                IntPtr logHandle = OpenEventLog(Environment.MachineName, this.LogDisplayName);

                if (IntPtr.Zero != logHandle)
                {
                    bool retValue = BackupEventLog(logHandle, exportedEventLogFileName);
                    //If false, notify.
                    CloseEventLog(logHandle);
                    return expPath;
                }
                return string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.WriteEntry("Error Writing Log File: " + expPath + "\n" + ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                return string.Empty;
            }

        }



    }
}
