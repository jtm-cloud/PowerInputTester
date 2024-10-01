using CommonHelpers.GuardClauses;
using Ivi.Visa;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Models;
using System;
using System.Text;
using System.Windows;

namespace PowerInputTester.Hardware.Controls
{
    public class InstrumentInfoFactory
    {
        #region MyRegion
        SerialPortConfigFactory _serialConfigFactory;
        InstrumentTypeResolver _instrumentTypeResolver;
        #endregion
        public InstrumentInfoFactory()
        {
            _serialConfigFactory = new SerialPortConfigFactory();
            _instrumentTypeResolver = new InstrumentTypeResolver();
        }
        public InstrumentInfo Create(IResourceManager manager, string address)
        {
            GuardClause.NullReference(manager, "manager");
            GuardClause.EmptyString(address, "address");

            ParseResult parseResult = manager.Parse(address);
            GuardClause.NullReference(parseResult, "parseResult");

            if (parseResult.InterfaceType == HardwareInterfaceType.Serial)
            {
                SerialPortConfig config = _serialConfigFactory.Create(manager, address);

                if (config != null)
                {
                    SerialSession session = (SerialSession)manager.Open(address, AccessModes.None, 500);
                    session.BaudRate = config.BaudRate;
                    session.DataBits = config.DataBits;
                    session.StopBits = config.StopBits;
                    session.FlowControl = config.FlowControl;
                    session.ReadTermination = SerialTerminationMethod.TerminationCharacter;
                    session.WriteTermination = SerialTerminationMethod.TerminationCharacter;
                    return ExtractDeviceInfo(session, address, parseResult, config);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                MessageBasedSession session = (MessageBasedSession)manager.Open(address, AccessModes.None, 500);
                return ExtractDeviceInfo(session, address, parseResult);
            }
        }
        private InstrumentInfo ExtractDeviceInfo(IMessageBasedSession session, string address, ParseResult parseResult,
                                                        SerialPortConfig serialConfig = null)
        {
            string responseString = null;
            InstrumentInfo info = null;
            try
            {

                session.TerminationCharacter = 0x0a;
                session.TerminationCharacterEnabled = true;

                session.RawIO.Write(Encoding.ASCII.GetBytes("*IDN?"));
                string buffer = session.RawIO.ReadString();
                session.Dispose();

                string noTermChar = buffer.Replace(((char)10).ToString(), "");
                responseString = noTermChar.Trim('"');
            }
            catch (VisaException ve)
            {
                MessageBox.Show(ve.InnerException.Message, ve.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message, e.Message);
            }
            finally
            {
                GuardClause.EmptyString(responseString, "responseString");

                string[] splitString = responseString.Split(',');
                InstrumentType instrumentType = _instrumentTypeResolver.Resolve(splitString[0], splitString[1]);

                info = new InstrumentInfo(address,
                                          parseResult.InterfaceType,
                                          instrumentType,
                                          splitString[0],
                                          splitString[1],
                                          splitString[2],
                                          splitString[3],
                                          serialConfig);
            }

            GuardClause.NullReference(info, "info");
            return info;
        }
    }
}
