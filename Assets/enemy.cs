using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Animator anim;

    private float health=4.5f;
    
    public static int enemy_num=0;
    public GameObject Hiteffect;

    public AudioClip pig_sound;
    private AudioSource audio;

    private int first_hurt=1;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //enemy_num++;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //Debug.Log(collider.relativeVelocity.magnitude);
        if (collider.relativeVelocity.magnitude > 1.7f){
            anim.SetBool("is_hurt",true);
            if (first_hurt==1){
                audio.PlayOneShot(pig_sound);
                first_hurt=0;
            }
        }

        if (collider.relativeVelocity.magnitude > health){
            audio.PlayOneShot(pig_sound);
            //Die();
            enemy_num--;
            health=100f;
            StartCoroutine(Die());
        }
    }

   /* void Die(){
        Instantiate(Hiteffect, transform.position, Quaternion.identity);
        enemy_num--;
        Debug.Log(enemy_num);
        Destroy(gameObject);
    }*/

    IEnumerator Die(){
        yield return new WaitForSeconds(0.6f);
        Instantiate(Hiteffect, transform.position, Quaternion.identity);
        
       
        Destroy(gameObject);
    }
}
