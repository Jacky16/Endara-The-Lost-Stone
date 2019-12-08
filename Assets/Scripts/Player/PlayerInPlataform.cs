using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInPlataform : MonoBehaviour
{
    public CharacterController player;
    private Vector3 groundPosition;
    private Vector3 lastGroundPosition;
    private string groundName;
    private string lastGroundName;
    Quaternion actualRot;
    Quaternion lastRot;

    // Update is called once per frame
    void FixedUpdate()
    {
        movementInPlataforms();
    }
    public void movementInPlataforms()
    {
        Debug.Log(player.isGrounded);
        if (player.isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up * 6, out hit,default))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;

                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
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
        else if (!player.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
        }
    }
    private void OnDrawGizmos()
    {
       // Debug.DrawLine(player.transform.position / 8, player.transform.position + 6);
    }

}
