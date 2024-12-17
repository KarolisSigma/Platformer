using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coins;

    public TextMeshProUGUI coinsTxt;

    void Start(){
        coins=0;
    }

    public void AddCoin(){
        coins++;
        coinsTxt.text = coins.ToString();
    }
}
