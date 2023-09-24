﻿using System;
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

        public static bool turnState { get; private set; } = true; //true for Naught, false for Cross
        public bool tileState { get; private set; } //true for Naught, false for Cross
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
            tileClicked = true;
            tileButton.Visible = false;
            tileButton.Enabled = false;
            Color color;
            if (!turnState)
            {
                color = Color.Green;
                TilePen.DrawNaught(boardForm.graphics, tileButton.Location.X, tileButton.Location.Y, color);
                tileState = true;
            }
            else
            {
                color = Color.Red;
                TilePen.DrawCross(boardForm.graphics, tileButton.Location.X, tileButton.Location.Y, color);
                tileState = false;
            }

            boardForm.NotiftyController(tileXPosition, tileYPosition, color);
            turnState = !turnState;
        }
    }
}
