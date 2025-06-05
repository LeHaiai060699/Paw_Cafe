using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int playerLevel = 1; // 🎯 Level ban đầu

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ qua scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
