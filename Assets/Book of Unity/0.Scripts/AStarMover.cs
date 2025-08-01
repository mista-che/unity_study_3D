using System.Collections.Generic;
using UnityEngine;

public class AStarMover : MonoBehaviour
{
    private Transform start, end;
    public GameObject start_cube, end_cube;
    public Node start_node, end_node;

    public List<Node> path = new List<Node>();

    private void Start()
    {
        GetPath();
    }

    void GetPath()
    {
        start = start_cube.transform;
        end = end_cube.transform;

        // get start and end
        int start_index = GridManager.Instance.GetGridIndex(start.position);
        int start_row = GridManager.Instance.GetRow(start_index);
        int start_col = GridManager.Instance.GetColumn(start_index);
        start_node = GridManager.Instance.cells[start_row, start_col];

        int end_index = GridManager.Instance.GetGridIndex(end.position);
        int end_row = GridManager.Instance.GetRow(end_index);
        int end_col = GridManager.Instance.GetColumn(end_index);
        end_node = GridManager.Instance.cells[end_row, end_col];

        // grab start to end from AStar, our calculator class
        path = AStar.FindPath(start_node, end_node);
    }

    private void OnDrawGizmos()
    {
        if (path == null) return;

        if (path.Count > 0)
        {
            int index = 1;
            foreach (Node node in path)
            {
                if (index < path.Count)
                {
                    Node next = path[index];
                    Debug.DrawLine(node.position, next.position, Color.blue);
                    index++;
                }
            }
        }
    }
}
