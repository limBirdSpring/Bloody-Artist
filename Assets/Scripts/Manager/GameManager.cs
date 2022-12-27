using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager :  SingleTon<GameManager>
{
    //상처율 : 100이 넘으면 게임오버
    private int hurtPercent = 0;


    //----------------------다쳤을 경우------------------------

    public void Hurt(int damage)
    {
        //게임화면 붉게 변함

        hurtPercent -= damage;
        if (hurtPercent <= 0)
            GameOver();

        BloodManager.Instance.AddTired(5);
    }




    //----------------------씬 관련------------------------

    private void GameOver()
    {
        //게임오버 씬으로 전환
        SceneChange("GameOver");
    }

    public void SceneChange(string sceneName)
    {
        //씬 체인지
    }
}



