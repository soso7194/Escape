using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public UnityEngine.UI.Button[] levelButtons;
    public GameObject[] lockIcons;

    void Start()
    {
        InitFirstTime();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isUnlocked = PlayerPrefs.GetInt("LevelCleared_" + i, 0) == 1;
            levelButtons[i].interactable = isUnlocked;
            lockIcons[i].SetActive(!isUnlocked);
        }
    }

    void InitFirstTime()
    {
        if (!PlayerPrefs.HasKey("Initialized"))
        {
            PlayerPrefs.SetInt("LevelCleared_0", 1);
            PlayerPrefs.SetInt("Initialized", 1);
            PlayerPrefs.Save();
        }
    }
}

