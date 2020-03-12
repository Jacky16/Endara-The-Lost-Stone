using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float life = 100;
    [SerializeField] protected float attackDamage;
    
    //Ajustes del enemigo
    [SerializeField] protected Transform player;
    [SerializeField] float _maxAngle;
    [SerializeField] float _maxRadius;
    [SerializeField] float _speed;
    [SerializeField] protected float nearRadiusAttack;
    [SerializeField] protected float farRadiusAttack;
    [SerializeField] bool isFollowPath;

    //Componentes
    [Header("Componentes")]
    [SerializeField]protected NavMeshAgent navMeshAgent;
    [SerializeField] protected Animator anim;
    [Header("Path Enemy")]
    [SerializeField] Transform[] pathEnemy;
    //Variables booleanas
    protected bool isInFov = false;
    protected bool canPath = true;
    //Variables int
    int _nextPosition = 0;
    //variables float
    protected float BetweenDistance;
    //Maquina de estados
    protected enum States { Chase, NearAttack,FarAttack, FollowPath };
    protected States EnemyStates;
    private void Start()
    {
        _speed = Random.Range(2, 4);
        anim = GetComponent<Animator>();
        _nextPosition = 0;
    }

    #region FovLogic
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
        InFOV(transform, player, _maxAngle, _maxRadius);
    }
    private void Update()
    {
        CommonUpdate();
    }
    #endregion
    void CommonUpdate()
    {
        anim.SetFloat("speed", navMeshAgent.speed);
        //Distancia entre el enemigo y el player
        BetweenDistance = Vector3.Distance(transform.position, player.position);

        //Persecucion: si es mayor que el radio de ataque y si la distancia al player es menor que el radio y maximo y en el campo de vision
        if (BetweenDistance > nearRadiusAttack && BetweenDistance < _maxRadius && isInFov && isFollowPath)
        {
            EnemyStates = States.Chase;
        }
        //Ataque cercano : si la distancia es menor que el radio de ataque y si esta en el campo de vision
        if (BetweenDistance <= nearRadiusAttack && isInFov)
        {
            EnemyStates = States.NearAttack;
        }
        else if(BetweenDistance <= farRadiusAttack && isInFov)
        {
            EnemyStates = States.FarAttack;
        }
        //Path: sigue la ruta si la distancia es mayor que el radio maximo
        if (BetweenDistance > _maxRadius)
        {
            //Siguiendo el Path
            EnemyStates = States.FollowPath;
        }
        StateMachine();
    }


    public void StateMachine()
    {
        //print("Enemy_2: " + EnemyStates + " Distance from player: " + Vector3.Distance(transform.position, player.position));
        switch (EnemyStates)
        {
            case States.Chase:
                Chase();
                break;
            case States.FollowPath:
                Path();
                break;
            case States.NearAttack:
                NearAttackPlayer();
                break;
            case States.FarAttack:
                FarAttackPlayer();
                break;
        }
    }
    public void Path()
    {
        navMeshAgent.speed = _speed;
        navMeshAgent.SetDestination(pathEnemy[_nextPosition].position);

        if (Vector3.Distance(transform.position, pathEnemy[_nextPosition].position) < 3)
        {
            if(canPath)
            _nextPosition++;
            StartCoroutine(DelayMovement());
            if (_nextPosition >= pathEnemy.Length)
            {
                _nextPosition = 0;
            }
        }   
    }
    public abstract void NearAttackPlayer();
    public abstract void FarAttackPlayer();
   
    public void Dead()
    {
        //Dead
    }
    public void Chase()
    {
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.speed = _speed;
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
        Gizmos.DrawWireSphere(transform.position, _maxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, nearRadiusAttack);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, farRadiusAttack);

        Vector3 fovLine1 = Quaternion.AngleAxis(_maxAngle, transform.up) * transform.forward * _maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-_maxAngle, transform.up) * transform.forward * _maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFov)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * _maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * _maxRadius);
    }
}
