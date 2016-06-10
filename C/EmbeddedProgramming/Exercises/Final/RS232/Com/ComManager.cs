using System;
using System.IO;
using System.IO.Ports;

namespace ComPort
{
    class ComManager
    {
        SerialPort comIO;
        byte[] nBuffer;
        int nSize;

        public delegate void DataReceivedHandler(byte[] nData);
        public event DataReceivedHandler DataReceived;

        public ComManager()
        {
            comIO = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            comIO.DataReceived += new SerialDataReceivedEventHandler(ComDataReceived);
            comIO.Encoding = System.Text.Encoding.ASCII;
            comIO.Open();

            DataReceived = new DataReceivedHandler(DataReceivedProc);
        }

        private void DataReceivedProc(byte[] nData)
       {
         
        }

        public void Write(byte[] nData)
        {
            comIO.Write(new byte[] { (byte)nData.Length }, 0, 1);
            comIO.Write(nData, 0, nData.Length);
            comIO.Write(new byte[] { 0xFF }, 0, 1);
        }

        byte[] ReadAllBytes()
        {
            byte[] n = new byte[comIO.BytesToRead];
            for (int i = 0; i < n.Length; i++)
                n[i] = (byte)comIO.ReadByte();
            return n;
        }

        void ComDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] n = ReadAllBytes();

            if (n.Length == 0)
                return;

            int i = 0;

            if (nBuffer == null)
            {
                nBuffer = new byte[n[i++]];
                nSize = 0;
            }

            while (i < n.Length && nSize < nBuffer.Length)
                nBuffer[nSize++] = n[i++];

            if (i < n.Length && n[i] == 0xFF)
            {
                if (nSize == nBuffer.Length)
                    DataReceived((byte[])nBuffer.Clone());
                nBuffer = null;
                i++;
            }

            if (i < n.Length)
            {
                nBuffer = new byte[n[i++]];
                nSize = 0;
                while (i < n.Length && nSize < nBuffer.Length)
                    nBuffer[nSize++] = n[i++];
            }
        }
    }
}
