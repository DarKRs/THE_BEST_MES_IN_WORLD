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
        Parser parser = new Parser();
        int Q = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
            string path = openFile.FileName;
           
            parser.ParseFile(path);
            PrintObjects(parser.Objects);
            QuestionsTextBox.Text = parser.Questions;
            AutorTextBox.Text = parser.Autor;
            Go.Enabled = true;
        }

        void PrintObjects(Object[] obj)
        {
            string Objects = "";
            for(int i = 0; i < obj.Length; i++)
            {
                Objects += obj[i].Name + "[" + obj[i].pConst + "]" + "\n";
            }
            ObjectTextBox.Text = Objects;
        }

        private void Go_Click(object sender, EventArgs e)
        {
            Reload();
            Next.Enabled = true;
            string[] Quest = parser.Questions.Split('\r');
            DynamicTextBox.Text = Quest[1];
        }

        private void Next_Click(object sender, EventArgs e)
        {
            string[] Quest = parser.Questions.Split('\r');
            if (Q+1 == Quest.Length-1)
            {
                MessageBox.Show("Закончились вопросы",
               "ВОПРОСОВ НЕТ!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Next.Enabled = false;
                return;
            }
            Q++;
            if (Otvet.Text == "")
            {
                MessageBox.Show("Впишите свой ответ от -5 до +5",
                "Все очень плохо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int Otv = Convert.ToInt32(Otvet.Text);
            if (Otv == 5)
            {
                for (int i = 0; i < parser.Objects.Length; i++)
                {
                    parser.Objects[i].pCurrent = (parser.Objects[i].Questins[Q].pPlus * parser.Objects[i].pCurrent) / ((parser.Objects[i].Questins[Q].pPlus * parser.Objects[i].pCurrent) + (parser.Objects[i].Questins[Q].pMinus * (1 - parser.Objects[i].pCurrent))) ;
                }
            }
            if (Otv == -5)
            {
                for (int i = 0; i < parser.Objects.Length; i++)
                {
                    parser.Objects[i].pCurrent = ((1 - parser.Objects[i].Questins[Q].pPlus) * parser.Objects[i].pCurrent) / ((1 - parser.Objects[i].Questins[Q].pPlus) * parser.Objects[i].pCurrent) - (parser.Objects[i].Questins[Q].pMinus * (1 - parser.Objects[i].pCurrent));
                }
            }
            if(Otv >=  -5 && Otv <= 0)
            {
                for (int i = 0; i < parser.Objects.Length; i++)
                {
                    parser.Objects[i].pCurrent = (((Otv + 5) * (parser.Objects[i].pCurrent - parser.Objects[i].Questins[Q].pMinus)) / 5) + parser.Objects[i].Questins[Q].pMinus;
                }
            }
            if (Otv >= 0 && Otv <= 5)
            {
                for (int i = 0; i < parser.Objects.Length; i++)
                {
                    parser.Objects[i].pCurrent = (((Otv - 0) * (parser.Objects[i].Questins[Q].pPlus - parser.Objects[i].pCurrent)) / 5) + parser.Objects[i].pCurrent;
                }
            }

            ModifyCurrentQuest();
            ModifyQuest();
            ModifyObjects();
        }

        void Reload()
        {
            string Objects = "";
            for (int i = 0; i < parser.Objects.Length; i++)
            {
                parser.Objects[i].pCurrent = parser.Objects[i].pConst;
            }
            for (int i = 0; i < parser.Objects.Length; i++)
            {
                Objects += parser.Objects[i].Name + "[" + parser.Objects[i].pConst + "]" + "\n";
            }
            ObjectTextBox.Text = Objects;
            QuestionsTextBox.Text = parser.Questions;
            AutorTextBox.Text = parser.Autor;
        }

        void ModifyObjects()
        {
            string Objects = "";
            for (int i = 0; i < parser.Objects.Length; i++)
            {
                if(parser.Objects[i].pCurrent == 0)
                {
                    i++;
                }
                Objects += parser.Objects[i].Name + "[" + parser.Objects[i].pCurrent + "]" + "\n";
            }
            ObjectTextBox.Text = Objects;
        }

        void ModifyCurrentQuest()
        {
            string[] Quest = parser.Questions.Split('\r');
            DynamicTextBox.Text = Quest[1 + Q];
           
        }

        void ModifyQuest()
        {
            QuestionsTextBox.Clear();
            string[] Quest = parser.Questions.Split('\r');
            for (int i = 2 + Q; i < Quest.Length; i++)
            {
                QuestionsTextBox.Text += Quest[i] + "\n";
            }
        }

    }
}
