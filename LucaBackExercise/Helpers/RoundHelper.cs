using System;

namespace LucaBackExercise.Helpers
{
    class RoundHelper
    {
        // Function to round in 4 decimals if nothing else is specified
        public static double Rounder(double toRound, int decimals = 4)
        {
            return Math.Round(toRound, decimals);
        }
    }
}
