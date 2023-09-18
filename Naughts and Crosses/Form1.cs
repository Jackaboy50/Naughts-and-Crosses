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

            int pointOffset = 200;
            for (int i = 0; i < 4; i++)
            {
                Button gridButton = new Button();
                Size size = new Size();
                Point point = new Point();
                
                if(i < 2)
                {
                    size = new Size(600, 5);
                    point = new Point(0, pointOffset);
                }
                else
                {
                    size = new Size(5, 600);
                    point = new Point(pointOffset - 400, 0);
                }

                gridButton.Size = size;
                gridButton.Location = point;
                gridButton.FlatStyle = FlatStyle.Flat;
                gridButton.FlatAppearance.BorderSize = 0;
                gridButton.BackColor = Color.Black;
                gridButton.Enabled = false;
                Controls.Add(gridButton);
                Controls[Controls.Count - 1].BringToFront();
                pointOffset += 200;
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