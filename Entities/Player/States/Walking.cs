using Godot;
using Scripts.Player.States;
using Scripts.StateMachine;
namespace Entities.Player.States;

public partial class Walking : PlayerState
{
    public override void Enter()
    {
        GD.Print("Entered walking state.");
        if (Player.HasWeapon) Player.Anim.Stop();
    }

    public override void PhysicsUpdate(double _delta)
    {
        if (Player.Velocity.Length() <= 0f)
		{
			EmitSignal(SignalName.Transitioned, this, "Idle");
		}
        
        if (Input.IsActionJustPressed("Shift"))
        {
            EmitSignal(SignalName.Transitioned, this, "Running");
        }
    }
    
    public override void Exit()
    {
        GD.Print("Exiting walking state.");
    }

}
