using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager :  SingleTon<GameManager>
{
    //상처율 : 100이 넘으면 게임오버
    private int hurtPercent = 0;

    private bool isRunMode;//런모드 변경 (get,set)

    [SerializeField]
    private Texture2D cursorImg;//커서이미지

    private void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);//기본 커서 이미지
    }

    //----------------------다쳤을 경우------------------------

    public void Hurt(int damage)
    {
        //게임화면 붉게 변함

        hurtPercent -= damage;
        if (hurtPercent <= 0)
            GameOver();

        BloodManager.Instance.AddTired(5);
    }

    //----------------------커서 변경------------------------

    public void CursorChange(Texture2D img)
    {
        Cursor.SetCursor(img, Vector2.zero, CursorMode.ForceSoftware);
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

    public void RunMode()//술래잡기 모드 변경 시 효과 (특정 키 사용 불가 등)
    {
    }


}



