using PowerInputTester.Hardware.Models;
using PowerInputTester.Hardware.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonHelpers.GuardClauses;

namespace PowerInputTester.Hardware.Controls
{
    public class CIPowerSupplyOptionsFactory
    {
        public SettingOptions Create(string settingName)
        {
            GuardClause.EmptyString(settingName, "settingName");

            switch (settingName)
            {
                case "OutputNumber":
                    return CreateOutputNumberOptions();
                case "OutputMode":
                    return CreateOutputModeOptions();
                case "OutputCoupling":
                    return CreateOutputCouplingOptions();
                case "WaveformShape":
                    return CreateWaveformShapeOptions();
                case "ClipLevel":
                    return CreateClipLevelOptions();
                default:
                    return null;
            }
        }
        private SettingOptions CreateOutputNumberOptions()
        {
            ICollection<SettingOption> options = new Collection<SettingOption>()
            {
                new SettingOption("ONE", "OutputNumber"),
                new SettingOption("THREE", "OutputNumber")
            };
            return new SettingOptions("OutputNumber",
                                      true,
                                      null,
                                      SettingReadType.String,
                                      options);
        }
        private SettingOptions CreateOutputModeOptions()
        {
            ICollection<SettingOption> options = new Collection<SettingOption>()
            {
                new SettingOption("AC", "OutputMode"),
                new SettingOption("DC", "OutputMode"),
                new SettingOption("ACDC", "OutputMode")
            };
            return new SettingOptions("OutputMode",
                                      true,
                                      null,
                                      SettingReadType.String,
                                      options);
        }
        private SettingOptions CreateOutputCouplingOptions()
        {
            ICollection<SettingOption> options = new Collection<SettingOption>()
            {
                new SettingOption("NONE", "OutputCoupling"),
                new SettingOption("ALL", "OutputCoupling")
            };
            return new SettingOptions("OutputCoupling",
                                      true,
                                      null,
                                      SettingReadType.String,
                                      options);
        }
        private SettingOptions CreateWaveformShapeOptions()
        {
            return new SettingOptions("WaveformShape",
                                      false,
                                      "TRAC:CAT?",
                                      SettingReadType.String,
                                      null);
        }
        private SettingOptions CreateClipLevelOptions()
        {
            ICollection<SettingOption> options = new Collection<SettingOption>()
            {
                new SettingOption("1", "ClipLevel"),
                new SettingOption("2", "ClipLevel"),
                new SettingOption("3", "ClipLevel"),
                new SettingOption("4", "ClipLevel"),
                new SettingOption("5", "ClipLevel"),
                new SettingOption("6", "ClipLevel"),
                new SettingOption("7", "ClipLevel"),
                new SettingOption("8", "ClipLevel"),
                new SettingOption("9", "ClipLevel"),
                new SettingOption("10", "ClipLevel"),
                new SettingOption("11", "ClipLevel"),
                new SettingOption("12", "ClipLevel"),
                new SettingOption("13", "ClipLevel"),
                new SettingOption("14", "ClipLevel"),
                new SettingOption("15", "ClipLevel"),
                new SettingOption("16", "ClipLevel"),
                new SettingOption("17", "ClipLevel"),
                new SettingOption("18", "ClipLevel"),
                new SettingOption("19", "ClipLevel"),
                new SettingOption("20", "ClipLevel")
            };
            return new SettingOptions("ClipLevel",
                                      true,
                                      null,
                                      SettingReadType.String,
                                      options);
        }
    }
}
