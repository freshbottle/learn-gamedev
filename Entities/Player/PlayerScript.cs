using Godot;
using Scripts;
using Scripts.Components;

namespace Entities.Player;
public partial class PlayerScript : CharacterBody3D
{
	[ExportCategory("Player properties")]
	[Export]
	public float MoveSpeed = 2f;

	[Export]
	public float JumpForce = 3f;

	[Export]
	private float _mouseSensitivity = 0.005f;
	[Export]
	public bool HasWeapon = false;

	public bool CanShoot = true;

	private float _gravity = -9.8f;

	[ExportCategory("Components")]
	[Export]
	private HealthComponent _healthComponent;

	[Export]
	private HurtboxComponent _hurtboxComponent;

	// References to child nodes.
	public AnimationPlayer Anim;
	private Camera3D _cam;
	private RayCast3D _interactionCast;

    public override void _EnterTree()
    {
		Anim = GetNode<AnimationPlayer>("%AnimationPlayer");
		if (Anim == null) GD.PushError("Missing animation node.");
    }

	public override void _Ready()
	{   
		// Makes sure the mouse cursor is invincible during gameplay. 
		Input.MouseMode = Input.MouseModeEnum.Captured;

		_cam = GetNode<Camera3D>("Head");
		if (_cam == null) GD.PushError("Missing camera node in player scene.");

		_interactionCast = GetNode<RayCast3D>("%InteractionCast");
		if (_interactionCast == null) GD.PushError("Missing hitscan node.");
		
		_healthComponent.Destroyed += DoSomethingWhenDestroyed;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("Escape"))
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}

		if (@event.IsActionPressed("LeftClick"))
		{
			if (Input.MouseMode == Input.MouseModeEnum.Visible)
			{
				Input.MouseMode = Input.MouseModeEnum.Captured;
			}
		}

		HandleCamera(@event);
	}


	public override void _PhysicsProcess(double delta)
	{
		Movement(delta);
	}

	private void HandleCamera(InputEvent @event)
	{
		if (@event is not InputEventMouseMotion eventMouseMotion) return;

		// When the mouse moves on the x-axis, rotate the camera in the y-axis direction.
		RotateY(-eventMouseMotion.Relative.X * _mouseSensitivity);
		_cam.RotateX(-eventMouseMotion.Relative.Y * _mouseSensitivity);
		var camRotation = _cam.Rotation;
		camRotation.X = Mathf.Clamp(camRotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(90));
		_cam.Rotation = camRotation;
	}

	private void Movement(double delta)
	{
		var direction = Input.GetVector("Left", "Right", "Forward", "Back");
		
		// Retrieve the Velocity struct first, and modify it later in the method.
		var velocity = Velocity;
		velocity = Transform.Basis * new Vector3
			(
				direction.X * MoveSpeed, 
				velocity.Y, 
				direction.Y * MoveSpeed
			);

		// Apply constant gravity if the player is in the air.
		if (!IsOnFloor())
		{
			velocity.Y += _gravity * (float)delta;
		}

		// Jump input.
		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y = JumpForce;
		}

		// Apply all the changes back to Velocity
		Velocity = velocity;
		MoveAndSlide();
	}

	private void DoSomethingWhenDestroyed()
	{
		GD.Print("HELLO");
	}
}
