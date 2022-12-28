using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BloodColor
{
    Red,
    Green,
    Blue,
    White,
    Pink,
    Black,
    Size

}

public class BloodManager : SingleTon<BloodManager>
{
    //피에 관련된 것들 진행

    //피로도 : 쌓일수록 시야가 흐려짐
    private int tiredPercent = 0;

    [SerializeField]
    private int howMuchTired;

    //현재 피 색
    [SerializeField]
    private BloodColor curBloodColor = BloodColor.Red; //get,set추가


    public void UsedKnife()
    {
        //칼을 사용해 현재 색의 피를 흘리는 애니메이션
    }

    public void DroppedGem()
    {
        //현재 피 색의 젬 떨어뜨림
    }

    public void AddTired(int tired)//다쳤거나 칼로 피를 흘릴 때 피로도 증가
    {
        tiredPercent += tired;

        Blind();
    }

    private void Blind()
    {
        //시야 흐려짐
    }
}
