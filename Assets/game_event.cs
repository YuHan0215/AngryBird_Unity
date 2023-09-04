using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_event : MonoBehaviour
{
    public static bool play_once=false;

    public GameObject win;
    public GameObject lose;
    public AudioClip win_sound;
    public AudioClip lose_sound;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.end_flag && !play_once){
            if (bird.win){
                audio.PlayOneShot(win_sound);
                bird.score=100-bird.throw_num*5+bird.coin_score;
                win.SetActive(true);
                GameObject.Find("score_win").GetComponent<Text>().text="score: "+bird.score;
            }
            else{
                bird.score=100-bird.throw_num*5-enemy.enemy_num*5+bird.coin_score;
                lose.SetActive(true);
                GameObject.Find("score_lose").GetComponent<Text>().text="score: "+bird.score;
                audio.PlayOneShot(lose_sound);
            }
            play_once=true;
        }
    }
}
