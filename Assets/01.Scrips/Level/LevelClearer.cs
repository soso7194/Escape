using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LevelClearer : MonoBehaviour
{
    private int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = GetLevelIndexFromSceneName();
    }

    public void SaveClear()
    {
        // ���� ���� Ŭ���� ����
        PlayerPrefs.SetInt("LevelCleared_" + currentLevelIndex, 1);

        // ���� ���� ����
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

        // "Level5" �� 5
        Match match = Regex.Match(sceneName, @"Level(\d+)");
        if (match.Success)
        {
            int sceneNumber = int.Parse(match.Groups[1].Value);
            return sceneNumber - 1; // �ε����� 0���� ����
        }

        Debug.LogWarning("�� �̸����� ���� �ε����� ã�� ���߽��ϴ�. �⺻�� 0 ���");
        return 0;
    }
}
