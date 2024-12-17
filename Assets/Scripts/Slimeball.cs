using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeball : MonoBehaviour
{

    public float speed;
    public Vector3 direction;

    void Update()
    {
        transform.position +=  direction*speed*Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            
            var health = other.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(1);
                
            }
            Destroy(gameObject);
        }
    }
}
