using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ElecManager : SingleTon<ElecManager>
{
    [SerializeField]
    private Elecable red;

    [SerializeField]
    private Elecable black;

    [SerializeField]
    private Elecable green;
    
    [SerializeField]
    private Elecable blue;

    private List<Elecable> elecList;

    [SerializeField]
    private GameObject half;

    [SerializeField]
    private GameObject all;


    public void ElecUpdate(Elecable elec)
    {
         elecList.Add(elec);
    }

    public void Cut()
    {
        if (GameManager.Instance.IsCurCursor("Knife"))
        {
            half.SetActive(true);
            all.SetActive(false);

            if (elecList[0] == green && elecList[1] == red && elecList[2] == blue && elecList[3] == black)
            {
                //���� �����̶��
                TVManager.Instance.ChangeTV();
            }
            else
            {
                //���� Ʋ�ȴٸ�
                red.Off();
                black.Off();
                green.Off();
                blue.Off();

                //���� ����
                BloodManager.Instance.Hurt(5);
                elecList.Clear();
            }
        }
    }

}
