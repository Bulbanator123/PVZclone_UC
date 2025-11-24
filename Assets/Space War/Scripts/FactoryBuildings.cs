using UnityEngine;

public class FactoryBuildings
{
    private GameObject _cubePrefab;
    public FactoryBuildings(GameObject cubePrefab)
    {
        _cubePrefab = cubePrefab;
    }
    public GameObject Create(Vector3 position)
    {
        return GameObject.Instantiate(_cubePrefab, position, Quaternion.identity);
    }
}
