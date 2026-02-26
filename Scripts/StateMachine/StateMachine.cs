using System;
using Godot;
using Godot.Collections;
using Scripts.StateMachine;

public partial class StateMachine : Node
{
    [Export]
    public State InitialState;

    private Dictionary<string, State> _states = [];
    private State _currentState;

    public override void _Ready()
    {
        // Get all the states nodes and store them in a dictionary
        foreach (var child in GetChildren())
        {
            if (child is State state)
            {
                _states[state.Name.ToString().ToLower()] = state;
                state.Transitioned += OnChildTransitioned;
            }
        }

        if (InitialState != null)
        {
            _currentState = InitialState;
            _currentState.Enter();
        }
    }

    public override void _Process(double delta)
    {
        _currentState?.Update(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        _currentState?.PhysicsUpdate(delta);
    }

    private void OnChildTransitioned(State state, string newStateName)
    {
        if (state != _currentState) return;

        var newState = _states[newStateName.ToLower()];
        if (newState == null) return;

        // Exit the previous state
        _currentState?.Exit();

        newState.Enter();
        _currentState = newState;
    }
}
