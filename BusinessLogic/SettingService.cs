using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Logging;
using Shared.Helpers;

namespace BusinessLogic{

    public class SettingsService : ISettingsService
    {
        private readonly ILogger<SettingsService> _logger;
        private readonly ISettingsRepository _settingsRepo;
        public SettingsService(
            ILogger<SettingsService> logger, 
            ISettingsRepository settingsRepo
        ){
            _logger = logger;
            _settingsRepo = settingsRepo;
        }

        
    }
}