using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Abstraction{
    public interface ISettingsService{
        SettingsDto GetSettings();
        SettingsDto SaveSettings(SettingsDto newData);
    }
}