using System.Data;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface ITeam
    {
        int AddTeam(TeamObject team);
        int DeleteTeam(int teamId);
        int UpdateTeam(TeamObject team);
        TeamObject ViewTeam(int teamId);
        DataTable GetTeam();
    }
}
