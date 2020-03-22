using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]
public class PlataformerController : MonoBehaviour
{
    Rigidbody platformRb;
    public Transform[] platformsPositions;
    [SerializeField] float speed = 5;
    private int actualPosition = 0;
    private int nextPosition = 0;
    private bool canMove = true;
    [SerializeField] float timeBetweenPoints = 0.5f;

    private void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        platformRb.useGravity = false;
    }

    void FixedUpdate()
    {
          Movement();
    }
    public void Movement()
    {


        if (canMove)
        {
           
            transform.position = (Vector3.MoveTowards(transform.position, platformsPositions[nextPosition].position, speed * Time.deltaTime));

        }
        if (Vector3.Distance(platformRb.position,platformsPositions[nextPosition].position) <= 1)
        {
            StartCoroutine(delayMovement(timeBetweenPoints));

            actualPosition = nextPosition;
            nextPosition++;
            if(nextPosition >= platformsPositions.Length)
            {
                nextPosition = 0;
               
            }

        }
    }

    IEnumerator delayMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
