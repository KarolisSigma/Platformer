using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{

    private GameObject child;

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            child=transform.GetChild(0).gameObject;
            StartCoroutine(spike());

                var health = other.gameObject.GetComponent<Health>();
                if(health != null)
                {
                    health.TakeDamage(1);
                }
        }
    }

    IEnumerator spike(){
        child.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        child.SetActive(false);
    }


}
