﻿using Allin.SharedCore.Configurations;

namespace Allin.Admin.Infrastructure.Persistence
{
    public abstract class AdminTypeConfiguration<T> : BaseTypeConfiguration<T>
        where T : AdminBaseEntity
    {

    }
}