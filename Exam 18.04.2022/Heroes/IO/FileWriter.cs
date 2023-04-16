using Heroes.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Heroes.IO
{
    internal class FileWriter : IWriter
    {
        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
