﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projas.Service.IService
{
    public interface IDapperContext : IDisposable
    {
        IDbConnection Db { get; }
    }
}
