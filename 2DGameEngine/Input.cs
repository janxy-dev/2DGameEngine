using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2DGameEngine
{
    public enum MouseTrigger
    {
        None,
        RightClick,
        LeftClick,
        RightRelease,
        LeftRelease,
    }

    public enum MouseDown
    {
        None,
        Right,
        Left
    }
    public static class Input
    {
        private static MouseState prevMouseState;
        private static Keys prevDownKey;

        private static KeyboardState keyboardState;
        private static KeyboardState prevKeyboardState;
        #region MOUSE

        private static MouseTrigger mouseButtonState;
        private static MouseState mouseState;
        public static Point MousePosition
        {
            get
            {
                return new Point(mouseState.Position.X, mouseState.Position.Y);
            }
        }
        public static bool IsMouseTriggered(MouseTrigger state)
        {
            mouseButtonState = 0;
            // Check if the mouse position is inside the rectangle
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton != ButtonState.Pressed)
            {
                mouseButtonState = MouseTrigger.LeftClick;
            }
            if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton != ButtonState.Released)
            {
                mouseButtonState = MouseTrigger.LeftRelease;
            }
            if (mouseState.RightButton == ButtonState.Pressed && prevMouseState.RightButton != ButtonState.Pressed)
            {
                mouseButtonState = MouseTrigger.RightClick;
            }
            if (mouseState.RightButton == ButtonState.Released && prevMouseState.RightButton != ButtonState.Released)
            {
                mouseButtonState = MouseTrigger.RightRelease;
            }
            return state == mouseButtonState;
        }

        public static bool IsMouseDown(MouseDown state)
        {
            if (state == MouseDown.Left)
            {
                return mouseState.LeftButton == ButtonState.Pressed;
            }
            if (state == MouseDown.Right)
            {
                return mouseState.RightButton == ButtonState.Pressed;
            }
            return false;
        }

        #endregion

        public static void GetState()
        {
            if (!RenderContext.Game.IsActive) return; //change later
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

        }

        public static bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && !prevKeyboardState.IsKeyDown(key);
        }

        public static bool IsKeyReleased(Keys key)
        {
            if (IsKeyDown(key))
            {
                prevDownKey = key;
            }
            if (prevDownKey == key && !IsKeyDown(key))
            {
                prevDownKey = Keys.None;
                return true;
            }
            return false;
        }
    }
}