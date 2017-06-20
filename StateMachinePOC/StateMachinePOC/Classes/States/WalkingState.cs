using StateMachinePOC.Classes.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.States
{
    class WalkingState : IMovementState
    {
        public WalkingState()
        {

        }

        public IMovementState processInput(Dummy dummy, ICommand c)
        {
            c.execute(dummy);

            if (c.commandType() == "StopHorizontal")
            {
                return new StandingState();
            }

            return null;
        }

        public void update(Dummy dummy)
        {

        }

        public void enter(Dummy dummy)
        {
            Console.WriteLine("Entering WalkingState");
        }

        public void exit(Dummy dummy)
        {
            Console.WriteLine("Exiting WalkingState");
        }
    }
}
