using UnityEngine;

public class UpgradableAsset : MonoBehaviour
{
    public string upgradeKey; // VD: "blender", "table", "decor_0"
    public Sprite[] levelSprites;
    public int currentLevel = 0;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadLevel();
        UpdateVisual();
    }

    public void Upgrade()
    {
        if (currentLevel < levelSprites.Length - 1)
        {
            currentLevel++;
            SaveLevel();
            UpdateVisual();
        }
    }

    void UpdateVisual()
    {
        if (spriteRenderer != null && currentLevel < levelSprites.Length)
            spriteRenderer.sprite = levelSprites[currentLevel];
    }

    void SaveLevel()
    {
        PlayerPrefs.SetInt("upgrade_" + upgradeKey, currentLevel);
    }

    void LoadLevel()
    {
        currentLevel = PlayerPrefs.GetInt("upgrade_" + upgradeKey, 0);
    }
}
