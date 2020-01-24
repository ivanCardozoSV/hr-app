﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Contracts.DeclineReason
{
    public class ReadedDeclineReasonContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
