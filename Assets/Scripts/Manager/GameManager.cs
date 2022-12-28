using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager :  SingleTon<GameManager>
{
    //��ó�� : 100�� ������ ���ӿ���
    private int hurtPercent = 0;

    private bool isRunMode;//����� ���� (get,set)

    [SerializeField]
    private Texture2D cursorImg;//Ŀ���̹���

    private void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);//�⺻ Ŀ�� �̹���
    }

    //----------------------������ ���------------------------

    public void Hurt(int damage)
    {
        //����ȭ�� �Ӱ� ����

        hurtPercent -= damage;
        if (hurtPercent <= 0)
            GameOver();

        BloodManager.Instance.AddTired(5);
    }

    //----------------------Ŀ�� ����------------------------

    public void CursorChange(Texture2D img)
    {
        Cursor.SetCursor(img, Vector2.zero, CursorMode.ForceSoftware);
    }


    //----------------------�� ����------------------------

    private void GameOver()
    {
        //���ӿ��� ������ ��ȯ
        SceneChange("GameOver");
    }

    public void SceneChange(string sceneName)
    {
        //�� ü����
    }

    public void RunMode()//������� ��� ���� �� ȿ�� (Ư�� Ű ��� �Ұ� ��)
    {
    }


}



