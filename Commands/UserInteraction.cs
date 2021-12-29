using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace DiscordXboxController
{
    public class UserInteraction : ApplicationCommandModule
    {
        [SlashCommand("Button", "Sends a button command directly to the host PC")]
        public async Task ButtonCommand(InteractionContext ctx, [Option("Button", "Which controller button do you want to press?")] Button button = Button.A, [Option("Duration", "How long to press the button?")] double duration = 0.2f)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            //Recalulate durating into milliseconds
            int actualDuration = Convert.ToInt32(duration * 1000);
            actualDuration = Math.Clamp(actualDuration, 0, 5000);

            //Send Response
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"**{button.GetName()}** is being pressed for **{MathF.Round((float)duration * 10.0f) * 0.1f} seconds**"));

            //Send command to virtual controller
            await Program.ButtonSend(ControllerTranlator.ButtonTranslate(button), actualDuration);
        }

        [SlashCommand("Axis", "Sends an axis command directly to the host PC")]
        public async Task AxisCommand(InteractionContext ctx, [Option("Axis", "Which controller axis do you want to press?")] Axis axis, [Option("Direction", "Which direction do you want to move")] Direction dir, [Option("Duration", "How long to hold the axis?")] double duration = 0.2f, [Option("Strength", "How far the stick will be tilted from 0 to 1")] double tilt = 1f)
        {
            await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

            //Recalulate durating into milliseconds
            int actualDuration = Convert.ToInt32(duration * 1000);
            actualDuration = Math.Clamp(actualDuration, 0, 5000);

            //Send response
            await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"**{axis.GetName()}** is being held **{dir.GetName()}** for **{MathF.Round((float)duration * 10.0f) * 0.1f} seconds** with **{Convert.ToInt32(tilt * 100)}% tilt**"));

            //Send command to virtual controller
            await Program.AxisSend(ControllerTranlator.AxisTranslate(axis), ControllerTranlator.DirToV2(dir, (float)tilt), actualDuration);
        }
    }

    
}
