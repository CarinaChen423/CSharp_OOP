using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoTiles
{
    internal class VoidMessages
    {
        public static void VoidWon(int showTime) //Displays a message for the User if he WON
        {
            MessageBox.Show(
                                        $"Your time was {Math.Abs(showTime).ToString()} seconds.",
                                       "You Won, congrats!",
                                       MessageBoxButtons.OK
                        );
        }
        public static void VoidGameOver(int showTime) //Displays a message for the User if he LOST
        {
            MessageBox.Show(
                                        $"Your wasted {Math.Abs(showTime).ToString()} seconds",
                                       "Game Over!",
                                       MessageBoxButtons.OK
                        );
        }
    }
}
