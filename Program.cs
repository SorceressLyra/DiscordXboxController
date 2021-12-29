using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace DiscordXboxController
{
    public class Program
    {
        internal static IXbox360Controller controller;

        static void Main(string[] args)
        {
            //Set up virtual controller
            ViGEmClient client = new ViGEmClient();
            controller = client.CreateXbox360Controller();
            controller.Connect();

            while (true)
            {
                MainAsync().GetAwaiter().GetResult();
            }

        }

        //Connect to the discord servers
        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = JoWorks.Data.AppdataStorage.ReadFromAppdata("BotToken", "token.txt"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var commands = discord.UseSlashCommands();
            commands.RegisterCommands<UserInteraction>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        //Sends button to controller
        public static async Task ButtonSend(object button, int duration)
        {
            if(button is Xbox360Button newButton)
            {
                controller.SetButtonState(newButton, true);
                await Task.Delay(duration);
                controller.SetButtonState(newButton, false);
            }
            else if(button is Xbox360Slider newSlider)
            {
                controller.SetSliderValue(newSlider, 255);
                await Task.Delay(duration);
                controller.SetSliderValue(newSlider, 0);
            }
        }

        //Sends axis to controller
        public static async Task AxisSend(Stick axis, Vector2 direction, int duration)
        {
            controller.SetAxisValue(axis.X, direction.X);
            controller.SetAxisValue(axis.Y, direction.Y);
            await Task.Delay(duration);
            controller.SetAxisValue(axis.X, 0);
            controller.SetAxisValue(axis.Y, 0);
        }
    }
}
