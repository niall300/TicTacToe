using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    public class Program
    {
        static void Main(string[] args)
        {
            myLabel:
            Console.WriteLine(" Please enter x or y ");
            char playerMarker;

            //as long as the first character is x or y we are happy
            try
            {
                playerMarker = Console.ReadLine()[0];
            }
            catch(IndexOutOfRangeException)
            {
                //just in case input is empty
                //we loop back to our question
                goto myLabel;
            }

                if(playerMarker != 'x' && playerMarker != 'y')
                {
                    goto myLabel;
                 }
             
            //create game      
            TicTacToe myGame = new TicTacToe(playerMarker);
            myGame.PrintIndexBoard();
           // Console.ReadLine();
            AI computerPlayer = new AI();
            int spot = computerPlayer.PickSpot(myGame);

            for (int i = 0; i < 40; i++)
            {
                spot = computerPlayer.PickSpot(myGame);
                Console.WriteLine(spot);
            }
            



            Console.ReadLine();

        }
    }
}
