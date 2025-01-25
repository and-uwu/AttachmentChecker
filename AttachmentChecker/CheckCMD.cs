using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentChecker
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CheckCMD : ICommand
    {
        public string Command => "checkattachment";

        public string[] Aliases { get; } = {"checkatt", "chkatt"};

        public string Description => "Check attachments on weapon";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(!sender.CheckPermission(PlayerPermissions.PlayersManagement))
            {
                response = "Permission denied";
                return false;
            }
            if (!Player.TryGet(sender, out Player player))
            {
                response = "You are not player";
                return false;
            }
            if (player.CurrentItem is not Firearm firearm)
            {
                response = "You don't have firearm";
                return false;
            }
            StringBuilder stb = new();
            stb.Append("Attachments:\n");
            foreach (AttachmentIdentifier attachment in firearm.AttachmentIdentifiers)
            {
                stb.Append($"Name - {attachment.Name.ToString()}\nSlot - {attachment.Slot.ToString()}\n\n");
            }
            response = stb.ToString();
            return true;
        }
    }
}
