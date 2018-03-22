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
    [Group("waa")]
    public class waaa : ModuleBase<SocketCommandContext>
    {
        [Command("me")]
        public async Task PingMe()
        {
            var builder = new EmbedBuilder();

            builder.WithThumbnailUrl("https://media.discordapp.net/attachments/379380070457802786/426246189722107914/waluigi-th.png");

            await Context.Channel.SendMessageAsync("", false, builder);
        
        }
        [Command("1")]
        public async Task Ping1()
        {
            var builder = new EmbedBuilder();

            builder.WithThumbnailUrl("https://www.youtube.com/watch?v=kabCb292eLM");

            await Context.Channel.SendMessageAsync("", false, builder);

        }

        [Command("at")]
        public async Task PingUser(SocketGuildUser user)
        {

            await ReplyAsync($"WAAAAAAH!!! {user.Mention}");
        }

        [Command("kick"), RequireBotPermission(GuildPermission.KickMembers)]
        public async Task PingAsync(SocketGuildUser user)
        {
            await user.KickAsync();
            await ReplyAsync($"Begone Thot!");
        }

        [Command("emoji")]
        public async Task PingAsync()
        {

            await ReplyAsync(":rage:");
        }



    }
}

