using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Clear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        Time.timeScale = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log("Next Scene Index: " + nextSceneIndex);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
