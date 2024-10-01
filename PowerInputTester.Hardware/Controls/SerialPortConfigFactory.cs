using CommonHelpers.GuardClauses;
using Ivi.Visa;
using NationalInstruments.Visa;
using PowerInputTester.Hardware.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PowerInputTester.Hardware.Controls
{
    public class SerialPortConfigFactory
    {
        public SerialPortConfig Create(IResourceManager manager, string address)
        {
            GuardClause.NullReference(manager, "manager");
            GuardClause.EmptyString(address, "address");

            SerialPortConfig serialConfig = null;

            bool connected = false;
            ICollection<int> baudRates = GenerateBaudRateList();
            SerialSession serialSession = (SerialSession)manager.Open(address);
            serialSession.TimeoutMilliseconds = 2000;
            serialSession.TerminationCharacter = 0x0a;
            serialSession.TerminationCharacterEnabled = false;
            serialSession.ReadTermination = SerialTerminationMethod.TerminationCharacter;
            serialSession.WriteTermination = SerialTerminationMethod.TerminationCharacter;

            foreach (int baudRate in baudRates)
            {
                try
                {
                    serialSession.BaudRate = baudRate;
                    connected = TryConnect(serialSession);
                }
                catch(VisaException ve)
                {
                    string message = ve.Message;
                    break;
                }
                if (connected)
                {
                    serialConfig = new SerialPortConfig(baudRate);
                    break;
                }
            };

            serialSession.Dispose();
            if(serialConfig != null)
            {
                return serialConfig;
            }
            else
            {
                return null;
            }

        }
        private bool TryConnect(SerialSession serialSession)
        {
            GuardClause.NullReference(serialSession, "serialSession");
            try
            {
                serialSession.RawIO.Write(Encoding.ASCII.GetBytes("*IDN?"));
                string buffer = serialSession.RawIO.ReadString();

                string noTermChar = buffer.Replace(((char)10).ToString(), "");
                string responseString = noTermChar.Trim('"');

                GuardClause.EmptyString(responseString, "responseString");
                return true;
            }
            catch (VisaException ve)
            {
                string message = ve.Message;
                return false;
            }
            catch(Exception e)
            {
                string message = e.Message;
                return false;
            }
        }
        private ICollection<int> GenerateBaudRateList()
        {
            ICollection<int> baudRates = new Collection<int>()
            {
                460800, 230400, 115200, 57600, 38400, 19200,
                9600, 4800, 2400, 1200, 600, 300
            };
            return baudRates;
        }
    }
}
