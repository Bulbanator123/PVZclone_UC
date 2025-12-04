using UnityEngine;

[RequireComponent (typeof(CanvasGroup))]
public abstract class UIView : MonoBehaviour
{
    [SerializeField]
    private bool isHideOnStart = true;

    protected CanvasGroup _canvasGroup;

    public bool IsVisiable {get; protected set;}

    protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ViewsManager.Register(this);

        if (isHideOnStart)
            Hide();
    }

    protected virtual void OnDestroy()
    {
        ViewsManager.UnRegister(this);
    }

    public virtual void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        IsVisiable = true;
    }

    public virtual void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        IsVisiable = false;
    }
}
