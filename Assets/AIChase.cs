using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;
    void Start()
    {

    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

            
        direction.Normalize();

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }

 
}