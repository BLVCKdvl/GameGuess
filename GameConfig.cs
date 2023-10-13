using System;
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
    public partial class GameConfig : Form
    {
        private int players;
        private int gamemode;

        public GameConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked != true && radioButton2.Checked != true
                && radioButton3.Checked != true && radioButton4.Checked != true
                && radioButton5.Checked != true)
            {
                MessageBox.Show("Выберите группу вопросов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            players = trackBar1.Value;
            if (radioButton1.Checked == true)
            {
                gamemode = 1;
            }
            else if (radioButton2.Checked == true)
            {
                gamemode = 2;
            }
            else if (radioButton3.Checked == true)
            {
                gamemode = 3;
            }
            else if (radioButton4.Checked == true)
            {
                gamemode = 4;
            }
            else
            {
                gamemode = 5;
            }

            this.Close();
        }

        private void GameConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game.SetDataConfiguration(players, gamemode);
        }
    }
}
