using UnityEngine;

public class SawTrigger : MonoBehaviour
{
    [SerializeField] private GameObject saw;
    private SawMovement sawMovement;
    private void Awake()
    {
        sawMovement = saw.GetComponentInParent<SawMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || sawMovement == null) return;
        sawMovement.Scale();
        Destroy(gameObject);
    }
}
