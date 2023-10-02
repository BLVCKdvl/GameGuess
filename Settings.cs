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

        public string path = "Group";


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
            //1gr
            OpenGroupFile(1);

            //MessageBox.Show("1st", "Успех операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //2gr
            OpenGroupFile(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //3gr
            OpenGroupFile(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //4gr
            OpenGroupFile(4);
        }

        private void OpenGroupFile(int number)
        {
            listBox1.Items.Clear();
            string openPath = path + number.ToString() + ".txt";
            StreamReader file = new StreamReader(openPath);
            string[] questions = file.ReadToEnd().Split("\r\n");
            foreach(var item in questions)
            {
                listBox1.Items.Add(item);
            }

            file.Close();
        }
    }
}
