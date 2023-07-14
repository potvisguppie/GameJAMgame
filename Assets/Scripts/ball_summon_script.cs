using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ob;
    public float freq;
    public float range;
    private float balltimer = 0;


    private void Start()
    {
        summon();
    }
    void Update()
    {
        balltimer += Time.deltaTime;
        if (balltimer > freq)
        {
            summon();
            if (freq > 0.001) freq /= 1.05f;
            balltimer = 0;
        }
    }

    void summon()
    {
        Instantiate(ob, new Vector3(Random.Range(transform.position.x + range, transform.position.x - range),
                transform.position.y,
                Random.Range(transform.position.z + range, transform.position.z - range)), transform.rotation);
    }
}
