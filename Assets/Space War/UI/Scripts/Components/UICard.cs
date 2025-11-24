using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UICard : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private Image objectImage;

    [SerializeField]
    private Image selectFrameImage;

    [SerializeField]
    private TextMeshProUGUI costText;

    private Button _button;

    #endregion

    #region Properties
    public CardDataSO Card { get; private set; }

    #endregion

    #region Events

    public event Action<UICard> OnClick;

    #endregion

    #region LifeCycle
    private void Awake()
    {
        _button = GetComponent<Button>();
        selectFrameImage.enabled = false;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickButton);
    }

    #endregion

    #region PublicMethods

    public void Initialize(CardDataSO cardData)
    {
        Card = cardData;
        objectImage.sprite = Card.Sprite;
        costText.text = Card.Cost.ToString();
    }

    public void Select()
    {
        selectFrameImage.enabled = true;
    }

    public void Unselect()
    {
        selectFrameImage.enabled = false;
    }
    #endregion

    #region PrivateMethods

    public void OnClickButton()
    {
        OnClick?.Invoke(this);
    }

    #endregion


}
