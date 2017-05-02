using System.Collections.Generic;
using System;

namespace tictactoe
{
    public class AI
    {
        Random rnd = new Random();
        public int PickSpot(TicTacToe game)
        {
            //create an arraylist(dynamic) of available spots
            //remember indexing from 1
            //go through array and check availability
            List<int> choices = new List<int>();
           
            //go thorugh list to find available slots
            for (int i = 0; i < 9; i++)
            {
             if(game.board[i] == '_')
                {
                    choices.Add(i + 1);
                }
            }

            //select a random slot
            
            int compChoice = rnd.Next(choices[0], choices.Count);
            
            //Console.WriteLine("spot is: " + compChoice);


            return compChoice;
        }

    }
}
