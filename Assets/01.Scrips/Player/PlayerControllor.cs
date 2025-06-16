using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private float _inputX;

    private void Awake()
    {
        Time.timeScale = 1;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        UpdateMove(); // 좌우이동
        UpdateJump(); // 점프
    }

    public void OnMove(InputValue value)
    {
        _inputX = value.Get<Vector2>().x;
    }

    public void UpdateJump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _playerMovement.Jump();
        }
    }

    private void UpdateMove()
    {
        _playerMovement.HorizontalMove(_inputX);
    }

    public IEnumerator Die()
    {
        Time.timeScale = 0;
        GetComponent<SpriteRenderer>().material.color = Color.black;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Foothold") && !collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Player Hit");
            StartCoroutine(Die());
        }
    }
}