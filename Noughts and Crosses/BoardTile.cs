using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    /// <summary>
    /// Represents a tile on the board
    /// </summary>
    internal class BoardTile
    {
        private GameForm boardForm;
        private Button tileButton;

        public static bool turnState { get; set; } = true; //Specifies whether the tile is true / nought or false / cross
        public string tileState { get; private set; } //Specifies what state the tile is in: nought / cross / empty
        public bool tileClicked { get; private set; } = false; //Specifies whether or not the tile has been clicked
        public int tileXPosition { get; private set; } //Specifies the tile's X Position
        public int tileYPosition { get; private set; } //Specifies the tile's Y Position

        /// <summary>
        /// Initializes a new instance of the BoardTile class
        /// </summary>
        /// <param name="tileXPosition">X Position of the tile</param>
        /// <param name="tileYPosition">Y Position of the tile</param>
        /// <param name="boardForm">Form to place the tile on</param>
        public BoardTile(int tileXPosition, int tileYPosition, GameForm boardForm)
        {
            this.tileXPosition = tileXPosition;
            this.tileYPosition = tileYPosition;
            this.boardForm = boardForm;
            CreateButton();
        }
        /// <summary>
        /// Resets tile to default
        /// </summary>
        public void ResetTile()
        {
            tileState = "empty";
            tileClicked = false;
            tileButton.Visible = true;
            tileButton.Enabled = true;
        }
        /// <summary>
        /// Creates the tile game button
        /// </summary>
        private void CreateButton()
        {
            tileButton = new Button();
            tileButton.Size = new Size(200, 200);
            tileButton.Location = new Point(tileXPosition, tileYPosition);
            tileButton.BackColor = Color.LightBlue;
            tileButton.MouseDown += new MouseEventHandler(tileClick);
            tileButton.FlatStyle = FlatStyle.Flat;
            tileButton.FlatAppearance.BorderSize = 0;
            boardForm.Controls.Add(tileButton);
        }
        /// <summary>
        /// Event handler for clicking a tile
        /// </summary>
        /// <param name="sender">Specifies where the event was sent from</param>
        /// <param name="e">Specifies the event</param>
        private void tileClick(object sender, MouseEventArgs e)
        {
            tileClicked = true;
            tileButton.Visible = false;
            tileButton.Enabled = false;
            Color color;
            if (!turnState)
            {
                color = Color.Green;
                TilePen.DrawNought(boardForm.graphics, tileButton.Location.X, tileButton.Location.Y, color);
                tileState = "naught";
            }
            else
            {
                color = Color.Red;
                TilePen.DrawCross(boardForm.graphics, tileButton.Location.X, tileButton.Location.Y, color);
                tileState = "cross";
            }

            boardForm.NotiftyController(tileXPosition, tileYPosition, color);
            turnState = !turnState;
        }
    }
}
