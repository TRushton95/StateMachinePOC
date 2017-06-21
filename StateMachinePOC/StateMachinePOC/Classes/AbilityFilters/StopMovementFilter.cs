using StateMachinePOC.Classes.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.AbilityFilters
{
    class StopMovementFilter : IFilter
    {
        public List<ICommand> filter(List<ICommand> commands)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i].commandType() == "MoveLeft") {
                    commands[i] = new NullCommand();
                }
                else if (commands[i].commandType() == "MoveRight")
                {
                    commands[i] = new NullCommand();
                }
            }

            return commands;
        }
    }
}
