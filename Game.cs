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
    public partial class Game : Form
    {
        private static int playersAmount;
        private static int groupMode;

        public Game()
        {
            InitializeComponent();
        }

        public static void SetDataConfiguration(int players, int group)
        {
            playersAmount = players;
            groupMode = group;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            GameConfig config = new GameConfig();
            config.ShowDialog();
            MessageBox.Show($"{playersAmount}players\n{groupMode}gamemode");
        }
    }
}
