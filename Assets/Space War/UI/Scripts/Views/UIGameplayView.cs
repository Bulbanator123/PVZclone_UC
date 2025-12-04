using UnityEngine;

public class UIGameplayView : UIView
{
    #region Fields
    [SerializeField]
    private UICardPanel uICardPanel;

    #endregion

    #region PublicMethods
    public CardDataSO GetSelectedCard()
    {
        if (uICardPanel.CurrentSelect != null)
        {
            return uICardPanel.CurrentSelect.Card;
        }
        return null;
    }
    #endregion
}
