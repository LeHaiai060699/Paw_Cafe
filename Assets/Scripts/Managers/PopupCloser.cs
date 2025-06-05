using UnityEngine;
using UnityEngine.SceneManagement;
public class PopupCloser : MonoBehaviour
{
    public GameObject backgroundDim;
    public GameObject currentPopup;

    public void ShowPopup(GameObject popup)
    {
        backgroundDim.SetActive(true);
        popup.SetActive(true);
        currentPopup = popup;
    }

    public void HideCurrentPopup()
    {
        if (currentPopup != null)
        {
            currentPopup.SetActive(false);
            currentPopup = null;
        }
        backgroundDim.SetActive(false);
    }

    public void OnBackgroundClicked()
    {
        HideCurrentPopup();
    }
}
