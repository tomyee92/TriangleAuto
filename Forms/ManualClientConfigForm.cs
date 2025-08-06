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
using TriangleAuto.Model;
using TriangleAuto.Utils;

namespace TriangleAuto.Forms
{
    public partial class ManualClientConfigForm : Form
    {
        private string selectedProcessName;
        private Subject subject;

        public ManualClientConfigForm(string processName, Subject subject)
        {
            InitializeComponent();
            this.selectedProcessName = processName;
            this.subject = subject;
            this.Text = "Manual Client Configuration - " + processName;
            
            // Set default example values
            txtHPAddress.Text = "015D23C8";
            txtNameAddress.Text = "015D5018";
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input addresses
                if (!IsValidHexAddress(txtHPAddress.Text))
                {
                    MessageBox.Show("Invalid HP Address. Please enter a valid 8-character hexadecimal address (e.g., 015D23C8)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidHexAddress(txtNameAddress.Text))
                {
                    MessageBox.Show("Invalid Name Address. Please enter a valid 8-character hexadecimal address (e.g., 015D5018)", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convert hex strings to integers
                int hpAddress = Convert.ToInt32("0x" + txtHPAddress.Text, 16);
                int nameAddress = Convert.ToInt32("0x" + txtNameAddress.Text, 16);

                // Get the actual process
                string rawProcessName = selectedProcessName.Split(new string[] { ".exe - " }, StringSplitOptions.None)[0];
                int choosenPID = int.Parse(selectedProcessName.Split(new string[] { ".exe - " }, StringSplitOptions.None)[1]);

                Process targetProcess = null;
                foreach (Process process in System.Diagnostics.Process.GetProcessesByName(rawProcessName))
                {
                    if (choosenPID == process.Id)
                    {
                        targetProcess = process;
                        break;
                    }
                }

                if (targetProcess == null)
                {
                    MessageBox.Show("Selected process is no longer running.", "Process Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new client with manual addresses using the process directly
                Client manualClient = new Client(targetProcess, hpAddress, nameAddress);
                
                // Set this as the current client
                ClientSingleton.Instance(manualClient);

                // Test if we can read character name
                try
                {
                    string characterName = manualClient.ReadCharacterName();
                    uint currentHP = 0;
                    uint maxHP = 0;
                    
                    // Try to read HP values for additional verification
                    try
                    {
                        currentHP = manualClient.ReadCurrentHp();
                        maxHP = manualClient.ReadMaxHp();
                    }
                    catch
                    {
                        // HP reading failed, but we'll still show the result
                    }
                    
                    if (!string.IsNullOrEmpty(characterName) && characterName.Trim() != "" && !characterName.Contains("\0"))
                    {
                        string message = $"Successfully configured client!\nProcess: {targetProcess.ProcessName} (PID: {targetProcess.Id})\nCharacter Name: {characterName}\nHP Address: 0x{txtHPAddress.Text}\nName Address: 0x{txtNameAddress.Text}";
                        
                        if (currentHP > 0 && maxHP > 0)
                        {
                            message += $"\nCurrent HP: {currentHP}/{maxHP}";
                        }
                        else
                        {
                            message += "\nHP: Could not read (address may be incorrect)";
                        }
                        
                        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Notify that process changed
                        subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Configuration applied but character name could not be read or is invalid. Please verify the addresses are correct.\nSpammer and macro functions will still work.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Still notify about the change so spammer works
                        subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Configuration applied but there was an error reading memory: {ex.Message}\nThe spammer and macro functions will still work.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Still notify about the change so spammer works
                    subject.Notify(new Utils.Message(Utils.MessageCode.PROCESS_CHANGED, null));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error configuring client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidHexAddress(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length != 8)
                return false;

            return address.All(c => "0123456789ABCDEFabcdef".Contains(c));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHPAddress_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Convert to uppercase and limit to 8 characters
            string text = textBox.Text.ToUpper();
            if (text.Length > 8)
                text = text.Substring(0, 8);
            
            // Remove any non-hex characters
            text = new string(text.Where(c => "0123456789ABCDEF".Contains(c)).ToArray());
            
            if (textBox.Text != text)
            {
                int selectionStart = textBox.SelectionStart;
                textBox.Text = text;
                textBox.SelectionStart = Math.Min(selectionStart, text.Length);
            }
        }

        private void txtNameAddress_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Convert to uppercase and limit to 8 characters
            string text = textBox.Text.ToUpper();
            if (text.Length > 8)
                text = text.Substring(0, 8);
            
            // Remove any non-hex characters
            text = new string(text.Where(c => "0123456789ABCDEF".Contains(c)).ToArray());
            
            if (textBox.Text != text)
            {
                int selectionStart = textBox.SelectionStart;
                textBox.Text = text;
                textBox.SelectionStart = Math.Min(selectionStart, text.Length);
            }
        }
    }
}