using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.Command
{
    interface ICommand
    {
        void execute(Dummy dummy);

        string commandType();
    }
}
