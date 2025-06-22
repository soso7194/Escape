using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroIn : MonoBehaviour
{
    public void OpenIntro()
    {
        SceneManager.LoadScene("02.Intro");
    }
}
