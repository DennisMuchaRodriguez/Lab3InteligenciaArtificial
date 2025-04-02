using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : Humano
{
    private void Awake()
    {
        typestate = TypeState.Dormir;
        LocadComponent();
    }
    public override void LocadComponent()
    {
        base.LocadComponent();

    }
    public override void Enter()
    {

    }
    public override void Execute()
    {
        if (_DataAgent.Sleep.value < 0.25f)
        {
            _StateMachine.ChangeState(TypeState.Banno);
        }
        else
        {
            _DataAgent.DiscountSleep();
        }


        base.Execute();
    }
    public override void Exit()
    {

    }
}
