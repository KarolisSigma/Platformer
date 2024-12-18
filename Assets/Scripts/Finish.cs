using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public CoinManager coinManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && coinManager.coins>=3)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
