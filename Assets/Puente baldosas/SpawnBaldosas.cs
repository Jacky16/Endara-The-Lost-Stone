using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBaldosas : MonoBehaviour
{
    [SerializeField] GameObject baldosaPrefab;
    [SerializeField] enum States{Bridge_1,Bridge_2 }
    [SerializeField] States Bridge;
    [SerializeField] float speed = 10;
    [SerializeField] float timeToSpawn = 3;
    float firstTime = 1;
    float time;
    Vector3 direction;
    [SerializeField]bool isSpawingBaldosas = false;
    private void Start()
    {
        //timeToSpawn = firstTime;
        isSpawingBaldosas = true;
    }
    private void FixedUpdate()
    {
        if (isSpawingBaldosas)
        {
            time += Time.deltaTime;
            if (time > timeToSpawn)
            {
                SpawnBaldosa();
                time = 0;
            }
        }
    }
    void SpawnBaldosa()
    {
        switch (Bridge)
        {
            case States.Bridge_1:
                direction = Vector3.left;
                GameObject g = Instantiate(baldosaPrefab, transform.position, Quaternion.Euler(-90,0,0)) as GameObject;
                //g.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;
                g.GetComponent<Baldosa>().SetMove(direction, speed, "DestroyBaldosas_2");
                break;

            case States.Bridge_2:
                direction = Vector3.right;
                GameObject h = Instantiate(baldosaPrefab, transform.position, Quaternion.Euler(-90, 0, 0)) as GameObject;
                //h.GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;
                h.GetComponent<Baldosa>().SetMove(direction, speed, "DestroyBaldosas_1");

                break;
        }
    }
    public void IsSpawingBool(bool b)
    {
        isSpawingBaldosas = b;
    }
}
