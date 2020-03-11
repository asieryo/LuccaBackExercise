using System;
using System.Collections.Generic;
using System.Text;

namespace LucaBackExercise.Model
{
    class Conversion
    {
        private String from;
        private String to;
        private double value;

        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public double Value { get => value; set => this.value = value; }

        public Conversion(String from, String to, double value)
        {
            this.From = from;
            this.To = to;
            this.Value = value;
        }
    }
}
