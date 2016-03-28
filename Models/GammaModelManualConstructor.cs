﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gamma.Models
{
    public partial class GammaEntities : DbContext
    {
        public GammaEntities(string connection)
            : base(connection)
        {
#if DEBUG
            this.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
#endif
        }
    }
}
