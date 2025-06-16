using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has entered the dead zone!");
            StartCoroutine(playerController.Die());
        }
        else if (collision.CompareTag("Obstacle") || collision.CompareTag("Wall"))
        {
            Debug.Log("Obstacle has been destroyed!");
            Destroy(collision.gameObject);
        }
    }
}
