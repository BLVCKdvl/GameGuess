using System.Windows.Forms;

namespace GameGuess
{
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
        }

        private void Quiz_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //game
            Game gameForm = new Game();
            gameForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //editor
            Settings editor = new Settings();
            editor.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //settings
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //guide
            Guide guide = new Guide();
            guide.ShowDialog();
        }

    }
}