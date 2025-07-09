using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LevelClearer : MonoBehaviour
{
    private int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = GetLevelIndexFromSceneName();
        void Start()
        {
            Debug.Log("LevelCleared_0: " + PlayerPrefs.GetInt("LevelCleared_0", 0));
            Debug.Log("LevelCleared_1: " + PlayerPrefs.GetInt("LevelCleared_1", 0));
            Debug.Log("Initialized: " + PlayerPrefs.GetInt("Initialized", 0));
        }

    }

    public void SaveClear()
    {
        // 현재 레벨 클리어 저장
        PlayerPrefs.SetInt("LevelCleared_" + currentLevelIndex, 1);

        // 다음 레벨 오픈
        int nextLevel = currentLevelIndex + 1;
        if (nextLevel < 11)
        {
            PlayerPrefs.SetInt("LevelCleared_" + nextLevel, 1);
        }

        PlayerPrefs.Save();
    }

    int GetLevelIndexFromSceneName()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // "Level5" → 5
        Match match = Regex.Match(sceneName, @"Level(\d+)");
        if (match.Success)
        {
            int sceneNumber = int.Parse(match.Groups[1].Value);
            return sceneNumber - 1; // 인덱스는 0부터 시작
        }

        Debug.LogWarning("씬 이름에서 레벨 인덱스를 찾지 못했습니다. 기본값 0 사용");
        return 0;
    }
}
