using Unity.VisualScripting;
using UnityEngine;

public class PlaceableSystem : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private GridManager _gridManager;
    [SerializeField]
    private FactoryBuildings _factoryBuildings;
    
    [SerializeField]
    private Cell _currentCell = null;

    [SerializeField]
    private UICardPanel UICardPanel;

    #endregion

    #region Properties
    private bool _isInitialized = false;
    private Vector3 mousePos = new(0, 0, 0);

    UICard _currentselectCard = null;

    #endregion
    private void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        if (!_isInitialized) { return; }

        if (!_gridManager.TryGetCellByMousePosition(mousePos, out var cell))
        {
            if (_currentCell != null)
            {
                _currentCell.Deselect();
                _currentCell = null;
            }
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
        
        if (UICardPanel.IsCurrentSelected())
        {
            _currentselectCard = UICardPanel.GetCurrentSelect();
        }


        if (_currentselectCard != null && _currentCell != null && Input.GetMouseButtonDown(0) && _currentCell.HasBuilding == false &&
         GridWorld.Instance.BankValue >= _currentselectCard.Card.Cost)
        {
            _factoryBuildings.Create(_currentselectCard.Card.Building, _currentCell.WorldPosition);
            _currentCell.Builded();

            GridWorld.Instance.BankValue -= _currentselectCard.Card.Cost;
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
