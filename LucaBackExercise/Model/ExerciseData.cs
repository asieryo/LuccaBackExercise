using LucaBackExercise.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace LucaBackExercise.Model
{
    class ExerciseData
    {
        // All the input conversions
        private static List<Conversion> conversions;
        // Object containing the main objective of the program
        private static Objective objective;
        // Different currencies for the problem
        private static HashSet<string> currencies;

        public static List<Conversion> Conversions { get => conversions; set => conversions = value; }
        public static Objective Objective { get => objective; set => objective = value; }
        public static HashSet<string> Currencies { get => currencies; set => currencies = value; }

        public static void GetExerciseData(String[] args)
        {
            Conversions = new List<Conversion>();
            Currencies = new HashSet<string>();

            var input = File.OpenText(args[0]);

            // With the first line we get the objective
            var firstLine = FileHelper.SplitLine(input.ReadLine());
            Objective = new Objective(firstLine[0], firstLine[2], int.Parse(firstLine[1]));

            // With the second line we get the number of iterations
            var SecondLine = input.ReadLine();
            var totalConversions = int.Parse(SecondLine);

            string[] line;
            for (int i = 0; i < totalConversions; i++)
            {
                line = FileHelper.SplitLine(input.ReadLine());
                var firstCurrency = line[0];
                var secondCurrency = line[1];
                Conversions.Add(new Conversion(firstCurrency, secondCurrency, double.Parse(line[2], CultureInfo.InvariantCulture.NumberFormat)));
                Currencies.Add(firstCurrency);
                Currencies.Add(secondCurrency);
            }
        }
    }
}
