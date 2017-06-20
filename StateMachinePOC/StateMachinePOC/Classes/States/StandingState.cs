using StateMachinePOC.Classes.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.States
{
    class StandingState : IMovementState
    {
        public StandingState()
        {

        }

        public IMovementState processInput(Dummy dummy, ICommand c)
        {
            c.execute(dummy);

            if (c.commandType() == "MoveLeft" || c.commandType() == "MoveRight")
            {
                return new WalkingState();
            }

            return null;
        }

        public void update(Dummy dummy)
        {

        }

        public void enter(Dummy dummy)
        {
            Console.WriteLine("Entering StandingState");
        }

        public void exit(Dummy dummy)
        {
            Console.WriteLine("Exiting StandingState");
        }
    }
}
