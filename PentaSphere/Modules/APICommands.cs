using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using PentaSphere.Reader;


namespace PentaSphere.Modules
{
    public class APICommands : ModuleBase<SocketCommandContext>
    {
        EmbedBuilder embed = new EmbedBuilder();

        bool isFriendly;
        bool isNoIntrusion;
        bool hasPassword;
        bool hasPity;

        public static Dictionary<string, string> API;

        [Command("help")]
        [Summary("Shows this message.")]
        [RequireBotPermission(ChannelPermission.SendMessages)]
        public async Task help()
        {
            List<CommandInfo> commands = Program._commands.Commands.ToList();
            EmbedBuilder embedBuilder = new EmbedBuilder();

            foreach (CommandInfo command in commands)
            {
                // Get the command Summary attribute information
                string embedFieldText = command.Summary ?? "No description available\n";

                embedBuilder.AddField(command.Name, embedFieldText);
            }

            await ReplyAsync("Here's a list of commands and their description: ", false, embedBuilder.Build());
        }

        [Command("player")]
        [Summary("Shows infos about a player.\nUsage: !player <playerid>")]
        [RequireBotPermission(ChannelPermission.SendMessages)]
        public async Task test(string playerid)
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead($"http://ServerIP:22000/players/{playerid}");
                using (StreamReader sr = new StreamReader(stream))
                {
                    var response = sr.ReadToEnd();
                    Player result = JsonConvert.DeserializeObject<Player>(response);
                    await ReplyAsync($"Nickname: {result.Nickname}\nLevel: {result.Level}\nPEN: {result.Pen}\nAP: {result.Ap}\nChannel: {result.ChannelId}\nRoom: {result.RoomId}");
                }
            }
            catch
            {
                await ReplyAsync("The player could not be found or is not online");
            }
        }

        [Command("room")]
        [Summary("Shows infos about a room.\nUsage: !room <channelid> <roomid>")]
        [RequireBotPermission(ChannelPermission.SendMessages)]
        public async Task room(string channel, string room)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead($"http://ServerIP:22000/rooms/{channel}/{room}");
            using (StreamReader sr = new StreamReader(stream))
            {
                var response = sr.ReadToEnd();
                Room result = JsonConvert.DeserializeObject<Room>(response);
                isFriendly = result.IsFriendly;
                isNoIntrusion = result.IsNoIntrusion;
                if (result.Password.Length > 0)
                    hasPassword = true;
                else
                    hasPassword = false;
                hasPity = result.IsBalanced;


                embed.WithAuthor($"Info about Room #{room} in {await Channels.ChannelList(int.Parse(channel))}");
                embed.AddField("Base info", $"**Name:** {result.Name}\n" +
                                            $"**Map:** {result.Map.Name} (ID: {result.Map.Id})\n" +
                                            $"**Password:** {(hasPassword ? "Yes" : "No")}\n" +
                                            $"**Mode:** {await Rules.GameRules(result.GameRule)}\n" +
                                            $"**Game state:** {await States.GameState(result.State)}\n" +
                                            $"**Time state:** {await States.TimeState(result.TimeState)}", true);
                embed.AddField("Limits",    $"**Players:** {result.PlayerLimit}\n" +
                                            $"**Spectators:** {result.SpectatorLimit}\n" +
                                            $"**Time:** {result.TimeLimit}min\n" +
                                            $"**Score:** {result.ScoreLimit}P\n" +
                                            $"**Equip:** {await Limits.EquipLimit(result.EquipLimit)}", true);
                embed.AddField("Options",   $"**Friendly:** {(isFriendly ? "Yes" : "No")}\n" +
                                            $"**No Intrusion:** {(isNoIntrusion ? "Yes" : "No")}\n" +
                                            $"**Level requirement:** {result.MinLevel} - {result.MaxLevel}\n" +
                                            $"**Pity:** {(hasPity ? "Yes" : "No")}", true);

                if (result.GameRule == 1)
                    embed.WithColor(Color.Red);
                else if (result.GameRule == 2)
                    embed.WithColor(Color.Blue);
                else if (result.GameRule == 9)
                    embed.WithColor(Color.DarkPurple);
                else embed.WithColor(Color.Orange);

                embed.WithFooter("Provided by PentaSphere | Bot developed by Dekirai | Based on NetspherePirates Season 1");

                await ReplyAsync("", false, embed: embed.Build());
            }
        }

        [Command("iteminfo")]
        [Summary("Shows infos about an item.\nUsage: !iteminfo <itemid>")]
        [RequireBotPermission(ChannelPermission.SendMessages)]
        public async Task iteminfo(string itemid)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead($"http://ServerIP:22000/gamedata/items/{itemid}");
            using (StreamReader sr = new StreamReader(stream))
            {
                var response = sr.ReadToEnd();
                Item result = JsonConvert.DeserializeObject<Item>(response);
                var gender = "Unisex";
                if (result.Gender == 0)
                    gender = "Unisex";
                else if (result.Gender == 1)
                    gender = "Male";
                else if (result.Gender == 2)
                    gender = "Female";
                await ReplyAsync($"Item info for {result.Name}\n\nID: {result.Id}\nName: {result.Name}\nGender: {gender}");
            }
        }

        [Command("playercount")]
        [Summary("Shows how many players are currently online.")]
        [RequireBotPermission(ChannelPermission.SendMessages)]
        public async Task playercount()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead($"http://ServerIP:22000/statistics");
            using (StreamReader sr = new StreamReader(stream))
                API = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());

            await ReplyAsync($"Players online: {API["PlayersOnline"]}");
        }
    }
}
