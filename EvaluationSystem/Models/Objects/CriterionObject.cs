using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class CriterionObject
    {
        private int _criteriaId;
        private string _criteriaName;
        private string _description;
        private RubricObject _rubric;

        public CriterionObject()
        {
            this.Rubric = new RubricObject();
        }
        public int CriteriaId { get => _criteriaId;}
        public string CriteriaName { get => _criteriaName; set => _criteriaName = value; }
        public string Description { get => _description; set => _description = value; }
        public RubricObject Rubric { get => _rubric; set => _rubric = value; }
    }
}
