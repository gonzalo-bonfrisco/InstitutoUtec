﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Instituto.Providers
{
    public interface INpgSqlProvider
    {
        NpgsqlConnection GetConection();

    }
}
