using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Satasupe
{
  class Program
  {
    private DiscordSocketClient _client;
    public static CommandService _commands;
    public static IServiceProvider _services;

    static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

    public async Task MainAsync()
    {
      _client = new DiscordSocketClient(new DiscordSocketConfig
      {
        LogLevel = LogSeverity.Info
      });
      _client.Log += Log;
      _commands = new CommandService();
      _services = new ServiceCollection().BuildServiceProvider();
      _client.MessageReceived += CommandRecieved;
      //次の行に書かれているstring token = "hoge"に先程取得したDiscordTokenを指定する。
      string token = "ODE0Mjg2NTg0NTA5MTA0MTc4.YDbpeg.1NJ1ktjboTNCLYlrn8jIwuiHYw8";
      await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
      await _client.LoginAsync(TokenType.Bot, token);
      await _client.StartAsync();

      await Task.Delay(-1);
    }

    /// <summary>
    /// 何かしらのメッセージの受信
    /// </summary>
    /// <param name="msgParam"></param>
    /// <returns></returns>
    private async Task CommandRecieved(SocketMessage messageParam)
    {
      var message = messageParam as SocketUserMessage;

      //デバッグ用メッセージを出力
      Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);
      //メッセージがnullの場合
      if (message == null)
        return;

      //発言者がBotの場合無視する
      if (message.Author.IsBot)
        return;
      var id = message.Author.Id;

      var context = new CommandContext(_client, message);

      //ここから記述--------------------------------------------------------------------------
      var CommandContext = message.Content;
      // コマンド("!I")かどうか判定：情報
      if (CommandContext.Substring(0, 2) == "!I")
      {

        if (CommandContext.Substring(2) == "")
        {
          await message.Channel.SendMessageAsync("情報");
        }
        //情報イベント
        if (CommandContext.Substring(2) == "E")
        {

        }
        //情報ファンブル
        else if (CommandContext.Substring(2) == "H")
        {

        }
      }

      // コマンド("!B")かどうか判定：命中ファンブル表
      if (CommandContext.Substring(0, 2) == "!B")
      {

        if (CommandContext.Substring(2) == "")
        {
          await message.Channel.SendMessageAsync("命中ファンブル表");
        }

        if (CommandContext.Substring(2) == "F")
        {

        }

      }

      // コマンド("!M")かどうか判定：致命傷表
      if (CommandContext.Substring(0, 2) == "!M")
      {

        if (CommandContext.Substring(2) == "")
        {
          await message.Channel.SendMessageAsync("致命傷表");
        }

        if (CommandContext.Substring(2) == "14")
        {

        }

      }

      // コマンド("!M")かどうか判定：競争アクシデント表
      if (CommandContext.Substring(0, 2) == "!C")
      {

        if (CommandContext.Substring(2) == "")
        {
          await message.Channel.SendMessageAsync("競争アクシデント表");
        }

        if (CommandContext.Substring(2) == "A")
        {

        }
      }

      // コマンド("!M")かどうか判定：ロマンスファンブル表
      if (CommandContext.Substring(0, 2) == "!R")
      {

        if (CommandContext.Substring(2) == "")
        {
          await message.Channel.SendMessageAsync("ロマンスファンブル表");
        }

        if (CommandContext.Substring(2) == "F")
        {

        }
      }
    }

    private Task Log(LogMessage message)
    {
      Console.WriteLine(message.ToString());
      return Task.CompletedTask;
    }
  }
}