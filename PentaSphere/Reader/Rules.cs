using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaSphere.Reader
{
    public static class Rules
    {
        public static async Task<string> GameRules(int gameRule)
        {
            string gamerule;

            switch (gameRule)
            {
                case 1:
                    gamerule = "DM";
                    break;
                case 2:
                    gamerule = "TD";
                    break;
                case 4:
                    gamerule = "Practice";
                    break;
                case 9:
                    gamerule = "BR";
                    break;

                default:
                    gamerule = "Unknown Mode";
                    break;
            }

            return gamerule;
        }
    }
}
