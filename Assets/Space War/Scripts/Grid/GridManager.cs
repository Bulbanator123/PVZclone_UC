using UnityEngine;

public class GridManager : MonoBehaviour
{   

    #region Fields
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Vector3 gridOrigin = Vector3.zero;
    [SerializeField]
    private Plane gridplane = new Plane(Vector3.forward, new Vector3(0, 0, 0));

    public Plane GridPlane => gridplane;
    #endregion


    #region  Properties
    [field: SerializeField]
    public Vector3 Pos { get; private set; } = new Vector3(0, 0, 0);
    [field: SerializeField]
    public Vector2Int GridSize { get; private set; } = new Vector2Int(9, 5);

    [field: SerializeField]
    public float CellSize { get; private set; } = 1;

    public Cell[] Cells { get; private set; }

    #endregion


    #region LifeCycle
    private void OnValidate()
    {
        Initialize();
    }
    [ContextMenu("DebugGetCell")]
    public void DebugGetCell()
    {
        if (TryGetCellByWorldPosition(Pos, out var cell))
        {
            Debug.Log(cell.WorldPosition);
            cell.Select();
        }
        else
        {
            Debug.Log("Не Ячейка!");
        }
    }
    #endregion

    #region PublicMethods
    public bool TryGetCellByWorldPosition(Vector3 worldPosition, out Cell cell)
    {
        cell = null;

        int x = Mathf.FloorToInt((worldPosition.x - gridOrigin.x) / CellSize);
        int y = Mathf.FloorToInt((worldPosition.z - gridOrigin.z) / CellSize);
        
        if (x < 0 || y < 0)
            return false;

        if (x >= GridSize.x)
            return false;

        if (y >= GridSize.y)
            return false;
        
        var index = GetLineIndex(x, y);

        if (index < 0)
            return false;

        if (index >= Cells.Length)
            return false;

        cell = Cells[index];
        return true;
    }

    public bool TryGetCellByMousePosition(Vector3 mousePostion, out Cell cell)
    {
        cell = null;
        var ray = _camera.ScreenPointToRay(mousePostion);
        Debug.DrawRay(mousePostion, ray.direction, Color.red);
        if (gridplane.Raycast(ray, out var enter))
        {
            var point = ray.GetPoint(enter);

            return TryGetCellByWorldPosition(point, out cell);
        }

        return false;
    }
    #endregion


    #region  PrivateMethods
    private void Start()
    {
        _camera = Camera.main;
    }
    [ContextMenu("GridInit")]
    private void Initialize()
    {
        Cells = new Cell[GridSize.x * GridSize.y];
        Vector3 offset = Vector3.zero;
        offset.y = gridOrigin.y;

        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                offset.x = gridOrigin.x + (x * CellSize) + (CellSize / 2);
                offset.z = gridOrigin.z + (y * CellSize) + (CellSize / 2);

                var index = GetLineIndex(x, y);
                var cell = new Cell(index, offset, CellSize);

                Cells[index] = cell;
            }
        }
        gridplane = new Plane(Vector3.down, gridOrigin);
    }
    private int GetLineIndex(int x, int y)
    {
        return (x * GridSize.y) + y;
    }
    #endregion
    
    #region Debug
    private void OnDrawGizmos()
    {
        if (Cells == null)
            return;

        if (Cells.Length <= 0)
            return;

        for (int i = 0; i < Cells.Length; i++)
        {
            var cell = Cells[i];
            cell.DebugDrawGizmos();
        }
    }
    #endregion
}
