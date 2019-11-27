using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidbody : MonoBehaviour
{
    public float pushPower = 2f;
    private float valueMass;


        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic)
        {
            return;
        }

        if(hit.moveDirection.y < -0.3f)
        {
            return;
        }

        valueMass = rb.mass;
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0 ,hit.moveDirection.z);
      
        rb.velocity = (pushDir * pushPower)/valueMass;
    }
}
