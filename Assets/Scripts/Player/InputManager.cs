using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;


public enum StateName
{
    Idle,
    Research,
    Talking,
    Inventory,
    Horror,
    Block,
    Size,
}

public struct StateMachine
{
    public StateName stateName;
    public State state;
}

public class InputManager : SingleTon<InputManager>
{
    [SerializeField]
    private List<StateMachine> allState = new List<StateMachine>();

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
}
