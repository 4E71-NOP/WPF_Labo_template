using Labo_template.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_template.agents
{
    public static class Msg
    {
        private static bool debugConsole = true;
        private static ApplicationGlobalVariables agv = ApplicationGlobalVariables.GetInstance;

        public static void Publication(string msg)
        {
            agv.PsbLabelMessage = msg;
            if (debugConsole) { Console.Out.WriteLine(msg); }
        }
    }
}
