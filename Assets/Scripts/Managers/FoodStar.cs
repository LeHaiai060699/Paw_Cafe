using UnityEngine;
using UnityEngine.UI;

public class FoodStar : MonoBehaviour
{
    public int currentStarLevel = 1; // Số sao hiện tại
    public Image[] starImages; // Hình ảnh sao
    public Sprite starFilled; // Hình ảnh sao đã được điền
    public Sprite starEmpty; // Hình ảnh sao trống

    void Start()
    {
        // Khởi tạo số sao ban đầu
        UpdateStars(5);
    }

    // Hàm cập nhật số sao
    public void UpdateStars(int level)
    {   
        currentStarLevel = level;

        for (int i = 0; i < starImages.Length; i++)
        {
            if (i < currentStarLevel)
                starImages[i].sprite = starFilled;
            else
                starImages[i].sprite = starEmpty;
            
            starImages[i].gameObject.SetActive(true); // Hiển thị sao từ đầu
        }
    }
}
