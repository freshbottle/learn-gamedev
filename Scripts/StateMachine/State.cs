using Godot;
using System;

namespace Scripts.StateMachine;

[GlobalClass]
public abstract partial class State : Node
{
    [Signal]
    public delegate void TransitionedEventHandler(State state, string newState);
    public virtual void Enter() {}
    public virtual void Exit() {}
    public virtual void HandleInput(InputEvent _event) {}
    public virtual void Update(double _delta) {}
    public virtual void PhysicsUpdate(double _delta) {}
}
