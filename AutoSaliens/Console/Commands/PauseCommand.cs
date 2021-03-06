using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS1998

namespace AutoSaliens.Console.Commands
{
    [CommandVerb("pause")]
    internal class PauseCommand : CommandBase
    {
        public override async Task<string> Run(string parameters, CancellationToken cancellationToken)
        {
            if (!Program.Saliens.AutomationActive)
                return "Automation has been paused already.";

            Program.Settings.EnableBot = false;
            Program.Settings.Save();
            Program.Saliens.Stop();

            // Activate checking periodically
            if (Program.Settings.EnableDiscordPresence)
                Program.Presence.CheckPeriodically = true;

            return "Automation has been paused. Use the command resume to unpause.";
        }
    }
}
