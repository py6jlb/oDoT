using System;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;

namespace DataAccess.Repositories{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly LiteDbContext _context;

        public SettingsRepository(LiteDbContext context) => _context = context;

        public Settings GetSettings()
        {
            var data = _context.Settings.FindOne(x=> true);
            return data;
        }

        public Settings AddSettings(Settings newData)
        {
            var id = _context.Settings.Insert(newData);
            var data = _context.Settings.FindById(id);
            return data;
        }
    }
}