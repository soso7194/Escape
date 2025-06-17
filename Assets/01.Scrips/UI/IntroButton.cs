using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroButton : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject pingpong;

    bool isSettingOpen = false;
    bool isCreditOpen = false;

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
            if (!isCreditOpen)
            {
                setting.SetActive(true);
                pingpong.SetActive(false);
                isSettingOpen = true;
            }
        }
    }
    public void OpenCredit()
    {
        if (isCreditOpen)
        {
            credit.SetActive(false);
            pingpong.SetActive(true);
            isCreditOpen = false;
        }
        else
        {
            if (!isCreditOpen)
            {
                credit.SetActive(true);
                pingpong.SetActive(false);
                isCreditOpen = true;
            }
        }
    }
}