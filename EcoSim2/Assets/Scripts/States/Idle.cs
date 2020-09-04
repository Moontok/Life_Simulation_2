using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Idle : IState
{

    AnimalBehavior animal = null;

    public Idle(AnimalBehavior animal)
    {
        this.animal = animal;
    }

    public void Tick()
    {

    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {
        
    }
}
