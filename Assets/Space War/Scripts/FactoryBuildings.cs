using UnityEngine;

public class FactoryBuildings
{
    public GameObject Create(CardDataSO card, Vector3 position)
    {
        return GameObject.Instantiate(card.Building, position, Quaternion.identity);
    }
}
