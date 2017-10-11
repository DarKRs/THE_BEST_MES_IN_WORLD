using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    class Parser
    {
        string Autor;
        string Objects;
        string Questions;

        public void ParseFile(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader reader = new StreamReader(fs, System.Text.Encoding.Default);

                string[] AQO;
                AQO = new string[3];
                int j = 0;

                string file = reader.ReadToEnd();
                string[] Entit = file.Split('\n');
                for (int i = 0; i < Entit.Length; i++)
                {
                    if (Entit[i] == "\r")
                    {
                        j++;
                    }
                    AQO[j] += Entit[i];

                }
                string[] Quest = AQO[1].Split(':');
                this.Autor = AQO[0];
                this.Questions = Quest[1];
                this.Objects = AQO[2];
                reader.Close();
                parseObjects(AQO[2]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Все очень плохо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void parseObjects(string AQO)
        {

            string[] Obj1 = AQO.Split('\t');
            Object[] Objectss = new Object[200];
            int o = 0;
            for (int a = 0; a < Obj1.Length; a++)
            {
                string[] Obj = Obj1[a].Split('\r');
                for (int i = 1; i <= Obj.Length; i++)
                {
                    string[] Objec = Obj[i].Split(',');
                    Objectss[o].Name = Objec[0];
                    Objectss[o].pConst = Convert.ToDouble(Objec[1]);
                    for (int j = 2; j < Objec.Length; j++)
                    {
                        int number = Convert.ToInt32(Objec[j]);
                        j++;
                        double pPlus1 = Convert.ToDouble(Objec[j]);
                        j++;
                        double pMinus1 = Convert.ToDouble(Objec[j]);
                        Objectss[o].Questins.Add(number, new Questions { pPlus = pPlus1, pMinus = pMinus1 });
                    }
                    o++;
                }
            }

        }
    }
}
