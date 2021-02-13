using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaSphere.Reader
{
    public static class States
    {
        public static async Task<string> GameState(int gameState)
        {
            string gamestate;

            switch (gameState)
            {
                case 1:
                    gamestate = "Waiting";
                    break;
                case 2:
                    gamestate = "Playing";
                    break;
                case 9:
                    gamestate = "Result";
                    break;

                default:
                    gamestate = "Waiting";
                    break;
            }

            return gamestate;
        }

        public static async Task<string> TimeState(int timeState)
        {
            string timestate;

            switch (timeState)
            {
                case 1:
                    timestate = "First Half";
                    break;
                case 2:
                    timestate = "Halftime";
                    break;
                case 9:
                    timestate = "Second Half";
                    break;

                default:
                    timestate = "First Half";
                    break;
            }

            return timestate;
        }
    }
}
