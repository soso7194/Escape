using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class IntroButton : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject readMe;
    [SerializeField] private GameObject pingpong;

    public static bool isSettingOpen = false;
    public static bool isReadMeOpen = false;

    private void Update()
    {
        if (Keyboard.current.ctrlKey.isPressed && Keyboard.current.shiftKey.isPressed && Keyboard.current.rKey.isPressed)
        {
            Debug.Log("Resetting PlayerPrefs...");
            for (int i = 0; i < 11; i++)
                PlayerPrefs.DeleteKey("LevelCleared_" + i);
            PlayerPrefs.DeleteKey("Initialized");
            PlayerPrefs.Save();
        }
    }

    public void StartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void OpenSetting()
    {
        if (isSettingOpen)
        {
            setting.SetActive(false);
            pingpong.SetActive(true);
            isSettingOpen = false;
        }
        else
        {
            if (!isReadMeOpen)
            {
                setting.SetActive(true);
                pingpong.SetActive(false);
                isSettingOpen = true;
            }
        }
    }
    public void OpenReadMe()
    {
        if (isReadMeOpen)
        {
            readMe.SetActive(false);
            isReadMeOpen = false;
        }
        else
        {
            if (!isSettingOpen)
            {
                readMe.SetActive(true);
                isReadMeOpen = true;
            }
        }
    }
}