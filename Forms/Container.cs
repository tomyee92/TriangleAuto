using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using TriangleAuto.Model;
using TriangleAuto.Utils;

namespace TriangleAuto.Forms
{
    public partial class Container : Form, IObserver
    {

        private Subject subject = new Subject();
        private string currentProfile;
        public Container()
        {
            this.subject.Attach(this);

            InitializeComponent();
            this.Text = AppConfig.Name + " - " + AppConfig.Version; // Window title

            //Container Configuration
            this.IsMdiContainer = true;
            SetBackGroundColorOfMDIForm();

            //Paint Children Forms 
            SetToggleApplicationStateWindow();
            SetAutopotWindow();
            SetAutopotYggWindow();
            SetSkillTimerWindow();
            SetAutoStatusEffectWindow();
            SetAHKWindow();
            SetProfileWindow();
            SetAutobuffStuffWindow();
            SetAutobuffSkillWindow();
            SetSongMacroWindow();
            SetATKDEFWindow();
            SetMacroSwitchWindow();
            SetServerWindow();
            SetAdvertisementWindow();

            TrackerSingleton.Instance().SendEvent("desktop_login", "page_view", "desktop_container_load");
        }

        public void addform(TabPage tp, Form f)
        {

            if (!tp.Controls.Contains(f))
            {
                tp.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Show();
                Refresh();
            }
            Refresh();
        }

        private void SetBackGroundColorOfMDIForm()
        {
            foreach (Control ctl in this.Controls)
            {
                if ((ctl) is MdiClient)
                {
                    ctl.BackColor = Color.White;
                }

            }
        }

