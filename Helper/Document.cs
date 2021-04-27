using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A827141.Actividad03.Helper
{
    public class Document
    {
        public static string ReadTextFromFile(string fileName)
        {
            string filePath = System.IO.Path.Combine(
                System.IO.Directory.GetCurrentDirectory(),
                "data", fileName);

            return System.IO.File.ReadAllText(filePath);
        }
    }
}