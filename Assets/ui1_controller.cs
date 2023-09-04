using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui1_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn_menu(){
        SceneManager.LoadScene("menu");
        game_event.play_once=false;
        bird.end_flag=false;
        bird.win=false;
    }
    public void btn_level1(){
        SceneManager.LoadScene("scene1");
        bird.throw_num=0;
        bird.score=0;
        enemy.enemy_num=3;
        bird.coin_score=0;

        game_event.play_once=false;
        bird.end_flag=false;
        bird.win=false;
    }
    public void btn_level2(){
        SceneManager.LoadScene("scene2");
        bird.throw_num=0;
        bird.score=0;
        enemy.enemy_num=5;
        bird.coin_score=0;

        game_event.play_once=false;
        bird.end_flag=false;
        bird.win=false;

    }


    
}
