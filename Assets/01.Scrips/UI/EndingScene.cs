using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] pageTexts;
    [SerializeField] Image fadeImage;

    int pages = 0;
    bool isTransitioning = false;

    void Start()
    {
        SetAllObjectsInactive();
        UpdatePageInstant();
    }

    void OnEnable()
    {
        pages = 0;
        SetAllObjectsInactive();
        UpdatePageInstant();
    }

    void Update()
    {
        if (isTransitioning) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (pages < objects.Length - 1)
            {
                pages++;
                StartCoroutine(FadeAndUpdatePage());
            }
            else if (pages == objects.Length - 1)
            {
                Exit();
            }
        }
    }

    void Exit()
    {
        pages = 0;
        SetAllObjectsInactive();
        gameObject.SetActive(false);
        StartCoroutine(Fade(0f, 1f, 0.3f));
    }

    void SetAllObjectsInactive()
    {
        foreach (var obj in objects)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }

    void UpdatePageInstant()
    {
        if (pages < objects.Length && objects[pages] != null)
            objects[pages].SetActive(true);

        if (pages < pageTexts.Length)
            text.text = pageTexts[pages];
        else
            text.text = "";
    }

    IEnumerator FadeAndUpdatePage()
    {
        isTransitioning = true;

        yield return StartCoroutine(Fade(0f, 1f, 0.2f)); // Fade Out

        SetAllObjectsInactive();
        UpdatePageInstant();

        yield return StartCoroutine(Fade(1f, 0f, 0.2f)); // Fade In

        isTransitioning = false;
    }

    IEnumerator Fade(float from, float to, float duration)
    {
        float time = 0f;
        Color c = fadeImage.color;

        while (time < duration)
        {
            float t = time / duration;
            c.a = Mathf.Lerp(from, to, t);
            fadeImage.color = c;
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        c.a = to;
        fadeImage.color = c;
        if ( pages == objects.Length - 1)
        {
            SceneManager.LoadScene("00.Tilte");
        }
    }
}
