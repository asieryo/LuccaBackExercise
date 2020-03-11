using LucaBackExercise.Model;
using System;

using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using System.Collections.Generic;
using System.Linq;
using LucaBackExercise.Helpers;

namespace LucaBackExercise
{
    class LuccaDevises
    {
        static void Main(string[] args)
        {
            ExerciseData.GetExerciseData(args);
            // Dictionary to know the equivalences between currency and nodes.
            var currencyNodes = new Dictionary<string, uint>();
            var graph = new Graph<string, string>();

            // Create the graph
            foreach (string currency in ExerciseData.Currencies)
            {
                uint nodeNumber = graph.AddNode(currency);
                currencyNodes.Add(currency, nodeNumber);
            }

            // Join the different nodes in both ways (exercise statement)
            foreach (Conversion conversion in ExerciseData.Conversions)
            {
                graph.Connect(currencyNodes[conversion.From], currencyNodes[conversion.To], 1, "");
                graph.Connect(currencyNodes[conversion.To], currencyNodes[conversion.From], 1, "");
            }

            // Apply Dijkstra
            var result = graph.Dijkstra(currencyNodes[ExerciseData.Objective.FirstCurrency], currencyNodes[ExerciseData.Objective.LastCurrency]);
            // Case no solution
            if (result.IsFounded == false)
            {
                Console.WriteLine("There is no possible way to convert the currencies");
                Console.ReadKey();
                return;
            }
            // Convert to list so it's easier to work with it
            var list = result.GetPath().Cast<uint>().ToList();
            int i = 0;
            double quantityToConvert = ExerciseData.Objective.Amount;
            while (i + 1 < list.Count)
            {
                /**
                    I can do this safely since I know all the values of the map are unique (each value is a node, and there are not two
                    nodes with the same number...) to recover the nodes
                */                
                var firstCurrency = currencyNodes.FirstOrDefault(x => x.Value == list[i]).Key;
                var secondCurrency = currencyNodes.FirstOrDefault(x => x.Value == list[i+1]).Key;
                var conversion = ExerciseData.Conversions.Find(x => x.From == firstCurrency && x.To == secondCurrency);
                // If there is no conversion in this way, there is in the other one.
                if(conversion == null) 
                {
                    conversion = ExerciseData.Conversions.Find(x => x.To == firstCurrency && x.From == secondCurrency);
                    quantityToConvert = quantityToConvert * RoundHelper.Rounder(1/ conversion.Value);
                } else
                {
                    quantityToConvert = quantityToConvert * conversion.Value;
                }

                quantityToConvert = RoundHelper.Rounder(quantityToConvert);
                i++;
            }
            Console.WriteLine(RoundHelper.Rounder(quantityToConvert, 0));
            Console.ReadKey();
        }
    }
}
