﻿using AquaShop.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AquaShop.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", false))
            {
                writer.WriteLine(string.Empty);
            }
        }
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
