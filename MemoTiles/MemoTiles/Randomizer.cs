using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoTiles
{
    internal class Randomizer
    {
        // Selecting Random tiles
        public static int[] RandomTiles(int numberTiles, int boardSize)
        {
            int[] activeTiles;
            activeTiles = new int[numberTiles];
            for (int tilenumber, i = 0; i < numberTiles;)
            {
                bool isNotInside = true;
                Random rnd = new Random();
                tilenumber = rnd.Next(0, (boardSize * boardSize));
                for (int j = 0; j < i; j++)
                {

                    if (activeTiles[j] == tilenumber)
                    {
                        isNotInside = false;
                    }
                }
                if (isNotInside)
                {
                    activeTiles[i] = tilenumber;
                    i++;
                }
            }
            return (activeTiles);
        }
    }
}
