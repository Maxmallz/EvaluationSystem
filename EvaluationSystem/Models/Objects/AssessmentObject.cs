using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class AssessmentObject
    {
        private int _assessmentId;
        private StudentObject _doneBy;
        private StudentObject _doneFor;
        private int _totalValue;
        private TeamObject _team;
        private ClassObject _class;
        private string _feedback;

        public AssessmentObject()
        {
            this.DoneBy = new StudentObject();
            this.DoneFor = new StudentObject();
            this.Team = new TeamObject();
            this._Class = new ClassObject();
        }
        public int AssessmentId { get => _assessmentId; }
        public StudentObject DoneBy { get => _doneBy; set => _doneBy = value; }
        public StudentObject DoneFor { get => _doneFor; set => _doneFor = value; }
        public int TotalValue { get => _totalValue; set => _totalValue = value; }
        public TeamObject Team { get => _team; set => _team = value; }
        public ClassObject _Class { get => _class; set => _class = value; }
        public string Feedback { get => _feedback; set => _feedback = value; }
    }
}
