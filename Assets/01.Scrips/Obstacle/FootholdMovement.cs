using UnityEngine;

public class FootholdMovement : MonoBehaviour
{
    // 이동 방향을 정의하는 열거형(enum)
    public enum Direction { Left, Right, Up, Down }
    // 현재 이동 방향을 저장하는 프로퍼티
    public Direction CurrentDirection { get; private set; }
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move_R()
    {
        rb.linearVelocity = Vector2.right * speed;
        CurrentDirection = Direction.Right;
    }
    public void Move_L()
    {
        rb.linearVelocity = Vector2.left * speed;
        CurrentDirection = Direction.Left;
    }
    public void Move_U()
    {
        rb.linearVelocity = Vector2.up * speed;
        CurrentDirection = Direction.Up;
    }
    public void Move_D()
    {
        rb.linearVelocity = Vector2.down * speed;
        CurrentDirection = Direction.Down;
    }
    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
}