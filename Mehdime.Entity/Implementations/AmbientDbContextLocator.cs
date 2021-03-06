﻿/* 
 * Copyright (C) 2014 Mehdi El Gueddari
 * http://mehdi.me
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Data.Entity;

namespace Mehdime.Entity
{
    public class AmbientDbContextLocator : IAmbientDbContextLocator
    {
        public DbContext Get(Type _DbContextType)
        {
            var ambientDbContextScope = DbContextScope.GetAmbientScope();
            return ambientDbContextScope == null ? null : ambientDbContextScope.DbContexts.Get(_DbContextType);
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var ambientDbContextScope = DbContextScope.GetAmbientScope();
            return ambientDbContextScope == null ? null : ambientDbContextScope.DbContexts.Get<TDbContext>();
        }
    }
}