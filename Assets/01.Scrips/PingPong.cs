using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Vector2 moveDirection = new Vector2(1, 1);
    public float speed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = new Vector2(1, 1).normalized;
    }

    void Update()
    {
        if (moveDirection == Vector2.zero)
        {
            moveDirection = new Vector2(1, 1).normalized;
        }
        rb.linearVelocity = moveDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽과 충돌 시 반사 방향 계산
        ContactPoint2D contact = collision.contacts[0];
        Vector2 normal = contact.normal;
        moveDirection = Vector2.Reflect(moveDirection, normal).normalized;
    }
}
