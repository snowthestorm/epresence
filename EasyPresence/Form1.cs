using System;
using System.IO;
using System.Windows.Forms;
using DiscordRPC;
using EasyPresence.Common;
using EasyPresence.Lib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasyPresence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 1)
            {
                Program.DiscordModule.SetPresence(new RichPresence
                {
                    Details = textBox2.Text.Length != 0 ? textBox2.Text : "www.wetty.com",
                    Timestamps = new Timestamps
                    {
                        Start = DateTime.UtcNow
                    },
                    Assets = new Assets
                    {
                        LargeImageKey = Data.Configurations.Image.Length > 0 ? Data.Configurations.Image : null,
                        LargeImageText = Data.Configurations.ImageText.Length > 0 ? Data.Configurations.Image : null,
                        SmallImageKey = Data.Configurations.ImageText.Length > 0 ? Data.Configurations.Image : null,
                        SmallImageText = "www.wetty.com/es"
                    }
                });
            }
            else
            {
                if (Data.CurrentIdentifier != textBox1.Text)
                {
                    Data.CurrentIdentifier = textBox1.Text;
                    Program.DiscordModule.Reset();
                        
                    Program.DiscordModule = null;
                    Program.DiscordModule = new Discord(textBox1.Text);
                    Program.DiscordModule.Initialize();
                }
                
                Program.DiscordModule.SetPresence(new RichPresence
                {
                    Details = textBox2.Text.Length != 0 ? textBox2.Text : "www.wetty.com",
                    State = textBox3.Text.Length != 0 ? textBox3.Text : null,
                    Timestamps = new Timestamps
                    {
                        Start = DateTime.UtcNow
                    },
                    Assets = new Assets
                    {
                        LargeImageKey = textBox4.Text.Length != 0 ? textBox4.Text : "easypresence",
                        LargeImageText = textBox5.Text.Length != 0 ? textBox5.Text : null,
                        SmallImageKey = textBox7.Text.Length != 0 ? textBox7.Text : "easypresence",
                        SmallImageText = textBox6.Text.Length != 0 ? textBox6.Text : "www.wetty.com/es"
                    }
                });
            }

            SaveConfigurations();
            MessageBox.Show(@"New status set!", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveConfigurations()
        {
            var data = new JObject(
                new JProperty("identifier", Data.CurrentIdentifier),
                new JProperty("state", textBox2.Text), 
                new JProperty("details", textBox3.Text), 
                new JProperty("image", textBox4.Text), 
                new JProperty("image_text", textBox5.Text));
                
            using (var file = File.CreateText(@"easyPresence.json"))
            using (var writer = new JsonTextWriter(file))
            {
                data.WriteTo(writer);
            }
        }
    }
}