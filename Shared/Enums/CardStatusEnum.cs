using System.ComponentModel;

namespace Shared.Enums{
    public enum CardStatusEnum{
        [Description("Ожидает исполнения")]
        Open = 1,
        [Description("Исполнено")]
        Close = 2
    }
}