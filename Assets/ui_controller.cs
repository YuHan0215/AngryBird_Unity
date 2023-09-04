using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ui_controller : MonoBehaviour
{
    public GameObject info;
    //public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn_level1(){
        SceneManager.LoadScene("scene1");
        enemy.enemy_num=3;
        bird.score=0;
        bird.throw_num=0;
        bird.coin_score=0;

        game_event.play_once=false;
        bird.end_flag=false;
        bird.win=false;
    }
    public void btn_level2(){
        SceneManager.LoadScene("scene2");
        enemy.enemy_num=5;
        bird.score=0;
        bird.throw_num=0;
        bird.coin_score=0;

        game_event.play_once=false;
        bird.end_flag=false;
        bird.win=false;
    }

    public void btn_menu_canvas(){
        info.SetActive(false);
    }

    public void btn_info_canvas(){
        info.SetActive(true);
    }

    public void btn_exit(){
        Application.Quit();
    }
    
}
