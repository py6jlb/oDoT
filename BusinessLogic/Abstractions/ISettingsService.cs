using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Abstraction{
    public interface ISettingsService{
        SettingsDto GetSettings();
        SettingsDto AddSettings(SettingsDto newData);
        SettingsDto SaveSettings(SettingsDto newData);
    }
}