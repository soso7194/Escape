using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadMe : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite[] images;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] pageTexts;
    int pages = 0;

    void Start()
    {
        UpdatePage();
    }

    void OnEnable()
    {
        pages = 0;
        UpdatePage();
    }

    public void LeftClick()
    {
        if (pages > 0)
        {
            pages--;
            Debug.Log(pages);
            UpdatePage();
        }
    }

    public void RightClick()
    {
        if (pages < images.Length - 1)
        {
            pages++;
            Debug.Log(pages);
            UpdatePage();
        }
        else if (pages == images.Length - 1)
        {
            ExitClick();
        }
    }

    public void ExitClick()
    {
        pages = 0;
        gameObject.SetActive(false);
        IntroButton.isReadMeOpen = false;
    }

    void UpdatePage()
    {
        if (images != null && pages < images.Length)
            image.sprite = images[pages];
        else
            image.sprite = null;

        if (pageTexts != null && pages < pageTexts.Length)
            text.text = pageTexts[pages];
        else
            text.text = "";
    }
}
