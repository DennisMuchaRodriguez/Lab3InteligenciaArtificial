using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : Humano
{
    private void Awake()
    {
        typestate = TypeState.Comer;
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


        base.Execute();
    }
    public override void Exit()
    {

    }
}
