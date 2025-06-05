using UnityEngine;
using TMPro;  // TextMeshPro nếu bạn dùng

public class NameTagUI : MonoBehaviour
{
    public TMP_InputField nameInputField;     // <-- Text hiện tên Player
    public TMP_Text starText;   // <-- Text hiện Level Player

    void Start()
    {
        LoadName();
        UpdateUI();
    }
    public void LoadName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        nameInputField.text = playerName;
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("PlayerName", nameInputField.text);
        PlayerPrefs.Save(); // Save ngay
    }
    public void UpdateUI()
    {
        starText.text = PlayerData.Instance.playerLevel.ToString();
    }
}

