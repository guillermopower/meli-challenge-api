﻿using meli_challenge_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meli_challenge_business
{
    public interface IStatsBusiness
    {
        IStatsServiceResponse GetStatistics();
    }
}
