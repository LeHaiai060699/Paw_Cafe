using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using DG.Tweening; // Import DOTween
public class TabSwitcher : MonoBehaviour
{
    public List<Button> tabButtons;       // Các nút tabs (coffee, drink, dessert)
    public Sprite normalSprite;           // Background thường
    public Sprite activeSprite;           // Background khi chọn
    public Color normalTextColor = new Color(0.4f, 0.2f, 0.1f); // Nâu đậm
    public Color activeTextColor = Color.white; // Trắng

    private float scaleDuration = 0.2f; // thời gian scale
    private float targetScale = 1.1f;   // scale lớn hơn khi active
    void Start()
    {
        // Gắn sự kiện cho tất cả nút
        foreach (Button btn in tabButtons)
        {
            btn.onClick.AddListener(() => SetActiveTab(btn));
        }

        // Set tab đầu tiên active mặc định
        SetActiveTab(tabButtons[0]);
    }

    public void SetActiveTab(Button activeButton)
    {
        foreach (Button btn in tabButtons)
        {
            Image img = btn.GetComponent<Image>();
            TMP_Text tmpText = btn.GetComponentInChildren<TMP_Text>(); // dùng TextMeshPro

            if (btn == activeButton)
            {
                img.sprite = activeSprite;

                // Scale lên 1.1
                btn.transform.DOScale(targetScale, scaleDuration).SetEase(Ease.OutBack);

                // Đổi màu text
                if (tmpText != null)
                    tmpText.DOColor(activeTextColor, scaleDuration);
            }
            else
            {
                img.sprite = normalSprite;

                // Scale về 1
                btn.transform.DOScale(1f, scaleDuration).SetEase(Ease.OutBack);

                // Đổi màu text về normal
                if (tmpText != null)
                    tmpText.DOColor(normalTextColor, scaleDuration);
            }
        }
    }
}
