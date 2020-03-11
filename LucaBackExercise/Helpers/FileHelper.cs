using LucaBackExercise.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LucaBackExercise.Helpers
{
    class FileHelper
    {
        // Function to split a line on ';' separator
        public static String[] SplitLine(String line)
        {
            return line.Split(';');
        }
    }
}
