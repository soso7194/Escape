using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    [SerializeField] float setActiveTime = 1f;
    [SerializeField] float setStopTime = 1f;
    [SerializeField] float waitTime;

    private Coroutine moveCoroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveUP()
    {
        StartCoroutine(Wait(Vector2.up));
    }

    public void MoveDown()
    {
        StartCoroutine(Wait(Vector2.down));
    }

    public void MoveRight()
    {
        StartCoroutine(Wait(Vector2.right));
    }

    public void MoveLeft()
    {
        StartCoroutine(Wait(Vector2.left));
    }

    private void Stop()
    {
        Debug.Log("Stop()");
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        rb.linearVelocity = Vector2.zero;
    }

    private IEnumerator Wait(Vector2 direction)
    {
        yield return new WaitForSeconds(waitTime);
        StartMove(direction);
    }
    private void StartMove(Vector2 direction)
    {
        Stop();
        rb.linearVelocity = direction * speed;
        moveCoroutine = StartCoroutine(MoveForDuration());
    }


    private IEnumerator MoveForDuration()
    {
        Debug.Log("Move started");
        yield return new WaitForSeconds(setActiveTime);
        Debug.Log("Move paused");
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(setStopTime);
        Debug.Log("Move down");
        rb.linearVelocity = Vector2.down * speed;
    }
}

