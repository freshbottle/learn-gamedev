using Godot;
using Scripts.Player.States;
using System;

namespace Entities.Player.States;

public partial class Idle : PlayerState
{
    public override void Enter()
    {
        GD.Print("Entered idle state.");
        if (Player.HasWeapon) Player.Anim.Play("Idle");
        Player.MoveSpeed = 2f;
    }

    public override void PhysicsUpdate(double _delta)
    {
        if (Input.IsActionJustPressed("Shift"))
        {
            EmitSignal(SignalName.Transitioned, this, "Running");
        }

        var direction = Input.GetVector("Left", "Right", "Forward", "Back");
        if (direction.Length() != 0)
        {
            EmitSignal(SignalName.Transitioned, this, "Walking");
        }
    }


    public override void Exit()
    {
        GD.Print("Exiting idle state.");
    }
}
