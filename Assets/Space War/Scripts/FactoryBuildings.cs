using UnityEngine;

public class FactoryBuildings
{
    private GameObject _cubePrefab;
    
    public FactoryBuildings(GameObject cubePrefab)
    {
        _cubePrefab = cubePrefab;
    }

    public GameObject Create(GameObject ConstructionBuilding, Vector3 position)
    {
        return GameObject.Instantiate(ConstructionBuilding, position, Quaternion.identity);
    }
}
