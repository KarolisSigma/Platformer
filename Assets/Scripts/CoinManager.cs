using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coins;
    public AudioSource audioSource;
    public TextMeshProUGUI coinsTxt;

    void Start(){
        coins=0;
    }

    public void AddCoin(){
        coins++;
        coinsTxt.text = coins.ToString();
        audioSource.Play();
    }
}
