using System;
using System.Collections.Generic;

public class StateMachine
{
    
    IState currentState = null;

    Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
    List<Transition> currentTransitions = new List<Transition>();
    List<Transition> anyTransitions = new List<Transition>();

    static List<Transition> EmptyTransitions = new List<Transition>(0);

    public void Tick()
    {
        Transition transition = GetTransition();
        
        if(transition != null) SetState(transition.GetTransition());

        if(currentState != null) currentState.Tick(); //currentState?.Tick();
    }

    public void SetState(IState state)
    {
        if(state == currentState) return;

        if(currentState != null) currentState.OnExit(); //currentState?.Onexit();
        currentState = state;

        transitions.TryGetValue(currentState.GetType(), out currentTransitions);

        if(currentTransitions == null)
        {
            currentTransitions = EmptyTransitions;
        }

        currentState.OnEnter();
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        anyTransitions.Add(new Transition(state, predicate));
    }

    Transition GetTransition()
    {
        foreach(Transition transition in anyTransitions)
        {
            if(transition.GetCondition()) return transition;
        }

        foreach(Transition transition in currentTransitions)
        {
            if(transition.GetCondition()) return transition;
        }

        return null;
    }
}
