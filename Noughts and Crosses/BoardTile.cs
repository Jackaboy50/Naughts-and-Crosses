using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class BoardTile
    {
        private Form1 boardForm;
        private Button tileButton;

        public static bool turnState { get; set; } = true; //false for Naught, true for Cross
        public string tileState { get; private set; } //naught / cross / empty
        public bool tileClicked { get; private set; } = false;
        public int tileXPosition { get; private set; }
        public int tileYPosition { get; private set; }

        public BoardTile(int tileXPosition, int tileYPosition, Form1 boardForm)
        {
            this.tileXPosition = tileXPosition;
            this.tileYPosition = tileYPosition;
            this.boardForm = boardForm;

            CreateButton();
        }

        public void ResetTile()
        {
            tileState = "empty";
            tileClicked = false;
            tileButton.Visible = true;
            tileButton.Enabled = true;
        }

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

        private void tileClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                Console.WriteLine($"turnstate: {turnState}");
                Console.WriteLine($"tilestate: {tileState}");
                Console.WriteLine($"tileClicked: {tileClicked}");
                return;
            }
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
