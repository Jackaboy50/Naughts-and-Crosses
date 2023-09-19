using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Naughts_and_Crosses
{
    internal class GameController
    {
        BoardTile[,] gameBoard = new BoardTile[3, 3];
        public int tileCounter = 0;

        public GameController(Form1 form1)
        {
            
            for (int x = 0; x < 3; x++)
            {
                int xOffset = 0;
                int yOffset = 0;
                for (int y = 0; y < 3; y++)
                {
                    xOffset = x * 5;
                    yOffset = y * 5;
                    gameBoard[x, y] = new BoardTile((x * 200) + xOffset, (y * 200) + yOffset, form1);
                }
            }
        }
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

        private bool CheckRow(int y)
        {
            bool state = gameBoard[0, y].tileState;
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

        private bool CheckColumn(int x)
        {
            bool state = gameBoard[x, 0].tileState;
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

        private bool CheckDiagonal(bool anti)
        {
            bool state;
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
