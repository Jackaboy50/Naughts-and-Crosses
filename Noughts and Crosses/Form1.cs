using System.ComponentModel;
using System.Windows.Forms.Design;

namespace Noughts_and_Crosses
{
    /// <summary>
    /// Represents the window for the noughts and crosses game
    /// </summary>
    public partial class GameForm : Form
    {
        private GameController gameController;
        private GameMenu gameMenu;
        public Graphics graphics;
        public Pen pen;
        /// <summary>
        /// Initializes a new instance of the GameForm class
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            SetForm();
            graphics = CreateGraphics();
            pen = new Pen(Color.Red);
            DrawBoard();
        }
        /// <summary>
        /// Draws the board for the game
        /// </summary>
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
        /// <summary>
        /// Starts the noughts and crosses game
        /// </summary>
        /// <param name="choiceState">Specifies what state the board starts in</param>
        public void StartGame(bool choiceState)
        {
            gameController = new GameController();
            gameController.CreateBoard(this, choiceState);
        }
        /// <summary>
        /// Restarts the noughts and crosses game
        /// </summary>
        public void RestartGame()
        {
            graphics.Clear(TransparencyKey);
            gameController.ResetBoard();
        }
        /// <summary>
        /// Sets the properties for the form
        /// </summary>
        private void SetForm()
        {
            Size = new Size(626, 649);
            Text = "Noughts and Crosses";
            BackColor = Color.LightBlue;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
        /// <summary>
        /// Notifies the controller of the tile clicked
        /// </summary>
        /// <param name="x">Specifies the X coordinate of the tile pressed</param>
        /// <param name="y">Specifies the Y coordinate of the tile pressed</param>
        /// <param name="tileColor">Specifies the colour for the tile</param>
        public void NotiftyController(int x, int y, Color tileColor)
        {
            string winMessage;
            if(tileColor == Color.Red)
            {
                tileColor = Color.DarkRed;
                winMessage = "Crosses Win!";
            }
            else
            {
                tileColor = Color.DarkGreen;
                winMessage = "Noughts Win!";
            }
            switch(gameController.CheckForWin(x / 200, y / 200))
            {
                case -1:
                    if(gameController.tileCounter == 9)
                    {
                        gameMenu.CreateWinMenu("The game ended in a draw");
                        return;
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
        /// <summary>
        /// Loads the form
        /// </summary>
        /// <param name="sender">Specifies where the event is sent from</param>
        /// <param name="e">Specifies the event</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}