        private void refreshProcessList()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.processCB.Items.Clear();
            });
            
            // Add all likely RO processes first
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle != "" && IsLikelyROProcess(p))
                {
                    this.processCB.Items.Add(string.Format("{0}.exe - {1}", p.ProcessName, p.Id));
                }
            }
            
            // If no RO processes found, add a separator and show more processes
            if (this.processCB.Items.Count == 0)
            {
                this.processCB.Items.Add("--- No RO Clients Detected ---");
                this.processCB.Items.Add("--- Showing All Processes with Windows ---");
                
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.MainWindowTitle != "" && !IsCommonNonROProcess(p.ProcessName))
                    {
                        this.processCB.Items.Add(string.Format("{0}.exe - {1}", p.ProcessName, p.Id));
                    }
                }
            }
        }

        // Helper method to identify likely RO processes
        private bool IsLikelyROProcess(Process process)
        {
            string processName = process.ProcessName.ToLower();
            string windowTitle = process.MainWindowTitle.ToLower();
            
            // More specific patterns for RO client executables
            string[] roProcessPatterns = {
                "ragnarok", "gravity", "jogar", "cliente", "ragna", "ragexe", 
                "rtales", "client", "launcher", "patcher", "gamestart",
                "ro_", "_ro", "roexe", "ragnarotk", "tales"
            };
            
            // Specific window title patterns for RO
            string[] roWindowPatterns = {
                "ragnarok", "gravity", "prontera", "midgard", "asgard", 
                "alfheim", "valhalla", "rune", "renewal", "classic",
                "tales", "online", "server", "episode"
            };
            
            // Check process name for specific RO patterns
            foreach (string pattern in roProcessPatterns)
            {
                if (processName.Contains(pattern))
                {
                    return true;
                }
            }
            
            // Check window title for RO-specific patterns (more restrictive)
            foreach (string pattern in roWindowPatterns)
            {
                if (windowTitle.Contains(pattern))
                {
                    // Additional check: if window title contains RO terms, 
                    // make sure it's not a common browser or other application
                    if (!IsCommonNonROProcess(processName))
                    {
                        return true;
                    }
                }
            }
            
            // Also include any process from the legacy supported list for backward compatibility
            return ClientListSingleton.ExistsByProcessName(process.ProcessName);
        }

        // Helper method to exclude common non-RO processes
        private bool IsCommonNonROProcess(string processName)
        {
            string[] nonROProcesses = {
                "chrome", "firefox", "safari", "edge", "msedge", "iexplore",
                "notepad", "explorer", "winword", "excel", "outlook", "teams",
                "discord", "steam", "spotify", "vlc", "photoshop", "skype"
            };
            
            foreach (string nonRO in nonROProcesses)
            {
                if (processName.Contains(nonRO))
                {
                    return true;
                }
            }
            
            return false;
        }

        private void processCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.processCB.SelectedItem == null)
                return;
                
            string selectedProcess = this.processCB.SelectedItem.ToString();
            
            // Skip separator items
            if (selectedProcess.StartsWith("---"))
            {
                return;
            }
            
            string rawProcessName = selectedProcess.Split(new string[] { ".exe - " }, StringSplitOptions.None)[0];
            int choosenPID = int.Parse(selectedProcess.Split(new string[] { ".exe - " }, StringSplitOptions.None)[1]);

            // Find the actual process
            Process targetProcess = null;
            foreach (Process process in Process.GetProcessesByName(rawProcessName))
            {
                if (choosenPID == process.Id)
                {
                    targetProcess = process;
                    break;
                }
            }

            if (targetProcess != null)
            {
                // First try to create client using existing supported server data
                try
                {
                    Client client = new Client(selectedProcess);
                    
                    // Check if the client was properly configured (has valid addresses)
                    if (client.currentHPBaseAddress > 0 && client.currentNameAddress > 0)
                    {
                        ClientSingleton.Instance(client);
                        characterName.Text = client.ReadCharacterName();
                        subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                        return;
                    }
                    else
                    {
                        // Client was created but addresses are 0 (not supported), skip to manual config
                        throw new Exception("Client not in supported list");
                    }
                }
                catch
                {
                    // If failed, show manual configuration dialog automatically
                    ShowManualConfigurationDialog(selectedProcess);
                }
            }
        }

        private void ShowManualConfigurationDialog(string processName)
        {
            ManualClientConfigForm configForm = new ManualClientConfigForm(processName, subject);
            configForm.ShowDialog(this);
        }

        private void Container_Load(object sender, EventArgs e)
        {
            ProfileSingleton.Create("Default");
            this.refreshProcessList();
            this.refreshProfileList();
            this.profileCB.SelectedItem = "Default";
        }

        public void refreshProfileList()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.profileCB.Items.Clear();
            });
            foreach (string p in Profile.ListAll())
            {
                this.profileCB.Items.Add(p);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.refreshProcessList();
        }

        private void btnManualConfig_Click(object sender, EventArgs e)
        {
            if (this.processCB.SelectedItem != null)
            {
                string selectedProcess = this.processCB.SelectedItem.ToString();
                
                // Skip separator items
                if (selectedProcess.StartsWith("---"))
                {
                    MessageBox.Show("Please select a valid process first.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                ShowManualConfigurationDialog(selectedProcess);
            }
            else
            {
                MessageBox.Show("Please select a process first.", "No Process Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                this.processCB.Items.Clear();
            });
            
            // Show all processes with windows (for debugging/troubleshooting)
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle != "")
                {
                    this.processCB.Items.Add(string.Format("{0}.exe - {1}", p.ProcessName, p.Id));
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            ShutdownApplication();
            base.OnClosed(e);
        }

        private void ShutdownApplication()
        {
            KeyboardHook.Disable();
            subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
            Environment.Exit(0);
        }

        private void lblLinkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.GithubLink);
        }

        private void lblLinkDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.DiscordLink);
        }

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(AppConfig.Website);
        }

        private void profileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.profileCB.Text != currentProfile)
            {
                try
                {
                    ProfileSingleton.Load(this.profileCB.Text); //LOAD PROFILE
                    subject.Notify(new Utils.Message(MessageCode.PROFILE_CHANGED, null));
                    currentProfile = this.profileCB.Text.ToString();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.TURN_ON: 
                case MessageCode.PROFILE_CHANGED:
                case MessageCode.PROCESS_CHANGED:
                    Client client = ClientSingleton.GetClient();
                    if (client != null)
                    {
                        try
                        {
                            string charName = client.ReadCharacterName();
                            if (!string.IsNullOrEmpty(charName) && charName.Trim() != "" && !charName.Contains("\0"))
                            {
                                characterName.Text = charName;
                            }
                            else
                            {
                                characterName.Text = "Connected (Name not readable)";
                            }
                            
                            // Try to read HP values for debugging
                            try
                            {
                                uint currentHP = client.ReadCurrentHp();
                                uint maxHP = client.ReadMaxHp();
                                hpValue.Text = $"{currentHP}/{maxHP}";
                            }
                            catch
                            {
                                hpValue.Text = "HP read error";
                            }
                        }
                        catch
                        {
                            characterName.Text = "Connected (Memory read error)";
                            hpValue.Text = "- -";
                        }
                    }
                    else
                    {
                        characterName.Text = "- -";
                        hpValue.Text = "- -";
                    }
                    break;
                case MessageCode.SERVER_LIST_CHANGED:
                    this.refreshProcessList();
                    break;
                case MessageCode.CLICK_ICON_TRAY:
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
                case MessageCode.SHUTDOWN_APPLICATION:
                    this.ShutdownApplication();
                    break;
            }
        }

        private void containerResize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Hide(); }
        }

        #region Frames

        public void SetToggleApplicationStateWindow()
        {
            ToggleApplicationStateForm frm = new ToggleApplicationStateForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(350, 70);
            frm.MdiParent = this;
            frm.Show();
        }

        public void SetAdvertisementWindow()
        {
            AdvertisementForm frm = new AdvertisementForm();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            this.panelAdvertisement.Controls.Add(frm);
            frm.Show();
        }

        public void SetAutopotWindow()
        {
            AutopotForm frm = new AutopotForm(subject, false);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutopot, frm);
        }
        public void SetAutopotYggWindow()
        {
            AutopotForm frm = new AutopotForm(subject, true);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageYggAutopot, frm);
        }

        public void SetSkillTimerWindow()
        {
            SkillTimerForm frm = new SkillTimerForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageSkillTimer, frm);

        }
        public void SetAutoStatusEffectWindow()
        {
            StatusEffectForm form = new StatusEffectForm(subject);
            form.FormBorderStyle = FormBorderStyle.None;
            form.Location = new Point(20, 220);
            form.MdiParent = this;
            form.Show();
        }

        public void SetAHKWindow()
        {
            AHKForm frm = new AHKForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageSpammer, frm);
        }

        public void SetProfileWindow()
        {
            ProfileForm frm = new ProfileForm(this);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageProfiles, frm);
        }

        public void SetServerWindow()
        {
            ServersForm frm = new ServersForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageServer, frm);
        }

        public void SetAutobuffStuffWindow()
        {
            StuffAutoBuffForm frm = new StuffAutoBuffForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            frm.Show();
            addform(this.tabPageAutobuffStuff, frm);
        }

        public void SetAutobuffSkillWindow()
        {
            SkillAutoBuffForm frm = new SkillAutoBuffForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabPageAutobuffSkill, frm);
            frm.Show();
        }

        public void SetSongMacroWindow()
        {
            MacroSongForm frm = new MacroSongForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabPageMacroSongs, frm);
            frm.Show();
        }

        public void SetATKDEFWindow()
        {
            ATKDEFForm frm = new ATKDEFForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.atkDef, frm);
            frm.Show();
        }

        public void SetMacroSwitchWindow()
        {
            MacroSwitchForm frm = new MacroSwitchForm(subject);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(0, 65);
            frm.MdiParent = this;
            addform(this.tabMacroSwitch, frm);
            frm.Show();
        }

        #endregion
    }
}
