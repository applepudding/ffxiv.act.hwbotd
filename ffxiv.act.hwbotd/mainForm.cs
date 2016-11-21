using System;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Xml;

namespace ffxiv.act.hwbotd
{
    public partial class mainForm : UserControl, IActPluginV1
    {
        public mainForm()
        {
            InitializeComponent();
        }
        Label lblStatus;    // The status label that appears in ACT's Plugin tab
        string settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\hwbotd.config.xml");
        SettingsSerializer xmlSettings;

        #region variable list
        private static System.Timers.Timer fightTimer;
        TimeSpan botdDuration;
        double botdNext;
        double lag_compensation = 2;

        #endregion

        #region IActPluginV1 Members
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            lblStatus = pluginStatusText;   // Hand the status label's reference to our local var
            pluginScreenSpace.Controls.Add(this);   // Add this UserControl to the tab ACT provides
            this.Dock = DockStyle.Fill; // Expand the UserControl to fill the tab's client space
            xmlSettings = new SettingsSerializer(this); // Create a new settings serializer and pass it this instance
            LoadSettings();
            initBotdPlugin();

            ActGlobals.oFormActMain.AfterCombatAction += new CombatActionDelegate(botd_oFormActMain_AfterCombatAction);

            lblStatus.Text = "Plugin Started";
        }
        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.AfterCombatAction -= botd_oFormActMain_AfterCombatAction;

            SaveSettings();
            disposeBotdPlugin();

            lblStatus.Text = "Plugin Exited";
        }
        #endregion

        void botd_oFormActMain_AfterCombatAction(bool isImport, CombatActionEventArgs actionInfo)
        {

            string skillName = actionInfo.theAttackType.ToLower();
            string skillUser = actionInfo.attacker;
            if (skillUser == "YOU")
            {

                switch (skillName)
                {
                    case "blood of the dragon":
                        botdDuration = new TimeSpan(0, 0, 15);
                        lag_compensation = 2;
                        botdNext = 60;
                        break;
                    case "fang and claw":
                        addBotdDuration();
                        break;
                    case "wheeling thrust":
                        addBotdDuration();
                        break;
                    case "geirskogul":
                        TimeSpan ts = new TimeSpan(0, 0, 10);
                        botdDuration = botdDuration.Subtract(ts);
                        break;
                }
            }
            //throw new NotImplementedException();
        }
        void addBotdDuration()
        {
            TimeSpan ts = new TimeSpan(0, 0, 15);
            botdDuration = botdDuration.Add(ts);
            if ((botdDuration.TotalSeconds > Int32.Parse(this.txt_safeToGS.Text)) || (botdNext < Int32.Parse(this.txt_safeToDrop.Text)))
            {
                ActGlobals.oFormActMain.PlayTtsMethod(this.txt_toSpeak.Text);
            }
            else
            {
                if (botdDuration.TotalSeconds > 30000)
                {
                    botdDuration = new TimeSpan(0, 0, 30);
                }
            }
        }
        void LoadSettings()
        {
            xmlSettings.AddControlSetting(txt_safeToGS.Name, txt_safeToGS);
            xmlSettings.AddControlSetting(txt_toSpeak.Name, txt_toSpeak);
            xmlSettings.AddControlSetting(txt_safeToDrop.Name, txt_safeToDrop);
            xmlSettings.AddControlSetting(txt_timeAccuracy.Name, txt_timeAccuracy);

            if (File.Exists(settingsFile))
            {
                FileStream fs = new FileStream(settingsFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlTextReader xReader = new XmlTextReader(fs);

                try
                {
                    while (xReader.Read())
                    {
                        if (xReader.NodeType == XmlNodeType.Element)
                        {
                            if (xReader.LocalName == "SettingsSerializer")
                            {
                                xmlSettings.ImportFromXml(xReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error loading settings: " + ex.Message;
                }
                xReader.Close();
            }
        }
        void SaveSettings()
        {
            FileStream fs = new FileStream(settingsFile, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter xWriter = new XmlTextWriter(fs, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            xWriter.Indentation = 1;
            xWriter.IndentChar = '\t';
            xWriter.WriteStartDocument(true);
            xWriter.WriteStartElement("Config");    // <Config>
            xWriter.WriteStartElement("SettingsSerializer");    // <Config><SettingsSerializer>
            xmlSettings.ExportToXml(xWriter);   // Fill the SettingsSerializer XML
            xWriter.WriteEndElement();  // </SettingsSerializer>
            xWriter.WriteEndElement();  // </Config>
            xWriter.WriteEndDocument(); // Tie up loose ends (shouldn't be any)
            xWriter.Flush();    // Flush the file buffer to disk
            xWriter.Close();
        }

        void initBotdPlugin()
        {

            //set fight timer
            fightTimer = new System.Timers.Timer(Int32.Parse(txt_timeAccuracy.Text)); // Create a timer with a 1 second interval.
            fightTimer.Elapsed += OnTimedEvent; // Hook up the Elapsed event for the timer. 
            fightTimer.AutoReset = true;
            fightTimer.Enabled = true;

            lbl_activeBuff.Text = "0";
            lbl_GSCooldown.Text = "0";

            //ActPluginData pluginData = ActGlobals.oFormActMain.PluginGetSelfData(this);
            //pluginData.pluginFile.FullName;
        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!InvokeRequired)
            {
                if (lag_compensation > 0)
                {
                    lag_compensation -= Int32.Parse(txt_timeAccuracy.Text) * 0.001;
                    lbl_activeBuff.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbl_activeBuff.ForeColor = System.Drawing.Color.Black;
                }
                if (botdNext > 0)
                {
                    botdNext -= Int32.Parse(txt_timeAccuracy.Text) * 0.001;
                    lbl_GSCooldown.Text = botdNext.ToString("#.#");

                }
                if (botdDuration.TotalSeconds > 0)
                {
                    TimeSpan ts = new TimeSpan(0, 0, 0, 0, Int32.Parse(txt_timeAccuracy.Text));
                    botdDuration = botdDuration.Subtract(ts);
                    lbl_activeBuff.Text = botdDuration.TotalSeconds.ToString();
                }
            }
            else
            {
                Invoke(new Action<Object, System.Timers.ElapsedEventArgs>(OnTimedEvent), source, e);
            }
        }
        
        void disposeBotdPlugin()
        {
            if (fightTimer != null)
            {
                fightTimer.Stop();
                fightTimer.Dispose();
                fightTimer = null;
            }
        } //dispose stuff

        private void txt_timeAccuracy_TextChanged(object sender, EventArgs e)
        {
            fightTimer = new System.Timers.Timer(Int32.Parse(txt_timeAccuracy.Text)); // Create a timer with a 1 second interval.
        }
    }
}
