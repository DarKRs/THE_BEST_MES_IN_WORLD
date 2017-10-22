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
            Next.Enabled = true;
            string[] Quest = parser.Questions.Split('\r');
            DynamicTextBox.Text = Quest[1];
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Q++;
            if (Otvet.Text == "")
            {
                MessageBox.Show("Впишите свой ответ от -5 до +5",
                "Все очень плохо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            for(int i = 0; i < parser.Objects.Length; i++)
            {
                parser.Objects[i].pCurrent += parser.Objects[i].Questins[Q].pPlus;
            }
            
            ModifyObjects();
        }

        void ModifyObjects()
        {
            string Objects = "";
            for (int i = 0; i < parser.Objects.Length; i++)
            {
                Objects += parser.Objects[i].Name + "[" + parser.Objects[i].pCurrent + "]" + "\n";
            }
            ObjectTextBox.Text = Objects;
        }

    }
}
