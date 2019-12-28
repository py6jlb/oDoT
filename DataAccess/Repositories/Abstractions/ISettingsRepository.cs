using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstractions{
    public interface ISettingsRepository
    {
        Settings GetSettings();
        Settings AddSettings(Settings newData);
    }
}