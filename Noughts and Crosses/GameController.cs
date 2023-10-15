using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Noughts_and_Crosses
{
    /// <summary>
    /// Represents a controller for the noughts and crosses game
    /// </summary>
    internal class GameController
    {
        private BoardTile[,] gameBoard = new BoardTile[3, 3]; //Stores the board tile instances
        public int tileCounter = 0; //Counts the tiles that have been pressed

        /// <summary>
        /// Initializes a new instance of the GameController class
        /// </summary>
        public GameController()
        {}
        /// <summary>
        /// Creates the board and tiles
        /// </summary>
        /// <param name="form1">Specifies where the board will be created</param>
        /// <param name="choiceState">Specifies what state the board starts in</param>
        public void CreateBoard(GameForm form1, bool choiceState)
        {
            for (int x = 0; x < 3; x++)
            {
                int xOffset;
                int yOffset;
                for (int y = 0; y < 3; y++)
                {
                    xOffset = x * 5;
                    yOffset = y * 5;
                    gameBoard[x, y] = new BoardTile((x * 200) + xOffset, (y * 200) + yOffset, form1);
                }
            }
            BoardTile.turnState = choiceState;
        }
        /// <summary>
        /// Resets the board to it's default state
        /// </summary>
        public void ResetBoard()
        {
            tileCounter = 0;
            foreach(BoardTile tile in gameBoard)
            {
                tile.ResetTile();
            }
        }
        /// <summary>
        /// Checks whether there is a win on the board
        /// </summary>
        /// <param name="x">Specifies the starting X position</param>
        /// <param name="y">Specifies the starting Y position</param>
        /// <returns></returns>
        public int CheckForWin(int x, int y)
        {
            tileCounter++;
            if (CheckRow(y))
            {
                return 0;
            }
            else if (CheckColumn(x))
            {
                return 1;
            }
            else if (CheckDiagonal(false))
            {
                return 2;
            }
            else if (CheckDiagonal(true))
            {
                return 3;
            }
            return -1;
        }
        /// <summary>
        /// Checks the given row for a win condition
        /// </summary>
        /// <param name="y">Specifies the row to check</param>
        /// <returns></returns>
        private bool CheckRow(int y)
        {
            string state = gameBoard[0, y].tileState;
            for(int i = 0; i < 3; i++)
            {
                if (!gameBoard[i, y].tileClicked)
                {
                    break;
                }

                if(gameBoard[i, y].tileState != state)
                {
                    return false;
                }
                else if(i == 2)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks the given column for a win condition
        /// </summary>
        /// <param name="x">Specifies the column to check</param>
        /// <returns></returns>
        private bool CheckColumn(int x)
        {
            string state = gameBoard[x, 0].tileState;
            for(int i = 0; i < 3; i++)
            {
                if(!gameBoard[x, i].tileClicked)
                {
                    break;
                }

                if (gameBoard[x, i].tileState != state)
                {
                    return false;
                }
                else if(i == 2)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks the given diagonal for a win condition
        /// </summary>
        /// <param name="anti">Specifies which diagonal to check</param>
        /// <returns></returns>
        private bool CheckDiagonal(bool anti)
        {
            string state;
            //Checks top right to bottom left if true
            if (anti)
            {
                state = gameBoard[0, 2].tileState;
                for(int i = 0; i < 3; i++)
                {
                    if(!gameBoard[i, 2 - i].tileClicked)
                    {
                        break;
                    }

                    if (gameBoard[i, 2 - i].tileState != state)
                    {
                        return false;
                    }
                    else if(i == 2)
                    {
                        return true;
                    }
                }
            }
            //Checks top left to bottom right if false
            else
            {
                state = gameBoard[0, 0].tileState;
                for(int i = 0; i < 3; i++)
                {
                    if (!gameBoard[i, i].tileClicked)
                    {
                        break;
                    }

                    if (gameBoard[i,i].tileState != state)
                    {
                        return false;
                    }
                    else if(i == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
