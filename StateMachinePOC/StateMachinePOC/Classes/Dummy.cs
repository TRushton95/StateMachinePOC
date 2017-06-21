using Microsoft.Xna.Framework.Input;
using StateMachinePOC.Classes.AbilityFilters;
using StateMachinePOC.Classes.Command;
using StateMachinePOC.Classes.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes
{
    class Dummy
    {
        public KeyboardState currentKeyboardState { get; set; }
        public KeyboardState previousKeyboardState { get; set; }

        public IMovementState movementState { get; set; }
        public IMovementState newMovementState { get; set; }

        public ICommand KeyDownD { get; set; }
        public ICommand KeyUpD { get; set; }
        public ICommand KeyDownA { get; set; }
        public ICommand KeyUpA { get; set; }
        public ICommand KeyDownP { get; set; }
        public List<ICommand> commands { get; set; }
        public List<ICommand> input { get; set; }

        public IFilter filter { get; set; }

        public Dummy()
        {
            KeyDownD = new MoveLeftCommand();
            KeyUpD = new StopHorizontalCommand();
            KeyDownA = new MoveRightCommand();
            KeyUpA = new StopHorizontalCommand();
            KeyDownP = new RootEffect();

            movementState = new StandingState();
            filter = null; //filter
        }

        public List<ICommand> processInput()
        {
            commands = new List<ICommand>();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyUp(Keys.A) && previousKeyboardState.IsKeyDown(Keys.A))
            {
                commands.Add(KeyUpA);
            }
            if (currentKeyboardState.IsKeyUp(Keys.D) && previousKeyboardState.IsKeyDown(Keys.D))
            {
                commands.Add(KeyUpD);
            }


            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                commands.Add(KeyDownA);
            }
            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                commands.Add(KeyDownD);
            }


            if (currentKeyboardState.IsKeyDown(Keys.P) && previousKeyboardState.IsKeyUp(Keys.P))
            {
                commands.Add(KeyDownP);
            }

            return commands;
        }

        public void update()
        {
            input = processInput();

            if (filter != null) //could use null filter but this is more efficient
            {
                filter.filter(input);
            }

            foreach (ICommand c in input)
            {
                newMovementState = movementState.processInput(this, c);
                if (newMovementState != null)
                {
                    Console.WriteLine("\n-----------\n");
                    movementState.exit(this);
                    movementState = newMovementState;
                    newMovementState.enter(this);
                }
            }

            movementState.update(this);
        }


    }
}
