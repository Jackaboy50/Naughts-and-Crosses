using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naughts_and_Crosses
{
    internal class BoardTile
    {
        private Form1 boardForm;
        private Button tileButton;

        public static bool turnState { get; private set; } = true;
        public bool tileState { get; private set; }
        public int tileXPosition { get; private set; }
        public int tileYPosition { get; private set; }

        public BoardTile(int tileXPosition, int tileYPosition, Form1 boardForm)
        {
            this.tileXPosition = tileXPosition;
            this.tileYPosition = tileYPosition;
            this.boardForm = boardForm;

            CreateButton();
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
            if (turnState)
            {
                tileButton.Visible = false;
                tileButton.Enabled = false;
                TilePen.DrawNaught(boardForm, tileButton.Location.X, tileButton.Location.Y);
            }
            else
            {

            }
        }
    }
}
