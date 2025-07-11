using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OpenSetting : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    private void Start()
    {
        settingsMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                settingsMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ExitButton()
    {
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("00.Tilte");
    }
}
