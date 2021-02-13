using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MySql.Data.MySqlClient;

namespace PentaSphere.Modules
{
    public class Miscellaneous : ModuleBase<SocketCommandContext>
    {
        public const int Iterations = 24000;
        public static string connString = "Server=localhost;Database=database;Uid=root;Pwd=password;";

        [Group("account")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public class account : ModuleBase<SocketCommandContext>
        {

            [Command("create", RunMode = RunMode.Async)]
            [Summary("Create a new account.\nUsage: !account create <username> <password>")]
            [RequireBotPermission(ChannelPermission.SendMessages)]
            public async Task create(string username, string password)
            {
                var (hash, salt) = Hash(password);
                MySqlConnection mcon = new MySqlConnection(connString);
                mcon.Open();
                try
                {
                    string cmdText = "INSERT INTO accounts (Username, Password, Salt, SecurityLevel) VALUES (@name, @password, @salt, 0)";
                    MySqlCommand cmd = new MySqlCommand(cmdText, mcon);
                    cmd.Parameters.AddWithValue("@name", $"{username}");
                    cmd.Parameters.AddWithValue("@password", $"{hash}");
                    cmd.Parameters.AddWithValue("@salt", $"{salt}");
                    cmd.ExecuteNonQuery();
                    await ReplyAsync($"Created account: **{username}**");
                }
                catch
                {
                    await ReplyAsync("The account already exists!");
                }
                mcon.Close();
            }

            [Command("newpw", RunMode = RunMode.Async)]
            [Summary("Generate a new password.\nUsage: !account newpw <password>")]
            [RequireBotPermission(ChannelPermission.SendMessages)]
            public async Task newpw(string password)
            {
                var (hash, salt) = Hash(password);
                await ReplyAsync($"**Hash:** {hash}\n**Salt:** {salt}");
            }
        }

        public static (string hash, string salt) Hash(string password)
        {
            var salt = new byte[24];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            var hash = new byte[24];
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                hash = pbkdf2.GetBytes(24);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        }

    }
}
