using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14HM
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Game cardGame = new Game("Player1", "Player2");
                cardGame.Play();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
