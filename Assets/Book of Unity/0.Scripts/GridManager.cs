using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public GameObject[] obstacles;
    public Node[,] cells { get; set; }
    public int row_count;
    public int col_count;
    public float grid_cellsize;
    private float cell_offset;

    private Vector3 origin = new Vector3();
    public Vector3 Origin { get { return origin; } }

    protected override void Awake()
    {
        base.Awake();

        cell_offset = grid_cellsize / 2;

        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        CalculateObstacles();
    }

    private void CalculateObstacles()
    {
        cells = new Node[row_count, col_count];
        int index = 0;

        for (int i = 0; i < col_count; i++) // col first, to go from left to right
        {
            for (int j = 0; j < row_count; j++) // row 2nd, to go from top to bottom
            {
                Vector3 cell_pos = GetCenter(index);
                Node node = new(cell_pos);
                cells[i, j] = node;
                index++;
            }
        }

        if (obstacles != null && obstacles.Length > 0)
        {
            foreach (GameObject obstacle in obstacles)
            {
                int index_cell = GetGridIndex(obstacle.transform.position);
                int row = GetRow(index_cell);
                int col = GetColumn(index_cell);
                cells[row, col].MarkAsObstacle();
            }

        }
    }

    public Vector3 GetCenter(int index)
    {
        Vector3 cell_position = GetCellPosition(index);
        cell_position.x += cell_offset;
        cell_position.z += cell_offset;

        return cell_position;
    }

    public Vector3 GetCellPosition(int index)
    {
        int row = index / col_count;
        int col = index % col_count;
        float x_position = col * grid_cellsize;
        float z_position = row * grid_cellsize;

        return Origin + new Vector3(x_position, 0f, z_position);
    }

    public int GetGridIndex(Vector3 pos)
    {
        if (!IsInBounds(pos)) return -1;

        pos += Origin;

        int col = (int)(pos.x / grid_cellsize);
        int row = (int)(pos.z / grid_cellsize);

        return row * col_count + col;
    }

    public bool IsInBounds(Vector3 pos)
    {
        float width = col_count * grid_cellsize;
        float height = row_count * grid_cellsize;

        return pos.x >= Origin.x && pos.x <= width && pos.z >= Origin.z && pos.z <= height;
    }

    public int GetRow(int index)
    {
        int row = index / col_count;
        return row;
    }

    public int GetColumn(int index)
    {
        int col = index % col_count;
        return col;
    }

    public void GetNeighbors(Node node, List<Node> neighbors)
    {
        int neighbor_index = GetGridIndex(node.position); // ?
        int row = GetRow(neighbor_index);
        int col = GetColumn(neighbor_index);

        // below
        int temp_row = row - 1;
        int temp_col = col;
        AssignNeighbor(temp_row, temp_col, neighbors);

        // above
        temp_row = row + 1;
        temp_col = col;
        AssignNeighbor(temp_row, temp_col, neighbors);

        // left
        temp_row = row;
        temp_col = col - 1;
        AssignNeighbor(temp_row, temp_col, neighbors);

        // above
        temp_row = row;
        temp_col = col + 1;
        AssignNeighbor(temp_row, temp_col, neighbors);
    }

    private void AssignNeighbor(int row, int col, List<Node> neighbors)
    {
        if (row != -1 && col != -1 && row < row_count && col < col_count)
        {
            Node assignee = cells[row, col];
            if (!assignee.is_obstacle)
            {
                neighbors.Add(assignee);
            }
        }
    }

    private void OnDrawGizmos()
    {
        DebugDrawGrid(transform.position, row_count, col_count, grid_cellsize, Color.green);


        /// draws obstacles
        Vector3 cellSize = new Vector3(grid_cellsize, 1f, grid_cellsize);
        if (obstacles != null && obstacles.Length > 0)
        {
            foreach (GameObject data in obstacles)
                Gizmos.DrawCube(GetCenter(GetGridIndex(data.transform.position)), cellSize);
        }

    }

    public void DebugDrawGrid(Vector3 origin, int row_count, int col_count, float cell_size, Color color)
    {
        float width = col_count * cell_size;
        float height = row_count * cell_size;

        for (int i = 0; i < row_count; i++)
        {
            Vector3 start = origin + (i * cell_size * new Vector3(0, 0, 1));
            Vector3 end = start + (width * new Vector3(1, 0, 0));
            Debug.DrawLine(start, end, color);
        }

        for (int i = 0; i <= col_count; i++)
        {
            Vector3 start = origin + (i * cell_size * new Vector3(1, 0, 0));
            Vector3 end = start + (height * new Vector3(0, 0, 1));
            Debug.DrawLine(start, end, color);
        }
    }
}
