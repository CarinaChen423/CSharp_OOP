using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoTiles
{
    class GameData
    {
        public string playerName;
        public int boardSize, lives, showTime, numberTiles;

    }
    static class Data
    {
        public static Dictionary<string, GameData>
            GameDictionary = new Dictionary<string, GameData>();
    }
}
