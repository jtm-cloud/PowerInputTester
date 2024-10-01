using PowerInputTester.Hardware.Models;
using System.Collections.Generic;

namespace PowerInputTester.Hardware.Abstract
{
    public enum SettingReadType
    {
        None,
        Boolean,
        BooleanList,
        Byte,
        ByteList,
        Double,
        DoubleList,
        Float,
        FloatList,
        Integer,
        IntegerList,
        Long,
        LongList,
        String,
        StringList
    }
    public interface ISetting
    {
        bool Disabled { get; set; }
        string Name { get; }
        ICollection<SettingChangeTrigger> PreTriggers { get; }
        bool ReadAllRequired { get; }
        string ReadCommand { get; }
        SettingReadType ReadType { get; }
        string SetCommand { get; }
        ICollection<SettingChangeTrigger> PostTriggers { get; }
        object Value { get; set; }
    }
}
