using UnityEngine;
using UnityEngine.Tilemaps;

public class Barrier : MonoBehaviour
{
    private Tilemap tilemap;
    private Color color;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        color = tilemap.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            color.a = 1f;
            tilemap.color = color;
        }
    }
}
