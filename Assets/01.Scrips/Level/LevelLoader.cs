using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int index)
    {
        if (index < 0)
        {
            SceneManager.LoadScene("00.Tilte");
        }
        else if (index == 11)
        {
            SceneManager.LoadScene("03.Ending");
        }
        else
        {
            string sceneName = "Level" + (index + 1);
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
