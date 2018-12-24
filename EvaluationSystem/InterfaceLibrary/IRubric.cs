using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IRubric
    {
        int AddRubric(RubricObject rubric);
        int DeleteRubric(RubricObject rubric);
        int UpdateRubric(RubricObject rubric);
        RubricObject ViewRubric(int rubricId);
    }
}
