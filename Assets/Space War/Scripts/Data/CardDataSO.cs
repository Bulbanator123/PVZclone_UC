using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/Card")]
public class CardDataSO : ScriptableObject
{
    [field: SerializeField]
    public string Name {get; private set; } = "Name";

    [field: SerializeField]
    public int Cost { get; private set; } = 2;

    [field: SerializeField]
    public Sprite Sprite{ get; private set; } 

    [field: SerializeField]
    public GameObject Building {get; private set;}
}
