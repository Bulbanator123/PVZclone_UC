using UnityEngine;

public class UICardPanel : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private UICard cardPrefab;

    [SerializeField]
    private Transform content;

    public UICard CurrentSelect {get; private set;}

    #endregion


    #region LifeCycle

    private void Start()
    {
        Clear();
        FillPanel();
    }

    #endregion

    #region PublicMethods

    public void FillPanel()
    {
        for (int i = 0; i < GridWorld.Instance.Deck.Cards.Length; i++)
        {
            var card = Instantiate(cardPrefab, content);
            card.Initialize(GridWorld.Instance.Deck.Cards[i]);
            card.OnClick += Card_OnClick;
        }
        
    }
    #endregion

    #region PrivateMethods

    private void Card_OnClick(UICard card)
    {
        if (CurrentSelect == card)
        {
            return;
        }
        
        if (CurrentSelect != null)
        {
            CurrentSelect.UnSelect();
        }

        CurrentSelect = card;
        CurrentSelect.Select();    
    }
    
    private void Clear()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }
    }

    #endregion
}
