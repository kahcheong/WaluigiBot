﻿using System;
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

            if (message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);

            }
        }

    }
}
