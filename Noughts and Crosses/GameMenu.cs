using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    internal class GameMenu
    {
        Form1 boardForm;

        Panel startMenu;
        Button playerChoiceX;
        Button playerChoiceO;
        Button startButton;

        Panel winMenu;
        Button restartButton;
        Button exitButton;
        Label winnerLabel;

        private bool choiceState;
        private Graphics graphics;

        public GameMenu(Form1 form1, Graphics graphics)
        {
            this.graphics = graphics;
            boardForm = form1;
            CreateStartMenu();
        }

        public void CreateStartMenu()
        {
            startMenu = new Panel();
            startMenu.Size = new Size(500, 400);
            startMenu.Location = new Point(50, 100);
            startMenu.BackColor = Color.LightGray;
            startMenu.BorderStyle = BorderStyle.FixedSingle;

            startButton = new Button();
            startButton.Size = new Size(200, 40);
            startButton.Location = new Point(151, 300);
            startButton.Text = "Start Game";
            startButton.Font = new Font("Arial", 12, FontStyle.Bold);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.BackColor = Color.ForestGreen;
            startButton.MouseDown += new MouseEventHandler(StartButtonClick);
            startMenu.Controls.Add(startButton);

            playerChoiceX = new Button();
            playerChoiceX.Size = new Size(25, 25);
            playerChoiceX.Location = new Point(125, 200);
            playerChoiceX.BackColor = Color.Green;
            playerChoiceX.MouseDown += new MouseEventHandler(PlayerChoiceOption);
            startMenu.Controls.Add(playerChoiceX);
            TilePen.DrawCross(graphics, 125, 100, Color.Red);

            playerChoiceO = new Button();
            playerChoiceO.Size = new Size(25, 25);
            playerChoiceO.Location = new Point(350, 200);
            playerChoiceO.BackColor = Color.Red;
            playerChoiceO.MouseDown += new MouseEventHandler(PlayerChoiceOption);
            startMenu.Controls.Add(playerChoiceO);
            TilePen.DrawNaught(graphics, 350, 100, Color.Green);

            boardForm.Controls.Add(startMenu);
            boardForm.Controls[boardForm.Controls.Count - 1].BringToFront();
        }

        public void CreateWinMenu(string winMessage)
        {
            if(winMenu != null)
            { 
                ShowWinMenu(winMessage);
            }
            winMenu = new Panel();
            winMenu.Size = new Size(500, 400);
            winMenu.Location = new Point(50, 100);
            winMenu.BackColor = Color.LightGray;
            winMenu.BorderStyle = BorderStyle.FixedSingle;

            restartButton = new Button();
            restartButton.Size = new Size(200, 40);
            restartButton.Location = new Point(41, 300);
            restartButton.Text = "Restart Game";
            restartButton.Font = new Font("Arial", 12, FontStyle.Bold);
            restartButton.FlatStyle = FlatStyle.Flat;
            restartButton.BackColor = Color.ForestGreen;
            restartButton.MouseDown += new MouseEventHandler(RestartButtonClick);
            winMenu.Controls.Add(restartButton);

            exitButton = new Button();
            exitButton.Size = new Size(200, 40);
            exitButton.Location = new Point(261, 300);
            exitButton.Text = "Exit Game";
            exitButton.Font = new Font("Arial", 12, FontStyle.Bold);
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.BackColor = Color.Red;
            exitButton.MouseDown += new MouseEventHandler(ExitButtonClick);
            winMenu.Controls.Add(exitButton);

            winnerLabel = new Label();
            winnerLabel.Size = new Size(100, 100);
            winnerLabel.Location = new Point(151, 150);
            winnerLabel.Text = winMessage;
            winnerLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            winnerLabel.TextAlign = ContentAlignment.MiddleCenter;
            winnerLabel.AutoSize = false;
            winnerLabel.Dock = DockStyle.Fill;
            winMenu.Controls.Add(winnerLabel);

            boardForm.Controls.Add(winMenu);
            boardForm.Controls[boardForm.Controls.Count - 1].BringToFront();

        }

        private void ShowWinMenu(string winMessage)
        {
            winnerLabel.Text = winMessage;
            winMenu.Visible = true;
        }

        private void StartButtonClick(object sender, MouseEventArgs e)
        {
            startMenu.Hide();
            boardForm.StartGame(choiceState);
        }

        private void RestartButtonClick(object sender, MouseEventArgs e)
        {
            foreach(Control c in boardForm.Controls)
            {
                if(c is Panel)
                {
                    c.Hide();
                }
            }
            boardForm.RestartGame();
        }

        private void ExitButtonClick(object sender, MouseEventArgs e)
        {
            boardForm.Close();
        }

        private void PlayerChoiceOption(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if(button.BackColor == Color.Green)
            {
                choiceState = false;
            }
            else
            {
                choiceState = true;
            }
        }
    }
}
