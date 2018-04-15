using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using Discord.Rest;
using System.Runtime.Remoting.Contexts;
//using DiscordSharp;

namespace WaluigiBot6
{
    class Program
    {
        public static void Main(String[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();


        public DiscordSocketClient _client;
        public CommandService _commands;
        public IServiceProvider _services;
        private static CommandService commands;

        public async Task RunBotAsync()
        {
      
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string botToken = ("NDI1ODQzMDY1NTg0ODc3NTg5.DZNoxQ.Q57aLFydxv5nYxf5-y45XFihScs");

            //event subscripttion
            _client.Log += Log;
            _client.UserJoined += AnnounceUserJoined;

            await RegisterCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, botToken);

            await _client.StartAsync();

            await Task.Delay(-1);

        }


        private async Task AnnounceUserJoined(SocketGuildUser user)
        {
            var guild = user.Guild;
            var channel = guild.DefaultChannel;
            await channel.SendMessageAsync($"waa off, {user.Mention}");
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                
                if (message.HasStringPrefix("waa", ref argPos)) 
                {
                    await message.DeleteAsync();
                }

                //await ReplyAsync($":hellagay:");
                if (message.Channel.Name.Equals("hella-gay"))
                {

                    if (message.HasStringPrefix("<:hellagay:434842057693986826>", ref argPos)) await message.Channel.SendMessageAsync("<:nou:434842867031212032>");
                    else if (message.HasStringPrefix("<:nou:434842867031212032>", ref argPos)) await message.Channel.SendMessageAsync("<:mirrorforce:434843712582057984>");
                    else if (message.HasStringPrefix("<:mirrorforce:434843712582057984>", ref argPos))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            await message.Channel.SendMessageAsync($"<:waah:434842362896842764>" + " " + "<:waah:434842362896842764>" + " " 
                                + "<:waah:434842362896842764>" + " " + "<:waah:434842362896842764>" + " " + "<:waah:434842362896842764>" );
                        }
                    }
                    else await message.Channel.SendMessageAsync("<:hellagay:434842057693986826>");
                    
                }
                else if (message.Channel.Name.Equals("☭kommunist-ussr☭"))
                {
                    //if (message.HasStringPrefix("i", ref argPos) || message.Content.Contains(" i ") || message.Content.Contains(" I ")
                    //|| message.Content.Contains("I ") || message.Content.Contains(".we ") || message.Content.Contains(" we ")
                    // || message.Content.Contains("We ") || message.Content.Contains(".We ")) await message.Channel.SendMessageAsync("We*");
                    String temp12 = message.Content.Replace("i'm", "we're").Replace("I'm", "We're").Replace("I'M", "WE'RE").Replace("i", "we")
                        .Replace("I", "We").Replace("my", "our").Replace("My", "Our").Replace("MY", "Our")
                        .Replace("me", "us").Replace("Me", "Us").Replace("ME", "US");
                    String temp13 = message.Content.Replace("food", "").Replace("hungry", "");
                    if (!temp13.Equals(message.Content)) await message.Channel.SendMessageAsync("In to the gulag with you.");
                    else if (!temp12.Equals(message.Content)) await message.Channel.SendMessageAsync(temp12 + "*");
                    await message.Channel.SendMessageAsync("<:communism:434847529629253634>");
                }

            }
        }

    }
}
