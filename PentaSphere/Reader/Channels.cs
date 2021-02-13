using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaSphere.Reader
{
    public static class Channels
    {
        public static async Task<string> ChannelList(int channels)
        {
            string channel;

            switch (channels)
            {
                case 1:
                    channel = "Rookie";
                    break;
                case 2:
                    channel = "Super Rookie";
                    break;
                case 3:
                    channel = "Pro";
                    break;
                case 4:
                    channel = "Free";
                    break;
                case 5:
                    channel = "Free 2";
                    break;
                case 6:
                    channel = "Free 3";
                    break;
                case 7:
                    channel = "Free 4";
                    break;

                default:
                    channel = "Unknown channel";
                    break;
            }

            return channel;
        }
    }
}
