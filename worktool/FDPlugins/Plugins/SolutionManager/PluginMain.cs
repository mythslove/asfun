using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using WeifenLuo.WinFormsUI.Docking;
using SolutionManager.Resources;
using PluginCore.Localization;
using PluginCore.Utilities;
using PluginCore.Managers;
using PluginCore.Helpers;
using PluginCore;
using System.Xml;
using System.Resources;
using System.Reflection;
using System.Text;

namespace SolutionManager
{
	public class PluginMain : IPlugin
	{
        public static ResourceManager ResManager;

        private String pluginName = "SolutionManager";
        private String pluginGuid = "C500E75B-0D2B-4788-8A05-BCFA8504FF64";
        private String pluginHelp = "www.riabox.com";
        private String pluginDesc = "项目管理插件";
        private String pluginAuth = "fanflash";
        private String settingFilename;
        private Settings settingObject;
        private DockContent pluginPanel;
        private PluginUI pluginUI;
        private Image pluginImage;

	    #region Required Properties

        /// <summary>
        /// Name of the plugin
        /// </summary> 
        public String Name
		{
			get { return this.pluginName; }
		}

        /// <summary>
        /// GUID of the plugin
        /// </summary>
        public String Guid
		{
			get { return this.pluginGuid; }
		}

        /// <summary>
        /// Author of the plugin
        /// </summary> 
        public String Author
		{
			get { return this.pluginAuth; }
		}

        /// <summary>
        /// Description of the plugin
        /// </summary> 
        public String Description
		{
			get { return this.pluginDesc; }
		}

        /// <summary>
        /// Web address for help
        /// </summary> 
        public String Help
		{
			get { return this.pluginHelp; }
		}

        /// <summary>
        /// Object that contains the settings
        /// </summary>
        [Browsable(false)]
        public Object Settings
        {
            get { return this.settingObject; }
        }
		
		#endregion
		
		#region Required Methods
		
		/// <summary>
		/// Initializes the plugin
		/// </summary>
		public void Initialize()
		{
            this.InitBasics();
            this.LoadSettings();
            this.AddEventHandlers();
            this.InitLocalization();
            this.CreatePluginPanel();
            this.CreateMenuItem();

            PMProxy.Initialize();
            
        }
		
		/// <summary>
		/// Disposes the plugin
		/// </summary>
		public void Dispose()
		{
            this.SaveSettings();
		}
		
		/// <summary>
		/// Handles the incoming events
		/// </summary>
		public void HandleEvent(Object sender, NotifyEvent e, HandlingPriority prority)
		{
            TextEvent te = e as TextEvent;

            //按从上到下的时间引发
            switch (e.Type)
            {
                case EventType.FileOpening:
                    te.Handled = this.OpenSolution(te.Value);
                    break;

                /*
                case EventType.FileOpen:
                    break;

                // Catches FileSwitch event and displays the filename it in the PluginUI.
                case EventType.FileSwitch:
                    string fileName = PluginBase.MainForm.CurrentDocument.FileName;
                    pluginUI.Output.Text += fileName + "\r\n";
                    TraceManager.Add("Switched to " + fileName); // tracing to output panel
                    break;

                // Catches Project change event and display the active project path
                case EventType.Command:
                    string cmd = (e as DataEvent).Action;
                    if (cmd == "ProjectManager.Project")
                    {
                        IProject project = PluginBase.CurrentProject;
                        if (project == null)
                            pluginUI.Output.Text += "Project closed.\r\n";
                        else
                            pluginUI.Output.Text += "Project open: " + project.ProjectPath + "\r\n";
                    }
                    break;
                 */
            }
		}



		#endregion

        #region Custom Methods
       
        /// <summary>
        /// Initializes important variables
        /// </summary>
        public void InitBasics()
        {
            String dataPath = Path.Combine(PathHelper.DataDir, "SolManagerPlugin");
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            this.settingFilename = Path.Combine(dataPath, "Settings.fdb");
            this.pluginImage = PluginBase.MainForm.FindImage("100");

            //公用的资源管理器
            ResManager = new ResourceManager("SolutionManager.Resources.Resource", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Adds the required event handlers
        /// </summary> 
        public void AddEventHandlers()
        {
            // Set events you want to listen (combine as flags)
            //EventManager.AddEventHandler(this, EventType.FileSwitch | EventType.Command | EventType.FileOpen | EventType.FileOpening);
            EventManager.AddEventHandler(this, EventType.FileOpening);
        }

        /// <summary>
        /// Initializes the localization of the plugin
        /// </summary>
        public void InitLocalization()
        {
            LocaleVersion locale = PluginBase.MainForm.Settings.LocaleVersion;
            switch (locale)
            {
                /*
                case LocaleVersion.fi_FI : 
                    // We have Finnish available... or not. :)
                    LocaleHelper.Initialize(LocaleVersion.fi_FI);
                    break;
                */
                default : 
                    // Plugins should default to English...
                    LocaleHelper.Initialize(LocaleVersion.en_US);
                    break;
            }
            this.pluginDesc = LocaleHelper.GetString("Info.Description");
        }

        /// <summary>
        /// Creates a menu item for the plugin and adds a ignored key
        /// </summary>
        public void CreateMenuItem()
        {
            ToolStripMenuItem viewMenu = (ToolStripMenuItem)PluginBase.MainForm.FindMenuItem("ViewMenu");
            viewMenu.DropDownItems.Add(new ToolStripMenuItem(LocaleHelper.GetString("Label.ViewMenuItem"), this.pluginImage, new EventHandler(this.OpenPanel), this.settingObject.SampleShortcut));
            PluginBase.MainForm.IgnoredKeys.Add(this.settingObject.SampleShortcut);
        }

        /// <summary>
        /// Creates a plugin panel for the plugin
        /// </summary>
        public void CreatePluginPanel()
        {
            this.pluginUI = new PluginUI(this);
            //this.pluginUI.Text = LocaleHelper.GetString("Title.PluginPanel");
            this.pluginPanel = PluginBase.MainForm.CreateDockablePanel(this.pluginUI, this.pluginGuid, this.pluginImage, DockState.DockRight);
        }

        /// <summary>
        /// Loads the plugin settings
        /// </summary>
        public void LoadSettings()
        {
            this.settingObject = new Settings();
            if (!File.Exists(this.settingFilename)) this.SaveSettings();
            else
            {
                try
                {
                    Object obj = ObjectSerializer.Deserialize(this.settingFilename, this.settingObject);
                    this.settingObject = (Settings)obj;
                }
                catch {
                    this.SaveSettings();
                }
            }
        }

        /// <summary>
        /// Saves the plugin settings
        /// </summary>
        public void SaveSettings()
        {
            ObjectSerializer.Serialize(this.settingFilename, this.settingObject);
        }

        /// <summary>
        /// Opens the plugin panel if closed
        /// </summary>
        public void OpenPanel(Object sender, System.EventArgs e)
        {
            this.pluginPanel.Show();
        }

        public bool OpenSolution(string path) {
            return this.pluginUI.OpenSolution(path);
        }

		#endregion

	}
	
}
