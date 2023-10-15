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
    /// <summary>
    /// Represents the game menu
    /// </summary>
    internal class GameMenu
    {
        private GameForm boardForm; //Specifies the form where the menu's will be created

        //Elements used within the start menu
        private Panel startMenu;
        private Button playerChoiceX;
        private Button playerChoiceO;
        private Button startButton;

        //Elements used within the win menu
        private Panel winMenu;
        private Button restartButton;
        private Button exitButton;
        private Label winnerLabel;

        private bool choiceState; //Specifies the choice state set by the player choice buttons
        
        /// <summary>
        /// Initializes a new instance of the GameMenu class
        /// </summary>
        /// <param name="form1">Specifies where the menu's are created</param>
        public GameMenu(GameForm form1)
        {
            boardForm = form1;
            CreateStartMenu();
        }
        /// <summary>
        /// Creates the start menu for the game
        /// </summary>
        public void CreateStartMenu()
        {
            startMenu = new Panel();
            startMenu.Size = new Size(500, 400);
            startMenu.Location = new Point(50, 100);
            startMenu.BackColor = Color.LightGray;
            startMenu.BorderStyle = BorderStyle.FixedSingle;
            startMenu.Paint += new PaintEventHandler(startMenuPaint);

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
            

            playerChoiceO = new Button();
            playerChoiceO.Size = new Size(25, 25);
            playerChoiceO.Location = new Point(350, 200);
            playerChoiceO.BackColor = Color.Red;
            playerChoiceO.MouseDown += new MouseEventHandler(PlayerChoiceOption);
            startMenu.Controls.Add(playerChoiceO);
            

            boardForm.Controls.Add(startMenu);
            boardForm.Controls[boardForm.Controls.Count - 1].BringToFront();
        }
        /// <summary>
        /// Creates the win menu for the game
        /// </summary>
        /// <param name="winMessage">Specifies the message to be displayed</param>
        public void CreateWinMenu(string winMessage)
        {
            //If the win menu already exists, set the message and return
            if(winMenu != null)
            { 
                ShowWinMenu(winMessage);
                return;
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
        /// <summary>
        /// Event handler for the start menu's paint event
        /// </summary>
        /// <param name="sender">Specifies where the event was sent from</param>
        /// <param name="e">Specifies the event</param>
        private void startMenuPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            TilePen.DrawNought(graphics, 35, 10, Color.Green);
            TilePen.DrawCross(graphics, 265, 10, Color.Red);
        }
        /// <summary>
        /// Displays the win menu
        /// </summary>
        /// <param name="winMessage">Specifies the message to be displayed</param>
        private void ShowWinMenu(string winMessage)
        {
            winnerLabel.Text = winMessage;
            winMenu.Visible = true;
        }
        /// <summary>
        /// Event handler for the start button
        /// </summary>
        /// <param name="sender">Specifies where the event was sent from</param>
        /// <param name="e">Specifies the event</param>
        private void StartButtonClick(object sender, MouseEventArgs e)
        {
            startMenu.Hide();
            boardForm.StartGame(choiceState);
        }
        /// <summary>
        /// Event handler for the restart button
        /// </summary>
        /// <param name="sender">Specifies where the event was sent from</param>
        /// <param name="e">Specifies the event</param>
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
        /// <summary>
        /// Event handler for exit button
        /// </summary>
        /// <param name="sender">Specifies where the event was sent from</param>
        /// <param name="e">Specifies the event</param>
        private void ExitButtonClick(object sender, MouseEventArgs e)
        {
            boardForm.Close();
        }
        /// <summary>
        /// Event handler for player choice button
        /// </summary>
        /// <param name="sender">Specifies where the event was sent from</param>
        /// <param name="e">Specifies the event</param>
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
