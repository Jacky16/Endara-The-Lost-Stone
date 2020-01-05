using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour
{
   
    [Header("Ajustes del enemigo")]
    [SerializeField] Transform player;
    [SerializeField] float maxAngle;
    [SerializeField] float maxRadius;
    [SerializeField] float radiusAttack;
    [SerializeField] float speed;
    int explosionRand = 1;


    [Header("Componentes")]
    NavMeshAgent navMeshAgent;
    Animator anim;
    [SerializeField] Transform[] pathEnemy;
    [SerializeField] GameObject explosionPrefab;
    //Variables booleanas
    private bool isInFov = false;
    bool canPath = true;
    //Variables int
    int nextPosition = 0;

    //Maquina de estados
    enum States { Chase, Attack, FollowPath };
    States EnemyStates;
    private void Start()
    {
        speed = Random.Range(2, 4);
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nextPosition = 1;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusAttack);

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

                        if (hit.transform == target.transform)
                        {
                            Debug.Log("IsInFov");
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
        //Debug.Log(EnemyStates);
        //Debug.Log("esta en el campo de vision: " + isInFov);

        //Distancia entre el enemigo y el player
        float BetweenDistance = Vector3.Distance(transform.position, player.position);
        //Persecucion: si es mayor que el radio de ataque y si la distancia al player es menor que el radio y maximo y en el campo de vision
        if (BetweenDistance > radiusAttack && BetweenDistance < maxRadius && isInFov)
        {
            EnemyStates = States.Chase;
        }
        //Ataque : si la distancia es menor que el radio de ataque y si esta en el campo de vision
        else if (BetweenDistance <= radiusAttack && isInFov)
        {
            //Atacando
            EnemyStates = States.Attack;
        }
        //Path: sigue la ruta si la distancia es mayor que el radio maximo
        else if (BetweenDistance > maxRadius)
        {
            //Siguiendo el Path
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
            StartCoroutine(DelayMovement());
            if (nextPosition >= pathEnemy.Length)
            {
                nextPosition = 0;
            }
        }
    }
    public void Chase()
    {
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.speed = speed;
        if (!isInFov)
        {
            EnemyStates = States.FollowPath;
        }
    }
    public void AttackPlayer()
    {
        if (explosionRand == 0)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else if (explosionRand == 1)
        {
            navMeshAgent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) < radiusAttack)
            {
                navMeshAgent.speed = 0;
                anim.SetTrigger("Explosion");

            }
        }
    }
    public void Explosion()
    {
        gameObject.SetActive(false);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
    }
    public void Dead()
    {
        gameObject.SetActive(false);
        GameObject g = explosionPrefab;
        g.GetComponent<SphereCollider>().enabled = false;
        Instantiate(g, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
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
}