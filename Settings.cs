using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGuess
{
    public partial class Settings : Form
    {
        public List<string> questionsList = new List<string>();
        public bool isFilled = false;

        public string path = "Questions.txt";


        public Settings()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //удалить
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //добавить
            if (textBox1.Text == "")
            {
                MessageBox.Show("Текстовое поле пустое", "Введите вопрос", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            questionsList.Add(textBox1.Text);

            WriteListToFile();
        }

        private void WriteListToFile()
        {
            StreamWriter file = new StreamWriter(path);
            StringBuilder result = new StringBuilder();
            foreach(var item in questionsList)
            {
                result.Append(item + "\r\n");
            }
            file.WriteLine(textBox1.Text);
            MessageBox.Show("Вопрос добавлен", "Успех операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
            file.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //открыть файл
            listBox1.Items.Clear();
            StreamReader file = new StreamReader(path);
            string[] questions = file.ReadToEnd().Split("\r\n");
            for (int i = 0; i < questions.Length; i++)
            {
                if (!isFilled)
                {
                    questionsList.Add(questions[i]);
                }

                listBox1.Items.Add(questions[i]);
            }
            isFilled = true;
            file.Close();
        }
    }
}
