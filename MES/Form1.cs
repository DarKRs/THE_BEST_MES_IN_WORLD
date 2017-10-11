using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            string path = openFile.FileName;
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string file = reader.ReadToEnd();
                string[] Entit = file.Split('&');
                for (int i = 0; i < Entit.Length; i++)
                {
                    string[] Zapis = Entit[i].Split('$');
                    switch (name)
                    {
                        case "Mob":
                            Mob mb = new Mob(Zapis[0], int.Parse(Zapis[1]), int.Parse(Zapis[2]), int.Parse(Zapis[3]), Zapis[4]);
                            Entity.Entitys.Add(mb);
                            break;
                        case "Armor":
                            Armor arm = new Armor(Zapis[0], int.Parse(Zapis[1]), int.Parse(Zapis[2]), Zapis[3]);
                            Entity.Entitys.Add(arm);
                            break;
                        case "Weapon":
                            Weapon wp = new Weapon(Zapis[0], Zapis[1], int.Parse(Zapis[2]), Zapis[3], int.Parse(Zapis[4]), Zapis[5]);
                            Entity.Entitys.Add(wp);
                            break;
                        case "Ability":
                            Ability ab = new Ability(Zapis[0], Zapis[1], int.Parse(Zapis[2]), Zapis[3]);
                            Entity.Entitys.Add(ab);
                            break;

                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
  "Все пошло по пизде", MessageBoxButtons.OK, MessageBoxIcon.Information); Close();
            }
        }
    }
}
