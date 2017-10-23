using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES
{
    class Parser
    {
       public string Autor;
       public Object[] Objects;
       public string Questions;

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
                this.Objects = parseObjects(AQO[2]);
                reader.Close();
                
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                "Все очень плохо", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }
        }

        public Object[] parseObjects(string AQO)
        {

            string[] Obj1 = AQO.Split('\t');
           
           
            int o = 0;

                string[] Obj = Obj1[0].Split('\r');
                 Object[] Objectss = new Object[Obj.Length-1];
            for (int i = 0; i < Obj.Length-1; i++)
            {
                Objectss[i] = new Object();
            }
            
            for (int i = 1; i < Obj.Length; i++)
                {
                    
                    string[] Objec = Obj[i].Split(',');
                    Objectss[o].Name = Objec[0];
                    

                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.NumberDecimalSeparator = ".";

                    Objectss[o].pConst = double.Parse(Objec[1], ci);
                    for (int j = 2; j < Objec.Length; j++)
                    {
                        int number = Convert.ToInt32(Objec[j]);
                        j++;
                        double pPlus1 = double.Parse(Objec[j], ci);
                        j++;
                        double pMinus1 = double.Parse(Objec[j], ci);
                        Questions quest = new Questions(pPlus1,pMinus1);
                        Objectss[o].Questins.Add(number, quest);
                    }
                    o++;
                }
            return Objectss;
        }
    }
}
