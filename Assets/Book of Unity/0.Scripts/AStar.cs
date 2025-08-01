using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    public static PriorityQueue open_list;
    public static PriorityQueue closed_list;

    private static float HeuristicEstimateCost(Node current, Node goal)
    {
        Vector3 cost = current.position - goal.position;

        return cost.magnitude;
    }

    public static List<Node> FindPath(Node start, Node end)
    {
        open_list = new PriorityQueue();
        open_list.Push(start);

        start.node_total_cost = 0f;
        start.estimated_cost = HeuristicEstimateCost(start, end);

        closed_list = new PriorityQueue();
        Node node = null;

        while (open_list.Length != 0)
        {
            node = open_list.First();
            open_list.Remove(node);


            if (node.position == end.position)
            {
                return CalculatePath(node);
            }

            List<Node> neighbors = new List<Node>();
            GridManager.Instance.GetNeighbors(node, neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Node neighbor = neighbors[i];

                // if neighbor has not been visited yet
                if (!closed_list.Contains(neighbor))
                {
                    float cost = HeuristicEstimateCost(node, neighbor);
                    float total_cost = node.node_total_cost + cost;

                    float neighbor_est_cost = HeuristicEstimateCost(neighbor, end);

                    neighbor.node_total_cost = total_cost;
                    neighbor.parent = node;
                    neighbor.estimated_cost = total_cost + neighbor_est_cost;

                    if (!open_list.Contains(neighbor))
                    {
                        open_list.Push(neighbor);
                    }
                }

            }
            closed_list.Push(node);
            // visitable_nodes.Remove(node);
        }

        if (node.position != end.position)
        {
            Debug.LogError("No valid path found.");
            return null;
        }

        return CalculatePath(node);
    }

    private static List<Node> CalculatePath(Node node)
    {
        List<Node> list = new();

        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }

        list.Reverse();

        return list;
    }
}
