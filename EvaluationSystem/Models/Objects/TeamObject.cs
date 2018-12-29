using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
    public class TeamObject
    {
        private InstructorObject _createdBy;
        private int _maxMember;
        private int _minMember;
        private ClassObject _class;
        private string _teamName;
        private int _teamId;

        public TeamObject()
        {
            this._Class = new ClassObject();
            this.CreatedBy = new InstructorObject();
        }
        public int TeamId { get => _teamId; set => this._teamId = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public ClassObject _Class { get => _class; set => _class = value; }
        public int MinMember { get => _minMember; set => _minMember = value; }
        public int MaxMember { get => _maxMember; set => _maxMember = value; }
        public InstructorObject CreatedBy { get => _createdBy; set => _createdBy = value; }
    }
}
