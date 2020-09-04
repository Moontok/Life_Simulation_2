using System;

public class Transition
{
    Func<bool> condition = null;
    IState transitionTo = null;

    public Transition(IState to, Func<bool> newCondition)
    {
        transitionTo = to;
        condition = newCondition;
    }

    public bool GetCondition()
    {
        return condition();
    }

    public IState GetTransition()
    {
        return transitionTo;
    }
}
