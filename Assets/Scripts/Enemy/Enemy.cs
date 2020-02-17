using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int life = 100;
    [SerializeField] protected float attackDamage;
    
    //Ajustes del enemigo
    [SerializeField] protected Transform player;
    [SerializeField] float maxAngle;
    [SerializeField] float maxRadius;
    [SerializeField] float speed;
    [SerializeField] protected float radiusAttack;

    //Componentes
    [Header("Componentes")]
    protected NavMeshAgent navMeshAgent;
    [SerializeField] protected Animator anim;
    [SerializeField] Transform[] pathEnemy;
    //Variables booleanas
    protected bool isInFov = false;
    protected bool canPath = true;
    //Variables int
    int nextPosition = 0;

    //Maquina de estados
    protected enum States { Chase, Attack, FollowPath };
    protected States EnemyStates;
    private void Start()
    {
        speed = Random.Range(2, 4);
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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
        CommonUpdate();
        PepitoUpdateQueMeSaleDeLasNaricesUpdate();
    }

    void CommonUpdate()
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

    protected virtual void PepitoUpdateQueMeSaleDeLasNaricesUpdate()
    {

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
        if(pathEnemy != null)
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
        else
        {
            Debug.LogWarning("No hay una ruta en " + gameObject.name);
        }
        
    }
    public abstract void AttackPlayer();
    public void Dead()
    {
        //Dead
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
}
