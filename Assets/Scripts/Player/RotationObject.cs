using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotationObject : MonoBehaviour
{
    public void Rotate()
    {
        transform.localRotation = Quaternion.LerpUnclamped(transform.localRotation, Quaternion.Euler(0, 15, 0), 1);
        Debug.Log("Hola");
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;

        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(Rotate(Vector3.up, 15, 1.0f));

            }
        }
    }
}
