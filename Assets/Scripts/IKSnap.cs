using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSnap : MonoBehaviour
{
    public bool useIK;

    public bool leftHandIK = false;
    public bool rightHandIK = false;

    private Vector3 lefHandPos;
    private Vector3 rightHandPos;

    private Animator anim;
    [SerializeField]LayerMask climbLayer;
    [SerializeField]float Distance;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit Lhit;
        RaycastHit Rhit;

        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -Vector3.up + new Vector3(-0.5f, 0.0f, 0.0f), out Lhit,Distance, climbLayer))
        {
            leftHandIK = true;
            lefHandPos = Lhit.point;
            
            
        }
        else
        {
            leftHandIK = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), out Rhit, Distance, climbLayer))
        {
            rightHandIK = true;
            rightHandPos = Rhit.point;

        }
        else
        {
            rightHandIK = false;
        }
     
    }
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), (-transform.up + new Vector3(-0.5f, 0.0f, 0.0f)).normalized * Distance, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), (-transform.up + new Vector3(0.5f, 0.0f, 0.0f)).normalized * Distance, Color.green);
        OnAnimatorIK();
    }

    private void OnAnimatorIK()
    {
        if (useIK)
        {
            if (leftHandIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, lefHandPos);
            }
            if (rightHandIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPos);
            }
        }
    }

}