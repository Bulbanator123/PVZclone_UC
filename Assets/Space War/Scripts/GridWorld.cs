using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GridWorld : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private GameObject cubePrefab;

    #endregion

    #region Properties

    public static GridWorld Instance {get; private set;}
    
    public float BankValue = 10f;
    [field: SerializeField]
    public DeckSO Deck {get; private set;}    
    [field: SerializeField]
    public GridManager GridManager { get; private set; }

    [field: SerializeField]
    public PlaceableSystem PlaceableSystem { get; private set; }

    public FactoryBuildings FactoryBuildings { get; private set; }

    #endregion

    #region LifeCycle

    private void Awake()
    {
        Instance = this;
        FactoryBuildings = new();
        PlaceableSystem.Initialize(FactoryBuildings, GridManager);
    }

    #endregion

    #region PrivateMethods

    private void Update()
    {
        BankValue += 10 * Time.deltaTime;
        if (BankValue > 10000)
        {
            BankValue = 10000;
        }
    }

    #endregion

}