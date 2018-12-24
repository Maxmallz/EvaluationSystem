using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace Models.Objects
{
    public class FeedbackObject
    {
        public enum FeedbackStatus { NoActionTaken = 0, Disapproved = 1, Approved = 2,}
        public FeedbackObject()
        {
            _status = new FeedbackStatus();
            _assessmentId = new AssessmentObject();
        }
        private int _feedbackId;
        private string _description;
        private AssessmentObject _assessmentId;
        private FeedbackStatus _status;

        public int FeedbackId { get => _feedbackId; set => _feedbackId = value; }
        public string Description { get => _description; set => _description = value; }
        public AssessmentObject AssessmentId { get => _assessmentId; set => _assessmentId = value; }
        public FeedbackStatus Status { get => _status; set => _status = value; }
    }
}
