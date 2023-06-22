using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace pvz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ChangeScreen(this, new MenuScreen());
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f;

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }


            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }

        public static void CheckProgress()
        {
            string xmlScore;

            XmlReader reader = XmlReader.Create("Resources/progression.xml", null);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    LevelScreen.progress = reader.ReadString();

                    reader.ReadToNextSibling("highscore");

                    xmlScore = reader.ReadString();
                    LevelScreen.highscore = Convert.ToInt32((xmlScore));
                }
            }

            reader.Close();
        }
    }
}
