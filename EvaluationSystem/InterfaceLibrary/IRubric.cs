using System.Data;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IRubric
    {
        int AddRubric(RubricObject rubric);
        int DeleteRubric(RubricObject rubric);
        int UpdateRubric(RubricObject rubric);
        RubricObject ViewRubric(int rubricId);
        DataTable GetRubric();
    }
}
