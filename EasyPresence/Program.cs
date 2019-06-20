using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using EasyPresence.Common;
using EasyPresence.Lib;

namespace EasyPresence
{
    internal static class Program
    {
        public static Form1 Form { get; set; }
        public static Discord DiscordModule { get; set; }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Helpers.LoadData())
            {
                MessageBox.Show(@"Configuration file loaded!");
            }
            
            DiscordModule = new Discord(Data.CurrentIdentifier);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DiscordModule.Initialize();
            DiscordModule.SetPresence(new RichPresence
            {
                Details = "www.wetty.com/ep",
                Timestamps = new Timestamps
                {
                    Start = DateTime.UtcNow
                },
                Assets = new Assets
                {
                    LargeImageKey = "easypresence"

                }
            });
            Form = new Form1();
            Application.Run(Form);
        }
    }
}