using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] Image image;
    private void Start()
    {
        StartCoroutine(IntroSequence(1.5f, image));
    }

    private IEnumerator IntroSequence(float time, Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
       
        while (image.color.a < 1.0f)
        {
            //�̹����� �Ⱥ��̴� ���¿��� ���̰� �ϴ� �ڵ�
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / time));
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        while (image.color.a > 0.0f)
        {
            //���� ���������ϱ� �ٽ� �Ⱥ��̰� �ϴ� �ڵ�
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / time));
            yield return null;
        }
        SceneManager.LoadScene("01.Main");
    }
}
