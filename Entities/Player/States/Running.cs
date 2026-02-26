using Godot;
using Scripts.Player.States;
using Scripts.StateMachine;

namespace Entities.Player.States;
public partial class Running : PlayerState
{
	public override void Enter()
	{
		GD.Print("Entered running state.");
		Player.MoveSpeed = 4.25f;
		Player.CanShoot = false;
		if (Player.HasWeapon) Player.Anim.Play("Running");
	}

	public override void PhysicsUpdate(double _delta)
	{
		if (Player.Velocity.Length() <= 0f)
		{
			EmitSignal(SignalName.Transitioned, this, "Idle");
		}
	}

	public override void Exit()
	{
		GD.Print("Exiting running state!");
		Player.CanShoot = true;
	}
}
