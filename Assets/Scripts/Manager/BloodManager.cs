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
    //�ǿ� ���õ� �͵� ����

    //�Ƿε� : ���ϼ��� �þ߰� �����
    private int tiredPercent = 0;

    [SerializeField]
    private int howMuchTired;

    //���� �� ��
    [SerializeField]
    private BloodColor curBloodColor = BloodColor.Red; //get,set�߰�


    public void UsedKnife()
    {
        //Į�� ����� ���� ���� �Ǹ� �긮�� �ִϸ��̼�
    }

    public void DroppedGem()
    {
        //���� �� ���� �� ����߸�
    }

    public void AddTired(int tired)//���ưų� Į�� �Ǹ� �긱 �� �Ƿε� ����
    {
        tiredPercent += tired;

        Blind();
    }

    private void Blind()
    {
        //�þ� �����
    }
}
