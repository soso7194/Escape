using UnityEngine;

public class FootholdMovement : MonoBehaviour
{
    // �̵� ������ �����ϴ� ������(enum)
    public enum Direction { Left, Right, Up, Down }
    // ���� �̵� ������ �����ϴ� ������Ƽ
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