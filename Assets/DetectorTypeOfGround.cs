using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorTypeOfGround : MonoBehaviour
{
    PlayerSoundMovement playerSoundMovement;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    float radiusSphere = 10;
    private void Awake()
    {
        playerSoundMovement = GetComponentInParent<PlayerSoundMovement>();
    }
    private void FixedUpdate()
    {
        DetectGround();
    }
    void DetectGround()
    {
        Ray ray;
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, radiusSphere, Vector3.down, out hit, 5))
        {
            if(hit.collider != null)
            {
                print(hit.collider.tag);
                if (hit.collider.CompareTag("Ground_Hierba"))
                {
                    playerSoundMovement.typeOfGroundState = PlayerSoundMovement.typeOfGround.Hierba;
                }
                if (hit.collider.CompareTag("Ground_Tierra") || hit.collider.gameObject.name == "Terrain")
                {
                    playerSoundMovement.typeOfGroundState = PlayerSoundMovement.typeOfGround.Tierra;
                }
                if (hit.collider.CompareTag("Ground_Piedra"))
                {
                    playerSoundMovement.typeOfGroundState = PlayerSoundMovement.typeOfGround.Piedra;

                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radiusSphere);
    }


}
