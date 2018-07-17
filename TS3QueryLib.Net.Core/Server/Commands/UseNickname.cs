using TS3QueryLib.Net.Core.Common.Commands;

namespace TeamspeakWebserver.Utils.Vendor.TS3QueryLib.Net.Core.Server.Commands
{
    public class UseNickname : ExecutableValuelessCommand
    {
        public UseNickname(string nickname) : base("clientupdate")
        {
            AddParameter("client_nickname", nickname);
        }
    }
}
