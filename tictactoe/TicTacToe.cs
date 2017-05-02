using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public class TicTacToe
    {
        //picture of game with index number
        //| 0 | 1 | 2 |
        //-------------
        //| 3 | 4 | 5 |
        //-------------
        //| 6 | 7 | 8 |

       //the user starts count at 1
       //| 1 | 2 | 3 |

       //initial game looks like
       //| _ | _ | _ |
       //-------------
       //| _ | _ | _ |
       //-------------
       //| _ | _ | _ |

       





        public char[] board;
        public char userMarker;
        public char computerMarker;
        public char winner;
        public char currentPlayer;
        public AI compPlayer;

        public char[] Board { get; set; }

        public TicTacToe(char playerMarker)
        {
            if (playerMarker == 'x')
            {
                this.userMarker = playerMarker;
                this.computerMarker = 'y';

            }
            else
            {
                this.userMarker = playerMarker;
                this.computerMarker = 'x';

            }
            
            this.winner = '_';
            board = SetBoard();


        }

        public static char[] SetBoard()
        {
            char[] board = new char[9];
            for(int i = 0; i < board.Length; i++)
            {
                board[i] = '_';
            }
            return board;
        }

        public void PrintBoard()
        {

            //attempting to create
            //| _ | _ | _ |
            //-------------
            //| _ | _ | _ |
            //-------------
            //| _ | _ | _ |
            //so every third element print the line "--------------"

            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
              
                //check if index is a multiple of 3
                //if so we are at the end of a line
                if(i % 3 == 0 && i != 0)
                {
                    Console.Write(" |");
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                }

                Console.Write(" | " + board[i]);
                //print a pipe after the last element
                if (i == board.Length - 1)
                {
                    Console.Write(" |");
                }

            }
            
           


        }
        public void PrintIndexBoard()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {

                //check if index is a multiple of 3
                //if so we are at the end of a line
                if (i % 3 == 0 && i != 0)
                {
                    Console.Write(" |");
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                }

                Console.Write(" | " + (i + 1));
                //print a pipe after the last element
                if (i == board.Length - 1)
                {
                    Console.Write(" |");
                }

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Select the slot for your {0} by selecting the relevant number.", userMarker);
        }

        public Boolean TakeTurn(int mySpot)
        {
            //take one from myspot (zero indexed array)
            mySpot = mySpot - 1;
            Boolean isValid = SpotisValid(mySpot) && !SpotIsTaken(mySpot);

            if(isValid)
            {
                //if it is a valid spot then put currentPlayer here
                //and change currentPlayer
                board[mySpot] = currentPlayer;

                //if currentplayer is usermarker then change it to usermarker
                //else it is by default computerMarker and we change it to userMarker
                currentPlayer = (currentPlayer == userMarker ? computerMarker : userMarker);

            }
            //else isValid is false

            return isValid;

        }

        public Boolean SpotisValid(int mySpot)
        {
            Boolean SpotValid;
            if (mySpot < board.Length || board[mySpot] <= 0)
            {
                SpotValid = true;
            }
            else
                SpotValid = false;
            return SpotValid;
        
        }

        public Boolean SpotIsTaken(int mySpot)
        {
            Boolean SpotTaken;
            if (board[mySpot] != '_')
            {
                SpotTaken = false;
            }
            else
                SpotTaken = true;
            return SpotTaken;
        }

        public Boolean IsThereAWinner()
        {
           
            //check diags and crosses
            //the center square must have a marker
            Boolean DiagsCrosses = DiagLeft() || DiagRight() || MidRow() || MidCol() && (board[4] != '_');
            //check top row and first column and first square must have a marker
            Boolean TopRowFirstCol = TopRow() || FirstCol() && (board[0] != '_');
            //check bottom row and last column and last square must have a marker
            Boolean BotRowLastCol = BottomRow() || LastCol() && (board[8] != '_');

            //check who the winner is
            if(DiagsCrosses)
            {
                this.winner = board[4];
            }
            else if(TopRowFirstCol)
            {
                this.winner = board[0];
            }
            else if(BotRowLastCol)
            {
                this.winner = board[8];
            }



            return DiagsCrosses || TopRowFirstCol || BotRowLastCol;
        }

        public Boolean IsBoardFilled()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '_')
                {
                    return false;
                }
                
                                   
            }
            return true;
        }

        public Boolean IsGameOver()
        {
            return IsThereAWinner() || IsBoardFilled();
        }

        private bool LastCol()
        {
            return (board[2] == board[5]) && (board[5] == board[8]);

        }

        private bool BottomRow()
        {
            return (board[6] == board[7]) && (board[7] == board[8]);
        }

        private bool FirstCol()
        {
            return (board[0] == board[3]) && (board[3] == board[6]);
        }

        private bool TopRow()
        {
            return (board[0] == board[1]) && (board[1] == board[2]);
        }

        private bool MidCol()
        {
            return (board[1] == board[4]) && (board[4] == board[7]);
        }

        private bool DiagLeft()
        {
            return (board[0] == board[4]) && (board[4] == board[8]);
        }

        private bool DiagRight()
        {
            return (board[2] == board[4]) && (board[4] == board[6]);
        }
        private bool MidRow()
        {
            return (board[1] == board[4]) && (board[4] == board[7]);
        }
    }
}
