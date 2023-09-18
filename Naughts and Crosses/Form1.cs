namespace Naughts_and_Crosses
{
    public partial class Form1 : Form
    {
        GameController gameController;
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
            gameController = new GameController(this);

            int pointOffset = 200;
            for (int i = 0; i < 4; i++)
            {
                Button gridButton = new Button();
                Size size;
                Point point;
                
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
            Size = new Size(1000, 600);
            Text = "Naughts and Crosses";
            BackColor = Color.LightBlue;
        }

        public void NotiftyController(int x, int y, bool tileState)
        {
            bool win = gameController.CheckForWin(x, y);
            if(win && tileState)
            {
                Console.WriteLine("Naughts win");
            }
            else if(win && !tileState)
            {
                Console.WriteLine("Crosses win");
            }
        }
    }
}