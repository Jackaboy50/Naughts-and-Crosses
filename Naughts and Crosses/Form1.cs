namespace Naughts_and_Crosses
{
    public partial class Form1 : Form
    {
        BoardTile[,] gameBoard = new BoardTile[3, 3];
        public Graphics graphics;
        public Pen pen;
        public Form1()
        {
            InitializeComponent();
            SetForm();
            DrawBoard();

            graphics = CreateGraphics();
            pen = new Pen(Color.Red);
        }

        private void DrawBoard()
        {
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    gameBoard[x, y] = new BoardTile(x * 200, y * 200, this);
                }
            }
        }

        private void SetForm()
        {
            Size = new Size(750, 750);
            Text = "Naughts and Crosses";
            BackColor = Color.LightBlue;
        }
    }
}