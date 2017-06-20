using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.Command
{
    class StopHorizontalCommand : ICommand
    {
        public void execute(Dummy dummy)
        {

        }

        public string commandType()
        {
            return "StopHorizontal";
        }
    }
}
