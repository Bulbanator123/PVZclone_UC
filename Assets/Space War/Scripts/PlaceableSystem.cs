using UnityEngine;

public class PlaceableSystem : MonoBehaviour
{
    private Vector3 mousePos = new(0, 0, 0);
    [SerializeField]
    private GridManager _gridManager;
    [SerializeField]
    private FactoryBuildings _factoryBuildings;
    
    [SerializeField]
    private Cell _currentCell = null;
    private bool _isInitialized = false;
    private void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        if (!_isInitialized) { return; }

        if (!_gridManager.TryGetCellByMousePosition(mousePos, out var cell))
        {
            return;
        }

        if (_currentCell != null)
        {
            if (_currentCell == cell) return;

            _currentCell.Deselect();
        }

        _currentCell = cell;
        _currentCell.Select();
    }

    private void Update()
    {
        if (!_isInitialized) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            // _factoryBuildings.Create(_currentCell.WorldPosition);
        }
    }

    #region PublicMethods

    
    public void Initialize(FactoryBuildings factoryBuildings, GridManager gridManager)
    {
        _factoryBuildings = factoryBuildings;
        _gridManager = gridManager;

        _isInitialized = true;
    }


    #endregion
}
