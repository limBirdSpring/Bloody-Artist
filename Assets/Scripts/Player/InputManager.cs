using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;


public enum StateName
{
    Idle,
    Research,
    Researching,
    Talking,
    Inventory,
    Horror,
    PaintBall,
    Block,
    MiniGame,
    BlockResearch,
    Size,
}

[Serializable]
public struct StateMachine
{
    public StateName stateName;


    public State state;
}

public class InputManager : SingleTon<InputManager>
{
    [SerializeField]
    public List<StateMachine> allState = new List<StateMachine>();

    private State curState;



    private void Start()
    {
        curState = allState[0].state;
    }

    private void Update()
    {
        curState.Action();
    }

    public void ChangeState(StateName state)
    {
        for(int i=0; i< allState.Count;i++)
        {
            if (allState[i].stateName == state)
            {
                curState = allState[i].state;
                return;
            }
        }
    }

    public StateName GetCurState()
    {
        for(int i=0; i<allState.Count;i++)
        {
            if (curState == allState[i].state)
                return allState[i].stateName;
        }
        return StateName.Block;
    }
}
