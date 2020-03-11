using System;
using System.Collections.Generic;
using System.Text;

namespace LucaBackExercise.Model
{
    class Objective
    {

        private string firstCurrency;
        private string lastCurrency;
        private int amount;

        public string FirstCurrency { get => firstCurrency; set => firstCurrency = value; }
        public string LastCurrency { get => lastCurrency; set => lastCurrency = value; }
        public int Amount { get => amount; set => amount = value; }

        public Objective(string firstCurrency, string lastCurrency, int amount)
        {
            this.FirstCurrency = firstCurrency;
            this.LastCurrency = lastCurrency;
            this.Amount = amount;
        }
    }
}
