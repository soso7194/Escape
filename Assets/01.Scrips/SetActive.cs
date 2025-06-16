using UnityEngine;

public class SetActive : MonoBehaviour
{
    [SerializeField] GameObject activeObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeObject.SetActive(!activeObject.activeSelf);
            gameObject.SetActive(false);
        }
    }
}
