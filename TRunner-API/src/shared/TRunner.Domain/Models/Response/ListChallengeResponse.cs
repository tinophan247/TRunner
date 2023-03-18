﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRunner.Domain.Models.Response
{
    public class ListChallengeResponse
    {
        public List<ChallengeResponse> Challenges { get; set; } = new List<ChallengeResponse>();
        public int TotalRow { get; set; }
    }

    public class ChallengeResponse
    {
        public int ChallengeID { get; set; }

        public int Calories { get; set; }

        public int SplatPoints { get; set; }

        public int AvgHr { get; set; }

        public int MaxHr { get; set; }

        public int Miles { get; set; }

        public int Steps { get; set; }

        public int ClassID { get; set; }
    }
}
