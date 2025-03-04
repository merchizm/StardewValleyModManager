using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StardewValleyModManager
{
    public partial class Form1 : Form
    {
        private string modsDirectory;
        private string deactivatedModsDirectory;
        private string gameDirectory;
        private List<ModInfo> activeMods = new List<ModInfo>();
        private List<ModInfo> deactivatedMods = new List<ModInfo>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Stardew Valley Mod Manager";
            
            // Set the directories to the current application directory by default
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            modsDirectory = Path.Combine(baseDirectory, "Mods");
            deactivatedModsDirectory = Path.Combine(baseDirectory, "DeactivatedMods");
            gameDirectory = baseDirectory;
            
            // Create directories if they don't exist
            EnsureDirectoriesExist();
            
            // Load mods on startup
            LoadMods();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up the links in the resources panel
            SetupResourceLinks();
        }

        private void SetupResourceLinks()
        {
            // Clear existing links
            flowResourceLinks.Controls.Clear();
            
            // Add links to resources
            AddResourceLink("Stardew Valley Wiki", "https://stardewvalleywiki.com/");
            AddResourceLink("Nexus Mods", "https://www.nexusmods.com/stardewvalley");
            AddResourceLink("SMAPI Documentation", "https://stardewvalleywiki.com/Modding:Index");
            AddResourceLink("Stardew Valley Forums", "https://forums.stardewvalley.net/");
            AddResourceLink("Stardew Valley Discord", "https://discord.gg/stardewvalley");
        }

        private void AddResourceLink(string text, string url)
        {
            LinkLabel link = new LinkLabel();
            link.Text = text;
            link.AutoSize = true;
            link.Margin = new Padding(3, 5, 3, 5);
            link.LinkClicked += (sender, e) => Process.Start(url);
            flowResourceLinks.Controls.Add(link);
        }

        private void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(modsDirectory))
            {
                Directory.CreateDirectory(modsDirectory);
            }

            if (!Directory.Exists(deactivatedModsDirectory))
            {
                Directory.CreateDirectory(deactivatedModsDirectory);
            }
        }

        private void LoadMods()
        {
            // Clear existing lists
            activeMods.Clear();
            deactivatedMods.Clear();
            
            // Load active mods
            if (Directory.Exists(modsDirectory))
            {
                foreach (string modFolder in Directory.GetDirectories(modsDirectory))
                {
                    string modName = new DirectoryInfo(modFolder).Name;
                    string manifestPath = Path.Combine(modFolder, "manifest.json");
                    bool hasManifest = File.Exists(manifestPath);
                    
                    activeMods.Add(new ModInfo
                    {
                        Name = modName,
                        Path = modFolder,
                        IsValid = hasManifest
                    });
                }
            }
            
            // Load deactivated mods
            if (Directory.Exists(deactivatedModsDirectory))
            {
                foreach (string modFolder in Directory.GetDirectories(deactivatedModsDirectory))
                {
                    string modName = new DirectoryInfo(modFolder).Name;
                    string manifestPath = Path.Combine(modFolder, "manifest.json");
                    bool hasManifest = File.Exists(manifestPath);
                    
                    deactivatedMods.Add(new ModInfo
                    {
                        Name = modName,
                        Path = modFolder,
                        IsValid = hasManifest
                    });
                }
            }
            
            // Update the UI
            UpdateModLists();
            
            // Check if SMAPI exists
            CheckSmapiExists();
        }

        private void CheckSmapiExists()
        {
            string smapiPath = Path.Combine(gameDirectory, "StardewModdingAPI.exe");
            btnLaunchGame.Enabled = File.Exists(smapiPath);
            
            if (!btnLaunchGame.Enabled)
            {
                lblStatus.Text = "StardewModdingAPI.exe not found. Please browse to the Stardew Valley directory.";
            }
        }

        private void UpdateModLists()
        {
            // Update active mods list
            listActiveModsView.Items.Clear();
            foreach (ModInfo mod in activeMods)
            {
                ListViewItem item = new ListViewItem(mod.Name);
                item.SubItems.Add(mod.IsValid ? "Valid" : "Invalid");
                item.Tag = mod;
                
                // Set color based on validity
                if (!mod.IsValid)
                {
                    item.ForeColor = Color.Red;
                }
                
                listActiveModsView.Items.Add(item);
            }
            
            // Update deactivated mods list
            listDeactivatedModsView.Items.Clear();
            foreach (ModInfo mod in deactivatedMods)
            {
                ListViewItem item = new ListViewItem(mod.Name);
                item.SubItems.Add(mod.IsValid ? "Valid" : "Invalid");
                item.Tag = mod;
                
                // Set color based on validity
                if (!mod.IsValid)
                {
                    item.ForeColor = Color.Red;
                }
                
                listDeactivatedModsView.Items.Add(item);
            }
            
            // Update status label
            if (btnLaunchGame.Enabled)
            {
                lblStatus.Text = $"Active Mods: {activeMods.Count} | Deactivated Mods: {deactivatedMods.Count}";
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (listActiveModsView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listActiveModsView.SelectedItems)
                {
                    ModInfo mod = (ModInfo)item.Tag;
                    string destPath = Path.Combine(deactivatedModsDirectory, new DirectoryInfo(mod.Path).Name);
                    
                    try
                    {
                        // Move the directory
                        Directory.Move(mod.Path, destPath);
                        
                        // Update the mod info
                        mod.Path = destPath;
                        
                        // Move from active to deactivated list
                        activeMods.Remove(mod);
                        deactivatedMods.Add(mod);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deactivating mod {mod.Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                // Refresh the lists
                UpdateModLists();
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (listDeactivatedModsView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listDeactivatedModsView.SelectedItems)
                {
                    ModInfo mod = (ModInfo)item.Tag;
                    string destPath = Path.Combine(modsDirectory, new DirectoryInfo(mod.Path).Name);
                    
                    try
                    {
                        // Move the directory
                        Directory.Move(mod.Path, destPath);
                        
                        // Update the mod info
                        mod.Path = destPath;
                        
                        // Move from deactivated to active list
                        deactivatedMods.Remove(mod);
                        activeMods.Add(mod);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error activating mod {mod.Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                // Refresh the lists
                UpdateModLists();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMods();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Stardew Valley Game Directory";
                dialog.ShowNewFolderButton = false;
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    string potentialModsPath = Path.Combine(selectedPath, "Mods");
                    string smapiPath = Path.Combine(selectedPath, "StardewModdingAPI.exe");
                    
                    if (File.Exists(smapiPath))
                    {
                        gameDirectory = selectedPath;
                        modsDirectory = potentialModsPath;
                        deactivatedModsDirectory = Path.Combine(selectedPath, "DeactivatedMods");
                        
                        // Ensure the directories exist
                        EnsureDirectoriesExist();
                        
                        txtModsPath.Text = modsDirectory;
                        LoadMods();
                    }
                    else
                    {
                        MessageBox.Show("The selected directory does not contain StardewModdingAPI.exe. Please select the Stardew Valley game directory.", 
                            "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnOpenModFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(modsDirectory))
            {
                Process.Start("explorer.exe", modsDirectory);
            }
        }

        private void btnOpenDeactivatedFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(deactivatedModsDirectory))
            {
                Process.Start("explorer.exe", deactivatedModsDirectory);
            }
        }

        private void btnLaunchGame_Click(object sender, EventArgs e)
        {
            string smapiPath = Path.Combine(gameDirectory, "StardewModdingAPI.exe");
            
            if (File.Exists(smapiPath))
            {
                try
                {
                    Process.Start(smapiPath);
                    lblStatus.Text = "Game launched successfully!";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error launching game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("StardewModdingAPI.exe not found. Please browse to the correct Stardew Valley directory.", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLaunchGame.Enabled = false;
            }
        }
    }

    public class ModInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsValid { get; set; }
    }
}
