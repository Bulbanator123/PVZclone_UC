using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Cards/Deck")]
public class DeckSO : ScriptableObject
{
    [field: SerializeField]
    public CardDataSO[] Cards {get; private set;}
}
