using UnityEngine;
using DG.Tweening;

public class PopupController : MonoBehaviour
{
    [Header("Popup Settings")]
    public CanvasGroup canvasGroup;   // Canvas Group để fade
    public Transform popupContent;    // Nội dung Popup để scale animation

    [Header("Animation Settings")]
    public float animationDuration = 0.3f;
    public Ease openEase = Ease.OutBack;
    public Ease closeEase = Ease.InBack;

    private Vector3 initialScale;

    void Awake()
    {
        // Scale ban đầu sẽ là scale thiết kế
        initialScale = popupContent.localScale;
        popupContent.localScale = Vector3.zero;  // Start hidden
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }

    public void OpenPopup()
    {
        // Mở popup với Scale và Fade
        popupContent.localScale = Vector3.zero;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = true;

        canvasGroup.DOFade(1, animationDuration);
        popupContent.DOScale(initialScale, animationDuration).SetEase(openEase);
    }

    public void ClosePopup()
    {
        // Đóng popup với Scale và Fade
        canvasGroup.blocksRaycasts = false;

        canvasGroup.DOFade(0, animationDuration);
        popupContent.DOScale(Vector3.zero, animationDuration).SetEase(closeEase)
            .OnComplete(() =>
            {
                gameObject.SetActive(false); // Disable sau khi đóng xong
            });
    }

    // Gọi từ Background_Dim Button
    public void OnBackgroundClick()
    {
        ClosePopup();
    }
}