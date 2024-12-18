using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool attacking;
    public int startx;
    public int endx;
    public float speed;
    public float howFarSee;
    public float shotDelay;
    private bool positiveVelocity;
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    public GameObject slime;

    public Sprite chill;
    public Sprite mad;

    private bool flipped;

    private float lastshot;

    void Start()
    {
        player = GameObject.Find("Player");
        flipped=false;
        attacking=false;
        spriteRenderer=GetComponent<SpriteRenderer>();
        positiveVelocity=false;
        StartCoroutine(LookForPlayer());
    }


    void Update()
    {
        if(!attacking){
            if(positiveVelocity){
                transform.position += Vector3.right*speed*Time.deltaTime;
                if(transform.position.x>endx){
                    positiveVelocity=false;
                    spriteRenderer.flipX = true;
                }
            }
            else{
                transform.position += Vector3.left*speed*Time.deltaTime;
                if(transform.position.x<startx){
                    positiveVelocity=true;
                    spriteRenderer.flipX = false;
                }
            }
        }
        else{
            if(Time.time-lastshot>shotDelay){
                lastshot=Time.time;
                Shoot();
            }
            if(player.transform.position.x<transform.position.x){
                if(!flipped){
                    spriteRenderer.flipX = true;
                    flipped=true;
                }

            }
            else if(flipped){
                spriteRenderer.flipX = false;
                flipped=false;
            }
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(slime, transform.position, Quaternion.identity);
        
        bullet.GetComponent<Slimeball>().direction = (player.transform.position-transform.position).normalized;
    }

    IEnumerator LookForPlayer(){
        while(true){
            yield return new WaitForSeconds(0.5f);
            if(Vector3.Distance(player.transform.position, transform.position)<howFarSee){
                attacking=true;
                spriteRenderer.sprite = mad;
            }
            else{
                attacking=false;
                spriteRenderer.sprite=chill;
            }
        }
    }
}
