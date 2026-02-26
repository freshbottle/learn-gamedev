using Godot;
using System;
using Scripts.StateMachine;
using Entities.Player;
using System.Diagnostics;

namespace Scripts.Player.States;

[GlobalClass]
public abstract partial class PlayerState : State
{
    protected PlayerScript Player;

    public override void _Ready()
    {
        Player = GetOwner<PlayerScript>();
    }
}
