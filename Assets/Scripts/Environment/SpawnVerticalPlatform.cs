using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVerticalPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPlatform;
    [SerializeField]
    [Range(0, 10)] float speedPlattform;

    [SerializeField]
    [Range(0, 10)] float delaySpawn;
    float currentTime;
    [SerializeField]
    bool directionInverted;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= delaySpawn)
        {
            Spawn();
            currentTime = 0;
        }
    }
    public void Spawn()
    {
        if (directionInverted)
        {
            GameObject go = Instantiate(prefabPlatform, transform.position, Quaternion.identity) as GameObject;

            Instantiate(go, transform.position, Quaternion.identity);
            go.GetComponent<VerticalPlatform>().SetDirection(Vector3.up, speedPlattform);
            Destroy(go, 15);
        }
        else
        {
            GameObject go = Instantiate(prefabPlatform, transform.position, Quaternion.identity) as GameObject;

            Instantiate(go, transform.position, Quaternion.identity);
            go.GetComponent<VerticalPlatform>().SetDirection(Vector3.down, speedPlattform);
            Destroy(go, 15);

        }
    }
   
}
