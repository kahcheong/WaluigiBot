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
    public class waaa : ModuleBase<SocketCommandContext>
    {

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("", ref argPos) )
            {
                await PingAsync();

            }
        }

        public async Task PingAsync()
        {
            await ReplyAsync("Waaa");
        }

    }
}

