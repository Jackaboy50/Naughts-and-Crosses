using System.ComponentModel;
using System.Windows.Forms.Design;

namespace Naughts_and_Crosses
{
    public partial class Form1 : Form
    {
        GameController gameController;
        GameMenu gameMenu;
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
            int pointOffset = 200;
            for (int i = 0; i < 4; i++)
            {
                Button gridButton = new Button();
                Size size = new Size();
                Point point = new Point();

                switch (i)
                {
                    case 0:
                        size = new Size(626, 5);
                        point = new Point(0, 200);
                        break;

                    case 1:
                        size = new Size(626, 5);
                        point = new Point(0, 405);
                        break;

                    case 2:
                        size = new Size(5, 649);
                        point = new Point(200, 0);
                        break;

                    case 3:
                        size = new Size(5, 649);
                        point = new Point(405, 0);
                        break;
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
            gameMenu = new GameMenu(this);
        }

        public void StartGame()
        {
            if(gameController == null)
            {
                gameController = new GameController();
                gameController.CreateBoard(this);
            }
            else
            {
                graphics.Clear(TransparencyKey);
                gameController.ResetBoard();
                Console.WriteLine("board reset");
            }
        }

        private void SetForm()
        {
            Size = new Size(626, 649);
            Text = "Naughts and Crosses";
            BackColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        public void NotiftyController(int x, int y, Color tileColor)
        {
            string winMessage = "";
            if(tileColor == Color.Red)
            {
                tileColor = Color.DarkRed;
                winMessage = "Crosses Win!";
            }
            else
            {
                tileColor = Color.DarkGreen;
                winMessage = "Naughts Win!";
            }
            switch(gameController.CheckForWin(x / 200, y / 200))
            {
                case -1:
                    if(gameController.tileCounter == 9)
                    {
                        gameMenu.CreateWinMenu("The game ended in a draw");
                    }
                    else
                    {
                        return;
                    }
                    break;

                case 0:
                    TilePen.DrawLine(graphics, 0, y + 100, 626, y + 100, tileColor);
                    break;

                case 1:
                    TilePen.DrawLine(graphics, x + 100, 0, x + 100, 649, tileColor);
                    break;

                case 2:
                    TilePen.DrawLine(graphics, 0, 0, 650, 650, tileColor);
                    break;

                case 3:
                    TilePen.DrawLine(graphics, 610, 0, 0, 610, tileColor);
                    break;
            }
            gameMenu.CreateWinMenu(winMessage);
        }
    }
}