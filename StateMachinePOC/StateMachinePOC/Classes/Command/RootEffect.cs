using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StateMachinePOC.Classes.Command
{
    class RootEffect : ICommand
    {
        Timer timer;
        Dummy dummy;

        public RootEffect()
        {
        }

        public void execute(Dummy dummy)
        {
            this.dummy = dummy;
            timer = new Timer(new TimerCallback(expire));
            timer.Change(1000, 0);
            Console.WriteLine("\n++++++++++++\nSlow started\n++++++++++++");
        }

        public void expire(object state)
        {
            Timer t = (Timer)state;
            t.Dispose();
            Console.WriteLine("\n++++++++++++\nSlow ended\n++++++++++++");

        }

        public string commandType()
        {
            return "Slow";
        }
    }
}
