using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager :  SingleTon<GameManager>
{
    //��ó�� : 100�� ������ ���ӿ���
    private int hurtPercent = 0;


    //----------------------������ ���------------------------

    public void Hurt(int damage)
    {
        //����ȭ�� �Ӱ� ����

        hurtPercent -= damage;
        if (hurtPercent <= 0)
            GameOver();

        BloodManager.Instance.AddTired(5);
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
}



