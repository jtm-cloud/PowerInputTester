using CommonHelpers.GuardClauses;
using NationalInstruments.Visa;
using System;
using System.Text;

namespace PowerInputTester.Hardware.Models
{
    public class InstrumentMessagingBase : IDisposable
    {
        private MessageBasedSession _session;
        public InstrumentMessagingBase(MessageBasedSession session)
        {
            _session = session;
        }

        public void Dispose()
        {
            _session.Dispose();
            _session = null;
        }

        public bool ReadBool()
        {
            string buffer = ReadString();
            GuardClause.NonBoolString(buffer, "buffer");
            return Convert.ToBoolean(buffer);
        }
        public bool[] ReadBoolList()
        {
            string[] buffer = ReadStringList();
            return Array.ConvertAll(buffer, bool.Parse);
        }
        public byte[] ReadByteList()
        {
            return _session.RawIO.Read();
        }
        public double ReadDouble()
        {
            string buffer = ReadString();
            GuardClause.NonDoubleString(buffer, "buffer");
            return Convert.ToDouble(buffer);
        }
        public double[] ReadDoubleList()
        {
            string[] buffer = ReadStringList();
            return Array.ConvertAll(buffer, double.Parse);
        }
        public float ReadFloat()
        {
            string buffer = ReadString();
            GuardClause.NonFloatString(buffer, "buffer");
            return Convert.ToSingle(buffer);
        }
        public float[] ReadFloatList()
        {
            string[] buffer = ReadStringList();
            return Array.ConvertAll(buffer, float.Parse);
        }
        public int ReadInteger()
        {
            string buffer = ReadString();
            GuardClause.NonIntegerString(buffer, "buffer");
            return Convert.ToInt32(buffer);
        }
        public int[] ReadIntegerList()
        {
            string[] buffer = ReadStringList();
            return Array.ConvertAll(buffer, int.Parse);
        }
        public long ReadLong()
        {
            string buffer = ReadString();
            GuardClause.NonLongString(buffer, "buffer");
            return Convert.ToInt64(buffer);
        }
        public long[] ReadLongList()
        {
            string[] buffer = ReadStringList();
            return Array.ConvertAll(buffer, long.Parse);
        }
        public string ReadString()
        {
            string buffer = _session.RawIO.ReadString();
            buffer = buffer.Replace(((char)10).ToString(), "");
            return buffer.Trim('"');
        }
        public string[] ReadStringList()
        {
            char[] delimiterChars = { ',', ';', ':' };
            string buffer = ReadString();
            return buffer.Split(delimiterChars);
        }
        public void Write(string command)
        {
            GuardClause.EmptyString(command, "command");
            _session.RawIO.Write(Encoding.ASCII.GetBytes(command));
        }
    }
}
