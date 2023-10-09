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
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace GameGuess
{
    public partial class Settings : Form
    {
        private SqlConnection sqlConnection = null;
        private int selectedGroup = 0;

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
            //add question to database
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("Заполните все текстовые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Отметьте верный вариант ответа!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (selectedGroup == 0)
            {
                MessageBox.Show("Выберите группу вопросов для добавления слева", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            string correct = GetCorrectAnswer();

            SqlCommand commandAddQuestion = new SqlCommand(
                "INSERT INTO Questions (text, ans1, ans2, ans3, correct, gr) VALUES (@text, @ans1, @ans2, @ans3, @correct, @gr)", 
                sqlConnection);

            commandAddQuestion.Parameters.AddWithValue("text", textBox1.Text);
            commandAddQuestion.Parameters.AddWithValue("ans1", textBox2.Text);
            commandAddQuestion.Parameters.AddWithValue("ans2", textBox3.Text);
            commandAddQuestion.Parameters.AddWithValue("ans3", textBox4.Text);
            commandAddQuestion.Parameters.AddWithValue("correct", correct);
            commandAddQuestion.Parameters.AddWithValue("gr", selectedGroup);

            commandAddQuestion.ExecuteNonQuery();

            MessageBox.Show("Вопрос успешно добавлен", "Отчет операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetCorrectAnswer()
        {
            if (radioButton1.Checked)
            {
                return textBox2.Text;
            }
            else if (radioButton2.Checked)
            {
                return textBox3.Text;
            }

            return textBox4.Text;
        }

        private void WriteListToFile()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1gr
            selectedGroup = 1;
            OpenGroupFile();

            //MessageBox.Show("1st", "Успех операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //2gr
            selectedGroup = 2;
            OpenGroupFile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //3gr
            selectedGroup = 3;
            OpenGroupFile();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //4gr
            selectedGroup = 4;
            OpenGroupFile();
        }

        private void OpenGroupFile()
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Questions"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                //MessageBox.Show("Connection Successful");
            }
        }
    }
}
