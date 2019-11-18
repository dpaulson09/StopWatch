﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ApplicationUpdate; // Application Updater to allow the program to update automatically https://github.com/dpaulson45/ApplicationUpdate/releases 
using System.Reflection;

using StopWatch.Data;
using StopWatch.TimeTracker;

namespace StopWatch
{
    public partial class StopWatch : Form, IApplicationUpdate
    {

        private List<StopWatchManager> stopWatches;
        private StopWatchManager adminTimer;
        private ApplicationUpdater appUpdater;
        private BackgroundWorker bgWorker;
        private string primarySaveDirectory;
        private string xmlUserSettingsLocation;
        private XmlUserSettings xmlUserSettings;
        private StopWatchUserSettings stopWatchUserSettings;

        private const bool DefaultDatabaseCommitOption = true;
        private const int DefaultStopWatchInstances = 5;
        private const bool DefaultIncludeMicroseconds = true;

        private const int startingYLocation = 100;
        private const int yPadding = 35;

#if DEBUG
        private string AppName_AppID = "StopWatch-Dev";
#else
      private string AppName_AppID = "StopWatch";
#endif



        public StopWatch()
        {
            InitializeComponent();
            primarySaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppName_AppID;

            if (!System.IO.Directory.Exists(primarySaveDirectory))
                System.IO.Directory.CreateDirectory(primarySaveDirectory);

            xmlUserSettingsLocation = primarySaveDirectory + "\\UserSettings.xml";
            stopWatchUserSettings = new StopWatchUserSettings();
            xmlUserSettings = new XmlUserSettings(xmlUserSettingsLocation,
                stopWatchUserSettings);

            LoadUserPreferences();

            stopWatches = new List<StopWatchManager>();
            for (int i = 1; i <= stopWatchUserSettings.StopWatchInstances; i++)
            {
                stopWatches.Add(new StopWatchManager("StopWatch" + i,
                    primarySaveDirectory,
                    (startingYLocation + ((i - 1) * yPadding)),
                    this,
                    lblMainDisplay,
                    stopWatchUserSettings.IncludeMicroseconds,
                    stopWatchUserSettings.DatabaseCommitOption,
                    btnStartStop_Click,
                    btnReset_Click));
            }

            adminTimer = new StopWatchManager("AdminStopWatch",
                primarySaveDirectory,
                lblAdminTimer,
                stopWatchUserSettings.IncludeMicroseconds);

            string adminStartTimeLocation = primarySaveDirectory + "\\AdminStartTime.dat";
            if (!System.IO.File.Exists(adminStartTimeLocation))
            {
                System.IO.FileStream fs = System.IO.File.Create(adminStartTimeLocation);
                fs.Close();
            }
            System.IO.TextReader textReader = new System.IO.StreamReader(adminStartTimeLocation);
            try
            {
                if (DateTime.Now.Date != (Convert.ToDateTime(textReader.ReadLine())).Date)
                {
                    adminTimer.stopWatch.Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                textReader.Close();
            }
            System.IO.TextWriter textWriter = new System.IO.StreamWriter(adminStartTimeLocation);
            try
            {
                textWriter.WriteLine(Convert.ToString(DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                textWriter.Close();
            }

            adminTimer.stopWatch.StartStop();

            appUpdater = new ApplicationUpdater(this);
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
            bgWorker.RunWorkerAsync();
            lblUpdate.Text = "Checking for updates....";

        }

        private void LoadUserPreferences()
        {
            if (!System.IO.File.Exists(xmlUserSettingsLocation))
            {
                stopWatchUserSettings.DatabaseCommitOption = DefaultDatabaseCommitOption;
                stopWatchUserSettings.IncludeMicroseconds = DefaultIncludeMicroseconds;
                stopWatchUserSettings.StopWatchInstances = DefaultStopWatchInstances;
                SaveUserPreferences();
            }
            else
            {
                stopWatchUserSettings = xmlUserSettings.ReadFromFile() as StopWatchUserSettings;
            }
        }

        private void SaveUserPreferences()
        {
            xmlUserSettings.SaveToFile(stopWatchUserSettings);
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (appUpdater.NewUpdate())
                lblUpdate.Text = "New Update Available";
            else
                lblUpdate.Text = " ";

        }
        
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(10000); 
        }


        protected void btnStartStop_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;

            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if(stopWatch.stopWatch.displayUpdateTimer.Enabled)
                {
                    //This is for when a user selects a Start/Stop button that isn't currently active.
                    if(btnSender.Name !=(stopWatch.stopWatchSetName + "_Start"))
                    {
                        stopWatch.stopWatch.StartStop();
                        stopWatch.SetStartButton();
                    }
                }
            }

            startStopAdminTimer();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            bool timerIsRunning = false;
            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if(stopWatch.stopWatch.displayUpdateTimer.Enabled)
                {
                    timerIsRunning = true;
                    break; 
                }
            }
            if(!timerIsRunning)
            {
                lblMainDisplay.Text = "00:00:00";
            }
        }


        public string ApplicationName
        {
            get {return AppName_AppID; }
        }

        public string ApplicationID
        {
            get { return AppName_AppID;  }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return Icon; }
        }

        public Form ApplicationForm
        {
            get { return this;  }
        }

        public Uri ApplicationUpdaterXmlLocation
        {
            get { return new Uri("https://raw.githubusercontent.com/dpaulson45/StopWatch/UpdateFileBranch/update.xml");  }
        }


        private void downloadUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            appUpdater.DoUpdate();
        }

        private void toggleAdminEnabledWording(bool enabled)
        {
            if(enabled)
                enableTimerToolStripMenuItem.Text = "Disable Timer";
            else
                enableTimerToolStripMenuItem.Text = "Enable Timer";
        }

        private void startStopAdminTimer()
        {
            bool stopWatchInstanceRunning = false;
            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if (stopWatch.stopWatch.displayUpdateTimer.Enabled)
                {
                    stopWatchInstanceRunning = true;
                    break;
                }
            }
            if (stopWatchInstanceRunning)
            {
                if (adminTimer.stopWatch.displayUpdateTimer.Enabled)
                {
                    adminTimer.stopWatch.StartStop();
                }
            }
            else
            {
                if (!adminTimer.stopWatch.displayUpdateTimer.Enabled)
                {
                    adminTimer.stopWatch.StartStop();
                }
            }
            toggleAdminEnabledWording(true);
        }


        private void enableTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool stopWatchInstanceRunning = false; 
            foreach (StopWatchManager stopWatch in stopWatches)
            {
                if(stopWatch.stopWatch.displayUpdateTimer.Enabled)
                {
                    stopWatchInstanceRunning = true;
                    break; 
                }
            }
            if(!stopWatchInstanceRunning)
            {
                toggleAdminEnabledWording(!adminTimer.stopWatch.displayUpdateTimer.Enabled);
                adminTimer.stopWatch.StartStop();
            }
            else
            {
                toggleAdminEnabledWording(true);
            }
        }

        private void resetTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(adminTimer.stopWatch.displayUpdateTimer.Enabled)
            {
                adminTimer.stopWatch.Restart();
            }
            else
            {
                adminTimer.stopWatch.Reset();
                lblAdminTimer.Text = adminTimer.stopWatch.GetTime;
            }
        }

        private void CommitAdminTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertForm test = new InsertForm(primarySaveDirectory,
                adminTimer.stopWatch.GetTotalMinutes);
            test.Show();
        }
    }
}
