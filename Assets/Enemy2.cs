using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    //Ajustes del enemigo
    [SerializeField] Transform player;
    [SerializeField] float maxAngle;
    [SerializeField] float maxRadius;
    [SerializeField] float speed;
    

    //Componentes
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] pathEnemy;
    [SerializeField] Animator anim;
    //Variables booleanas
    private bool isInFov = false;
    bool canPath = true;
    //Variables int
    int nextPosition = 0;

    //Maquina de estados
    enum States {Chase,Attack,FollowPath};
    States EnemyStates;
    private void Start()
    {
        speed = Random.Range(2, 4);
        //nextPosition = 0;
    }


    public void InFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] colliders = Physics.OverlapSphere(checkingObject.position, maxRadius);
        foreach (Collider c in colliders)
        {
            if (c.transform == player)
            {
                Vector3 betweenDistance = (target.position - checkingObject.position).normalized;
                float angle = Vector3.Angle(checkingObject.forward, betweenDistance);
                if (angle <= maxAngle)
                {
                    Ray ray = new Ray(checkingObject.position, betweenDistance);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, maxRadius))
                    {
                        if (hit.collider.tag == "Player" || hit.collider.name == "Player")
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
    private void FixedUpdate()
    {
        InFOV(transform, player, maxAngle, maxRadius);

    }
    private void Update()
    {
        Debug.Log(EnemyStates);
        Debug.Log("esta en el campo de vision: " + isInFov);
        
        float BetweenDistance = Vector3.Distance(transform.position, player.position);
        //Persecucion
        if (BetweenDistance > 10 && BetweenDistance < maxRadius) 
        {
            EnemyStates = States.Chase;
        }
        //Atacando
        if (BetweenDistance <= 10 )
        {
            EnemyStates = States.Attack;
        }
        
        //Siguiendo el Path
        if (BetweenDistance > maxRadius)
        {
            EnemyStates = States.FollowPath;
        }
        StateMachine();
         
    }
    public void StateMachine()
    {
        switch (EnemyStates)
        {
            case States.Chase:
                Chase();
                break;
            case States.FollowPath:
                Path();
                break;
            case States.Attack:
                AttackPlayer();
                break;
        }
    }
    public void Path()
    {

        navMeshAgent.speed = speed;
        navMeshAgent.SetDestination(pathEnemy[nextPosition].position);
        
        if (Vector3.Distance(transform.position, pathEnemy[nextPosition].position) <= navMeshAgent.stoppingDistance)
        {
            nextPosition++;
            //StartCoroutine(DelayMovement());
            if (nextPosition >= pathEnemy.Length)
            {
                nextPosition = 0;
            }
        }
    }
    public void AttackPlayer()
    {
        navMeshAgent.speed = 0;
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation,rotationToPlayer, 1 * Time.deltaTime);
        //Instanciar rocas
    }

    public void Dead()
    {
        //Dead
    }
    public void Chase()
    {
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.speed = speed;
    }
    IEnumerator DelayMovement()
    {
        canPath = false;
        yield return new WaitForSeconds(1f);
        canPath = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Caja")
        {
            Dead();
            Destroy(collision.gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);

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

}
