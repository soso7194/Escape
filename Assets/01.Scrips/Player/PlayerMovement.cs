using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _moveSpeed = 5f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 12f;

    [Header("CheckGround")]
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private LayerMask _whatIsGround;

    [Header("CheckFoothold")]
    [SerializeField] private LayerMask _whatIsFoothold;

    [Header("CheckHead")]
    [SerializeField] private Transform _headChecker;
    [SerializeField] private Vector2 _headCheckSize;
    [SerializeField] private LayerMask _whatIsBlock;

    public bool _isGrounded;
    public bool _isFoothold;
    public Collider2D _hitObject;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _isGrounded = CheckGround();
        _isFoothold = CheckFoothold();
        _hitObject = CheckHead();
    }
    public void HorizontalMove(float x)
    {
        if (x != 0)
        {
            x = Mathf.Sign(x);
            _rb.linearVelocityX = x * _moveSpeed;
        }
    }
    public void Jump()
    {
        if (_isGrounded || _isFoothold)
        {
            _rb.linearVelocityY = _jumpForce;
        }
    }
    public bool CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundChecker.position, _groundCheckSize, 0, _whatIsGround);
        return collider;
    }

    public bool CheckFoothold()
    {
        Collider2D collider = Physics2D.OverlapBox(_groundChecker.position, _groundCheckSize, 0, _whatIsFoothold);
        return collider;
    }

    public Collider2D CheckHead()
    {
        Collider2D collider = Physics2D.OverlapBox(_headChecker.position, _headCheckSize, 0, _whatIsBlock);
        return collider;
    }
    private void OnDrawGizmos()
    {
        if (_groundChecker != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(_groundChecker.position, _groundCheckSize);
        }

        if (_headChecker != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_headChecker.position, _headCheckSize);
        }
        Gizmos.color = Color.white;
    }
}