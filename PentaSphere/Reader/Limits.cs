using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaSphere.Reader
{
    public static class Limits
    {
        public static async Task<string> EquipLimit(int equipLimit)
        {
            string equiplimit;

            switch (equipLimit)
            {
                case 0:
                    equiplimit = "S4 League";
                    break;
                case 1:
                    equiplimit = "Super League";
                    break;
                case 2:
                    equiplimit = "Rookie League";
                    break;
                case 3:
                    equiplimit = "Sword Match";
                    break;

                default:
                    equiplimit = "Unknown Equip Limit";
                    break;
            }

            return equiplimit;
        }
    }
}
