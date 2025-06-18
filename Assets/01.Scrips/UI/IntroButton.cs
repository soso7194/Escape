using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroButton : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject readMe;
    [SerializeField] private GameObject pingpong;

    bool isSettingOpen = false;
    bool isReadMeOpen = false;

    public void StartGame()
    {
        SceneManager.LoadScene("02.0-1");
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
    public void OpenCredit()
    {
        if (isReadMeOpen)
        {
            readMe.SetActive(false);
            pingpong.SetActive(true);
            isReadMeOpen = false;
        }
        else
        {
            if (!isSettingOpen)
            {
                readMe.SetActive(true);
                pingpong.SetActive(false);
                isReadMeOpen = true;
            }
        }
    }
}