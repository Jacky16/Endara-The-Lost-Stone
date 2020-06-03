using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    float speed;
    Vector3 direction;
    private void Start()
    {
        //direction = Vector3.down;
        //speed = 5;
    }
    private void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }
    public void SetDirection(Vector3 dir, float s)
    {
        speed = s;
        direction = dir;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetMovingPlattform(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetMovingPlattform(false);
        }
    }
    private void OnEnable()
    {

    }

}
