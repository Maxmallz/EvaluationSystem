using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface ICriterion
    {
        int AddCriterion(CriterionObject criterion);
        int DeleteCriterion(int criteriaId);
        int UpdateCriterion(CriterionObject criterion);
        CriterionObject ViewCriterion(int criterionId);
    }
}
