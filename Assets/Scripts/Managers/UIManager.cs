using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject Popup_Staff;
    public GameObject Popup_Menu;
    public GameObject Popup_Build;
    public GameObject Popup_Tasks;

    void Awake()
    {
        Debug.Log($"UIManager parent: {(transform.parent == null ? "ROOT" : "NOT ROOT")}");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TogglePanel(GameObject panel)
    {
        bool isActive = panel.activeSelf;
        CloseAllPanels();
        panel.SetActive(!isActive);
    }

    public void CloseAllPanels()
    {
        Popup_Staff?.SetActive(false);
        Popup_Menu?.SetActive(false);
        Popup_Build?.SetActive(false);
        Popup_Tasks?.SetActive(false);
    }

    public void OnStaffsButton() => TogglePanel(Popup_Staff);
    public void OnMenuButton() => TogglePanel(Popup_Menu);
    public void OnBuildButton() => TogglePanel(Popup_Build);
    public void OnTasksButton() => TogglePanel(Popup_Tasks);
    public void OnCreateButton() => SceneManager.LoadScene("Scene_Create");
    public void OnMergeButton() => SceneManager.LoadScene("Scene_Merge");
}
