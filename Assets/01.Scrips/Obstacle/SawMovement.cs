using UnityEngine;
using System.Collections;
using System;

public class SawMovement : MonoBehaviour
{
    [SerializeField] bool isScaled = false;
    [SerializeField] float scaleFactor = 1f;
    [SerializeField] float setStopTime = 1f;
    [SerializeField] float speed = 0.5f;
    private Vector2 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }
    public void Scale()
    {
        if (isScaled == true)
        {
            StartCoroutine(ScaleUp());
        }
    }
    IEnumerator ScaleUp()
    {
        while (transform.localScale.x < originalScale.x * scaleFactor)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0) * speed;
            yield return null;
        }
        yield return new WaitForSeconds(setStopTime);
        StartCoroutine(ScaleDown());
    }

    IEnumerator ScaleDown()
    {
        while (transform.localScale.x > originalScale.x)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0) * speed;
            yield return null;
        }
    }
}