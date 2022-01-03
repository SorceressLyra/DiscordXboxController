# Discord Xbox Controller
This is a self-hosted bot that acts as a a regular Xbox 360 controller on the host PC.

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/A0A71V8FT)

## How do I use it?
The bot itself operates through slash commands in discord, every button an xbox 360 controller has, the bot has!
![image](https://user-images.githubusercontent.com/20424962/147700100-be59187a-bf08-452d-abcc-0fcf3b1a12a6.png)

The commands have a few parameters: `/button button:X Button Duration:2`


The thumbsticks are accessed through `/axis axis direction duration strength` where you define which stick and direction furthermore optionally the duration and tilt

While it is not implemented yet, I plan to add a button limiter to allow you to disable things such as the start button and such so people won't quit the game for you.

## Notes about this software
* You need to host this bot yourself, which also need you need to create a bot in the [Discord Developer Portal](https://discord.com/developers/applications)
* I do not take responsiblity of any problems this can cause on your device, this has only been tested on a relatively small scale and I'm not super familar with Discord bots nor ViGem

## What do I use it for?
This tool is perfect for streams such as 'Twitch Plays Pokemon' but where you want to very directly limit whose in control, i.e. a discord community! I intend to make it possible to set a role limit or channel limit on it in the future.

## How do I set up the bot?
### Where do I add my token?
When you have created a discord application and bot you need to add your token to the bot, luckily you don't need to touch any code for this.

All you have to do is to go to your appdata\roaming, add a folder called BotToken and then add your token in there saved within a txt file, the software will automatically grab the token from there.

`C:\Users\USER\AppData\Roaming\BotToken\token.txt`

### What permissions should the Bot have?
![image](https://user-images.githubusercontent.com/20424962/147699936-e0315e01-de61-4c24-886e-70be17fada91.png)


## What is coming?
[check milestones for more ](https://github.com/Wizard-Jo/DiscordXboxController/milestones)
