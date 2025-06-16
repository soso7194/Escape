using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    private ObstacleMovement obstacleMovement;

    private void Start()
    {
        obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || obstacleMovement == null) return;

        switch (gameObject.tag)
        {
            case "Trigger_U":
                obstacleMovement.MoveUP();
                break;
            case "Trigger_D":
                obstacleMovement.MoveDown();
                break;
            case "Trigger_R":
                obstacleMovement.MoveRight();
                break;
            case "Trigger_L":
                obstacleMovement.MoveLeft();
                break;
            default:
                Debug.LogWarning($"Unknown trigger tag: {gameObject.tag}", this);
                break;
        }

        Destroy(gameObject);
    }
}
