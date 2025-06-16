using System;
using UnityEngine;

public class FootholdTrigger : MonoBehaviour
{
    [SerializeField] GameObject foothold;
    FootholdMovement footholdMovement;

    private void Start()
    {
        footholdMovement = foothold.GetComponent<FootholdMovement>();
        footholdMovement.Move_R();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Foothold"))
        {
            footholdMovement.Stop();

            switch (footholdMovement.CurrentDirection)
            {
                case FootholdMovement.Direction.Left:
                    footholdMovement.Move_R();
                    break;
                case FootholdMovement.Direction.Right:
                    footholdMovement.Move_L();
                    break;
                case FootholdMovement.Direction.Up:
                    footholdMovement.Move_D();
                    break;
                case FootholdMovement.Direction.Down:
                    footholdMovement.Move_U();
                    break;
            }
        }
    }
}
