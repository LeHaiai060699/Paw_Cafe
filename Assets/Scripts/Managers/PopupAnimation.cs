using UnityEngine;
using DG.Tweening;

public class PopupAnimation : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    [Header("Animation Settings")]
    public float animationDuration = 0.35f; // Thời gian mở/đóng
    public float startScale = 0.7f;          // Scale khi bắt đầu
    public Ease easeType = Ease.OutBack;     // Hiệu ứng Ease

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Gọi khi muốn mở popup
    public void Show()
    {
        gameObject.SetActive(true);

        rectTransform.localScale = Vector3.one * startScale;
        canvasGroup.alpha = 0;

        rectTransform.DOScale(1f, animationDuration).SetEase(easeType);
        canvasGroup.DOFade(1f, animationDuration);
    }

    // Gọi khi muốn đóng popup
    public void Hide()
    {
        rectTransform.DOScale(startScale, animationDuration).SetEase(easeType);
        canvasGroup.DOFade(0f, animationDuration)
            .OnComplete(() => gameObject.SetActive(false));
    }
}
