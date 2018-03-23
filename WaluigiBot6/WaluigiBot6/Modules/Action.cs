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
    
    public class Action : ModuleBase<SocketCommandContext>
    {

        [Command("slap")]
        public async Task Slap(SocketGuildUser user)
        {
            var builder = new EmbedBuilder();

            builder.WithTitle($"{user.Username}, you got a slap from {Context.User.Username}");
            builder.WithThumbnailUrl("https://cdn.weeb.sh/images/S1lf3XkKvW.gif");
            builder.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, builder);

        }
    }
}
