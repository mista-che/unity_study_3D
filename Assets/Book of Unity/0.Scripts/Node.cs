using System;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Node parent;
    public Vector3 position;

    public float node_total_cost;
    public float estimated_cost;
    public bool is_obstacle;

    public Node()
    {
        parent = null;
        node_total_cost = 0f;
        estimated_cost = 0f;
        is_obstacle = false;
    }

    public Node(Vector3 p)
    {
        this.position = p;
        parent = null;
        node_total_cost = 0f;
        estimated_cost = 0f;
        is_obstacle = false;
    }

    public void MarkAsObstacle()
    {
        is_obstacle = true;
    }

    public float GetFCost()
    {
        return node_total_cost + estimated_cost;
    }

    public int CompareTo(Node node)
    {
        float my_f = GetFCost();
        float other_f = node.GetFCost();

        if (my_f < other_f) return -1;
        if (my_f > other_f) return 1;

        if (estimated_cost < node.estimated_cost) return -1;
        if (estimated_cost > node.estimated_cost) return 1;

        return 0;
    }
}
