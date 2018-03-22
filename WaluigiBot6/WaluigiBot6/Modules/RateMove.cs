using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaluigiBot6.Modules
{
    public class RateMove : ModuleBase<SocketCommandContext>
    {
        [Command("rate")]
        public async Task PingRate(SocketGuildUser user)
        {
            Random rnd = new Random();
            int score = rnd.Next(0, 100);

            var role1 = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "Alpha Thot");
            var role2 = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "beta cucks");
            var role3 = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "street hoes");
            var role4 = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "garbage slut");

            if (user.Roles.Contains(role1)) score = rnd.Next(90, 100);
            if (user.Roles.Contains(role2)) score = rnd.Next(60, 80);
            if (user.Roles.Contains(role3)) score = rnd.Next(10, 60);
            if (user.Roles.Contains(role4)) score = rnd.Next(00, 10);

            await ReplyAsync($"I rate {user.Mention} {score}/100");
        }


    }
}
