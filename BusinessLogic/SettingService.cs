using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Logging;

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

        public SettingsDto SaveSettings(SettingsDto newData)
        {
            var res = _settingsRepo.AddSettings(new Settings{
                DeadlineTimeSpanInMiliseconds = newData.DeadlineTimeSpanInMiliseconds,
                DoNotDisturbTimeSpanInMiliseconds = newData.DeadlineTimeSpanInMiliseconds,
                PanicTimeSpanInMiliseconds = newData.PanicTimeSpanInMiliseconds,
                StartPanicForTimeSpanInMiliseconds = newData.StartPanicForTimeSpanInMiliseconds
            });
            return new SettingsDto(res);
        }

        public SettingsDto GetSettings()
        {
            var data = _settingsRepo.GetSettings();
            return data != null ?  new SettingsDto(data): null;            
        }
    }
}