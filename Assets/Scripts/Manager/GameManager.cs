using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager :  SingleTon<GameManager>
{
    

    private bool isRunMode;//런모드 변경 (get,set)

    [SerializeField]
    private Texture2D cursorImg;//커서이미지

    [SerializeField]
    private Image bloodyScene;

    private void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);//기본 커서 이미지
    }




    //----------------------커서 변경------------------------

    public void CursorChange(Texture2D img)
    {
        Cursor.SetCursor(img, new Vector2((float)img.width*0.5f, (float)img.height*0.5f), CursorMode.ForceSoftware);
    }

    //현재 커서가 입력한 아이템 이름의 커서인가?
    public bool IsCurCursor(string fileName)
    {
        Debug.Log(fileName);
        Debug.Log(ItemManager.Instance.curSetItem.fileName);
        if (fileName == ItemManager.Instance.curSetItem.fileName)
            return true;
        else
            return false;
    }


    //----------------------씬 관련------------------------

    public void BloodyScene()
    {
        //다쳤을때 화면 빨갛게 하기
        bloodyScene.gameObject.SetActive(true);

        StartCoroutine(BloodySceneActive());
    }

    private IEnumerator  BloodySceneActive()
    {
        yield return new WaitForSeconds(0.15f);
        bloodyScene.gameObject.SetActive(false);
    }

    


    public void GameOver()
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



