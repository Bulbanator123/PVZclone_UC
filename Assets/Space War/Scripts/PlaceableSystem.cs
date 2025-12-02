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

    #endregion

    #region Properties
    private bool _isInitialized = false;
    private Vector3 mousePos = new(0, 0, 0);

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            ViewsManager.GetView<UIGameplayView>().Show();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ViewsManager.GetView<UIGameplayView>().Hide();
        }

        if (Input.GetMouseButtonDown(0))
        {
            var view = ViewsManager.GetView<UIGameplayView>();
            var selectedCard = view.GetSelectedCard();
            if (_currentCell != null && _currentCell.HasBuilding == false && GridWorld.Instance.BankValue >= selectedCard.Cost)
            {
                return;
            }
            _factoryBuildings.Create(selectedCard, _currentCell.WorldPosition);
            _currentCell.Builded();

            GridWorld.Instance.BankValue -= selectedCard.Cost;
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
