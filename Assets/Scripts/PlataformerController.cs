using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformerController : MonoBehaviour
{
    public Rigidbody platformRb;
    public Transform[] platformsPositions;
    public float speed = 5;
    private int actualPosition = 0;
    private int nextPosition = 0;
    private bool canMove = true;
    public float timeBetweenPoints = 0.5f;

    // Update is called once per frame
    void Update()
    {
        
            Movement();

        
       
    }
    public void Movement()
    {


        if (canMove)
        {
           
            platformRb.MovePosition(Vector3.MoveTowards(platformRb.position, platformsPositions[nextPosition].position, speed * Time.deltaTime));

        }
        if (Vector3.Distance(platformRb.position,platformsPositions[nextPosition].position) <= 0)
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
}
