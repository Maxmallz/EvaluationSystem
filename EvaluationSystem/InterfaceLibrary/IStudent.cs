﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Objects;

namespace InterfaceLibrary
{
    public interface IStudent:IAssessment, IReport
    {
        int MakeAssessment(AssessmentObject assessment);
    }
}
