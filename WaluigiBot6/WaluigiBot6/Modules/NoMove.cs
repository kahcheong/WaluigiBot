using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WaluigiBot6.Modules
{
    [Group("no")]
    public class NoMove : ModuleBase<SocketCommandContext>
    {
        [Command("way")]
        public async Task No()
        {
            var builder = new EmbedBuilder();

            builder.WithTitle("No");
            builder.WithThumbnailUrl("http://s2.quickmeme.com/img/f7/f7a5e5acfc5e88de76b775a8866a1fb2fcf1b64ba05c28da6be3d45e9a8cf1c3.jpg");


            builder.WithColor(Color.Red);
            await Context.Channel.SendMessageAsync("", false, builder);
        }

        [Command("u")]
        public async Task Nou()
        {
            var builder = new EmbedBuilder();

            builder.WithTitle("No u");
            builder.WithThumbnailUrl("https://media.discordapp.net/attachments/379380070457802786/421866017732427776/d8339f3.jpg?width=321&height=468");
            builder.WithColor(Color.Red);

            await Context.Channel.SendMessageAsync("", false, builder);
            
            
        }




    }
}
