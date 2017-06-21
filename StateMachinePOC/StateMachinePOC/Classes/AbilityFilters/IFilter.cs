using StateMachinePOC.Classes.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.AbilityFilters
{
    interface IFilter
    {
        List<ICommand> filter(List<ICommand> commands);
    }
}
