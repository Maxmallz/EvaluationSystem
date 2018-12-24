using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface ITeam
    {
        int AddTeam(TeamObject team);
        int DeleteTeam(TeamObject team);
        int UpdateTeam(TeamObject team);
        TeamObject ViewTeam(int teamId);
    }
}
