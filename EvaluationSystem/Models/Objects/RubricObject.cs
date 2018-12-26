using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class RubricObject
    {
        private int _rubricId;
        private string _rubricName;
        private int _minGrade;
        private int _maxGrade;
        private int _averageGrade;
        private int _maxCriteria;
        private ClassObject _class;

        public RubricObject()
        {
            this.Class = new ClassObject();
        }
        public int RubricId { get => _rubricId; set => _rubricId = value; }
        public string RubricName { get => _rubricName; set => _rubricName = value; }
        public int MinGrade { get => _minGrade; set => _minGrade = value; }
        public int MaxGrade { get => _maxGrade; set => _maxGrade = value; }
        public int AverageGrade { get => _averageGrade; set => _averageGrade = value; }
        public int MaxCriteria { get => _maxCriteria; set => _maxCriteria = value; }
        public ClassObject Class { get => _class; set => _class = value; }
    }
}
