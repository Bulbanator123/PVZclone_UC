using UnityEngine;

public class UICardPanel : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private UICard cardPrefab;

    [SerializeField]
    private Transform content;

    private UICard _currentSelect;

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
        if (_currentSelect == card)
        {
            return;
        }
        
        if (_currentSelect != null)
        {
            _currentSelect.Unselect();
        }

        _currentSelect = card;
        _currentSelect.Select();    
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
