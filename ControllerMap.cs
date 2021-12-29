using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.Attributes;
using DSharpPlus.Interactivity;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace DiscordXboxController
{
    public static class ControllerTranlator
    {
        //Translates button to xbox360button
        public static object ButtonTranslate(Button b)
        {
            switch (b)
            {
                case Button.Up:
                    return Xbox360Button.Up;
                    break;
                case Button.Down:
                    return Xbox360Button.Down;
                    break;
                case Button.Left:
                    return Xbox360Button.Left;
                    break;
                case Button.Right:
                    return Xbox360Button.Right;
                    break;
                case Button.Start:
                    return Xbox360Button.Start;
                    break;
                case Button.Back:
                    return Xbox360Button.Back;
                    break;
                case Button.LeftThumb:
                    return Xbox360Button.LeftThumb;
                    break;
                case Button.RightThumb:
                    return Xbox360Button.RightThumb;
                    break;
                case Button.LeftShoulder:
                    return Xbox360Button.LeftShoulder;
                    break;
                case Button.RightShoulder:
                    return Xbox360Button.RightShoulder;
                    break;
                case Button.Guide:
                    return Xbox360Button.Guide;
                    break;
                case Button.A:
                    return Xbox360Button.A;
                    break;
                case Button.B:
                    return Xbox360Button.B;
                    break;
                case Button.X:
                    return Xbox360Button.X;
                    break;
                case Button.Y:
                    return Xbox360Button.Y;
                    break;
                case Button.LeftTrigger:
                    return Xbox360Slider.LeftTrigger;
                    break;
                case Button.RightTrigger:
                    return Xbox360Slider.RightTrigger;
                    break;
                default:
                    return null;
                    break;
            }
        }

        /// <summary>
        /// Translates axis into something the virtual controller understands
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static Stick AxisTranslate(Axis A)
        {
            switch (A)
            {
                case Axis.LeftThumb:
                    return new Stick(Xbox360Axis.LeftThumbX, Xbox360Axis.LeftThumbY);
                    break;
                case Axis.RightThumb:
                    return new Stick(Xbox360Axis.RightThumbX, Xbox360Axis.RightThumbY);
                    break;
                default:
                    return new Stick(Xbox360Axis.LeftThumbX, Xbox360Axis.LeftThumbY);
                    break;
            }
        }

        /// <summary>
        /// Converts direction to vector2
        /// </summary>
        /// <param name="dir">Direction to convert</param>
        /// <returns></returns>
        public static Vector2 DirToV2(Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return new Vector2(0, 1);
                    break;
                case Direction.Down:
                    return new Vector2(0, -1);
                    break;
                case Direction.Left:
                    return new Vector2(-1, 0);
                    break;
                case Direction.Right:
                    return new Vector2(1, 0);
                    break;
                default:
                    return new Vector2(0, 0);
                    break;
            }
        }

        /// <summary>
        /// Converts direction to vector2 plus a tilt value
        /// </summary>
        /// <param name="dir">Direction</param>
        /// <param name="tilt">Stick tilt amount</param>
        /// <returns></returns>
        public static Vector2 DirToV2(Direction dir, float tilt)
        {
            switch (dir)
            {
                case Direction.Up:
                    return new Vector2(0, tilt);
                    break;
                case Direction.Down:
                    return new Vector2(0, -tilt);
                    break;
                case Direction.Left:
                    return new Vector2(-tilt, 0);
                    break;
                case Direction.Right:
                    return new Vector2(tilt, 0);
                    break;
                default:
                    return new Vector2(0, 0);
                    break;
            }
        }
    }
    /// <summary>
    /// Defines all buttons on controller
    /// </summary>
    public enum Button
    {
        [ChoiceName("Up")]
        Up,
        [ChoiceName("Down")]
        Down,
        [ChoiceName("Left")]
        Left,
        [ChoiceName("Right")]
        Right,
        [ChoiceName("Start")]
        Start,
        [ChoiceName("Back")]
        Back,
        [ChoiceName("Left Thumbstick")]
        LeftThumb,
        [ChoiceName("Right ThumbStick")]
        RightThumb,
        [ChoiceName("Left Shoulder")]
        LeftShoulder,
        [ChoiceName("Right Shoulder")]
        RightShoulder,
        [ChoiceName("Guide button")]
        Guide,
        [ChoiceName("A button")]
        A,
        [ChoiceName("B button")]
        B,
        [ChoiceName("X Button")]
        X,
        [ChoiceName("Y Button")]
        Y,
        [ChoiceName("Left Trigger")]
        LeftTrigger,
        [ChoiceName("Right Trigger")]
        RightTrigger,
    }

    /// <summary>
    /// Defines sticks on controller
    /// </summary>
    public enum Axis
    {
        [ChoiceName("Left Stick")]
        LeftThumb,
        [ChoiceName("Right stick")]
        RightThumb,
    }

    /// <summary>
    /// Defines directions
    /// </summary>
    public enum Direction
    {
        [ChoiceName("Up")]
        Up,
        [ChoiceName("Down")]
        Down,
        [ChoiceName("Left")]
        Left,
        [ChoiceName("Right")]
        Right,
    }

    /// <summary>
    /// Defines a controller stick with both axes
    /// </summary>
    public struct Stick
    {
        Xbox360Axis x;
        Xbox360Axis y;

        public Stick(Xbox360Axis x, Xbox360Axis y)
        {
            this.x = x;
            this.y = y;
        }

        public Xbox360Axis X { get => x; set => x = value; }
        public Xbox360Axis Y { get => y; set => y = value; }
    }

    /// <summary>
    /// Simple controller stick vector 2, using a short as value
    /// </summary>
    public struct Vector2
    {
        short x;
        short y;

        public Vector2(float x, float y)
        {
            this.x = (short)(Math.Clamp(x, -1, 1) * 32767);
            this.y = (short)(Math.Clamp(y, -1, 1) * 32767);
        }

        public short X { get => x; set => x = value; }
        public short Y { get => y; set => y = value; }
    }
}
