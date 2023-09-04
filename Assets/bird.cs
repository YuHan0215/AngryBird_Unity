using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bird : MonoBehaviour
{
    private bool isdrag = false;
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float releaseTime = 0.15f;

    private Animator anim;

    public GameObject nextbird;
    private Vector2 startPos;


    public static int score=0;
    public static int coin_score=0;
    public static int throw_num=0;
    
    public AudioClip drag_sound;
    public AudioClip new_bird_sound;
    public AudioClip shoot_sound;
    public AudioClip coin_sound;
    
    private AudioSource audio;

    public static bool end_flag=false;
    public static bool win=false;

    private int first_drag=1;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        startPos = transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isdrag){
           if (Vector2.Distance(mousePos,hook.position) <= 2.5f) rb.position = mousePos;
           else rb.position = hook.position+(mousePos - hook.position).normalized * 2.5f;
            
        }

        if(enemy.enemy_num == 0  && !end_flag){
            end_flag=true;
            win=true;
        }
        GameObject.Find("throw_time").GetComponent<Text>().text="THROW TIME   "+throw_num;

    }

    void OnMouseDown()
    {
        isdrag = true;
        rb.isKinematic=true;

        if (first_drag==1) {
            audio.PlayOneShot(drag_sound);
            first_drag=0;
        }
        throw_num++;
    }

    void OnMouseUp()
    {
        isdrag = false;
        rb.isKinematic=false;

        audio.Stop();
        audio.PlayOneShot(shoot_sound);

        StartCoroutine(Release());
        anim.SetBool("is_fly",true);
        
    }

    IEnumerator Release(){
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled=false;

        yield return new WaitForSeconds(2f);

        
        if (nextbird != null){
            nextbird.SetActive(true);
            
        }
        else{
            
            StartCoroutine(wait_end());
            
        }
    }

    IEnumerator wait_end(){
        yield return new WaitForSeconds(3f);
        end_flag=true;
        if(enemy.enemy_num > 0){
            win = false;
            
        }
        else{
            win = true;
            
        }
    }

    void OnTriggerEnter2D(Collider2D c){
        if (c.gameObject.tag=="coin"){
            coin_score+=2;
            audio.PlayOneShot(coin_sound);
            
            Destroy(c.gameObject);
        }
    }
}
