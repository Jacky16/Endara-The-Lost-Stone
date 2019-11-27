using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour
{
    public Transform player;
    public float maxAngle;
    public float maxRadius;

    private bool isInFov = false;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] pathEnemy;
    bool canPath = true;
    int nextPosition = 0;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFov)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public void inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(checkingObject.position, maxRadius);
        foreach(Collider c in colliders)
        {
            if (c.transform == target)
            {
                Vector3 betweenDistance = (target.position - checkingObject.position).normalized;
                float angle = Vector3.Angle(checkingObject.forward, betweenDistance);
                if (angle <= maxAngle)
                {

                    Ray ray = new Ray(checkingObject.position, betweenDistance);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, maxRadius))
                    {

                        if (hit.transform == target)
                        {
                            isInFov = true;

                        }
                    }
                }
                else
                {
                    isInFov = false;
                }
            }
        }
    }
    

    private void Update()
    {
        inFOV(transform, player, maxAngle, maxRadius);
        if (isInFov)
        {
            navMeshAgent.SetDestination(player.position);
        }else
        {
            Path();
        }
        Debug.Log(isInFov);
    }
    public void Path()
    {
        if (canPath)
        {
            navMeshAgent.SetDestination(pathEnemy[nextPosition].position);
        }
        if(Vector3.Distance(transform.position,pathEnemy[nextPosition].position) <= navMeshAgent.stoppingDistance)
        {
            Debug.Log("he llegado");
            nextPosition++;
            StartCoroutine(DelayMovement());
            
            
            if(nextPosition >= pathEnemy.Length)
            {
                nextPosition = 0;
            }
        }
    }
  IEnumerator DelayMovement()
    {
        canPath = false;
        yield return new WaitForSeconds(1f);
        canPath = true;
    }

}