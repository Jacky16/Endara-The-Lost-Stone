using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInPlataform : MonoBehaviour
{
    [SerializeField] CharacterController player;
    private Vector3 groundPosition;
    private Vector3 lastGroundPosition;
    private string groundName;
    private string lastGroundName;
    Quaternion actualRot;
    Quaternion lastRot;
    private bool isInPlattform = false;
    PlayerMovement playerMovement;

    [SerializeField] LayerMask platformLayerMask;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void LateUpdate()
    {
        movementInPlataforms();
    }
    public void movementInPlataforms()
    {
        Debug.Log(isInPlattform);
        //if (isInPlattform)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f, platformLayerMask))
            {
                //playerMovement.gravity = 0;

                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;
                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                    transform.parent = groundedIn.transform;

                }
                if (actualRot != lastRot && groundName == lastGroundName)
                {
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }


                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
            }
        }
        //else if (!isInPlattform)
        //{
        //    lastGroundName = null;
        //    lastGroundPosition = Vector3.zero;
        //    transform.parent = null;
        //    playerMovement.gravity = 6;

        //}
    }
    //private void OnDrawGizmos()
    //{
    //   // Debug.DrawLine(player.transform.position / 8, player.transform.position + 6);
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Caja")
    //    {
    //        isInPlattform = true;
    //    }
       
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Caja")
    //    {
    //        isInPlattform = false;
    //    }
    //}

}

