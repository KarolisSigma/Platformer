using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string scene;
    public void Restart(){
        SceneManager.LoadScene(scene);
    }
}
