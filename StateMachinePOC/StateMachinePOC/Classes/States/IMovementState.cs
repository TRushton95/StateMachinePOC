using StateMachinePOC.Classes.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.States
{
    interface IMovementState
    {
        IMovementState processInput(Dummy dummy, ICommand c);
        void update(Dummy dummy);
        void enter(Dummy dummy);
        void exit(Dummy dummy);
    }
}
