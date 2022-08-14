using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyBFS
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> ConnectedNodes { get; set; } = new List<Node>();
        public int Distance { get; set; }
        public bool IsVisited { get; set; }
    }

    public class Graph
    {
        public List<Node> Nodes { get; set; }=new List<Node>();
    }

    internal class Program
    {
        static List<string> VisitedNodes = new();

        static void Main(string[] args)
        {
            Node Bucharest = new Node { Name = "Bucharest", Distance = 0 };
            Node Girgui = new Node { Name = "Girgui", Distance = 77 };
            Node Urzecini = new Node { Name = "Urzecini", Distance = 80 };
            Node Fagaras = new Node { Name = "Fagaras", Distance = 178 };
            Node Pitesti = new Node { Name = "Pitesti", Distance = 98 };
            Node Sibiu = new Node { Name = "Sibiu", Distance = 253 };
            Node Rimnicu = new Node { Name = "Rimnicu", Distance = 193 };

            Bucharest.ConnectedNodes.Add(Girgui);
            Bucharest.ConnectedNodes.Add(Urzecini);
            Bucharest.ConnectedNodes.Add(Fagaras);
            Bucharest.ConnectedNodes.Add(Pitesti);

            Girgui.ConnectedNodes.Add(Bucharest);

            Urzecini.ConnectedNodes.Add(Bucharest);

            Fagaras.ConnectedNodes.Add(Bucharest);
            Fagaras.ConnectedNodes.Add(Sibiu);

            Pitesti.ConnectedNodes.Add(Bucharest);
            Pitesti.ConnectedNodes.Add(Rimnicu);

            Rimnicu.ConnectedNodes.Add(Pitesti);
            Rimnicu.ConnectedNodes.Add(Sibiu);

            Sibiu.ConnectedNodes.Add(Fagaras);
            Sibiu.ConnectedNodes.Add(Rimnicu);

            Graph graph = new Graph();
            graph.Nodes.Add(Bucharest);
            graph.Nodes.Add(Girgui);
            graph.Nodes.Add(Urzecini);
            graph.Nodes.Add(Fagaras);
            graph.Nodes.Add(Pitesti);
            graph.Nodes.Add(Sibiu);
            graph.Nodes.Add(Rimnicu);


            var currNode = graph.Nodes.FirstOrDefault(a => a.Name == "Sibiu");

            do
            {
                VisitedNodes.Add(currNode.Name);

                currNode = currNode.ConnectedNodes.OrderBy(a => a.Distance).FirstOrDefault();

            } while (currNode.Name != "Bucharest");

            VisitedNodes.Add(currNode.Name);

            Console.WriteLine($"Nearest visited node : {String.Join(", ", VisitedNodes.Select(a => a))} ");
        }

        
    }
}
