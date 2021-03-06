﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IInstructor:ITeam, IAssessment, IReport,ICriterion
    {
        int AddStudentToTeam(string studentId, int teamId);
        int RemoveStudentFromTeam(string studentId, int teamId);
        int AddStudentToClass(string studentId, int classId);
        int RemoveStudentFromClass(string studentId, int classId);
    }
}
