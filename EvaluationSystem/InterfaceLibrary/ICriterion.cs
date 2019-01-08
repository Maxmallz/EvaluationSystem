using System.Data;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface ICriterion
    {
        int AddCriterion(CriterionObject criterion);
        int DeleteCriterion(int criteriaId);
        int UpdateCriterion(CriterionObject criterion);
        CriterionObject ViewCriterion(int criterionId);
        DataTable GetCriterion();
    }
}
