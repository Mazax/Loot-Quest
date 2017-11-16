using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public bool destroyIfInWater = true;

    public float aliveTime = 5;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time > (startTime + aliveTime))
        {
            DestroySelf();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sea")
        {
            DestroySelf();
        }

    }

    public void DestroySelf()
    {
        GameObject.Destroy(gameObject);
    }
}
