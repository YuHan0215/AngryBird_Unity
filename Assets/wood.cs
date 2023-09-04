using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audio;

    public static int sound_num=0;
    // Start is called before the first frame update
    void Start()
    {
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
            if (sound_num<4){
                sound_num++;
                audio.PlayOneShot(sound);
                StartCoroutine(silent());
            }
        }
    }

    IEnumerator silent(){
        yield return new WaitForSeconds(2f);
        sound_num--;
    }

}
