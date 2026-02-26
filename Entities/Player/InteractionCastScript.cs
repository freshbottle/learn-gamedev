using Godot;
using Scripts.InteractionSystem;
using System;

public partial class InteractionCastScript : RayCast3D
{
    private Label _interactLabel;

    public override void _Ready()
    {
        _interactLabel = GetNode<Label>("%InteractLabel");
    }

    public override void _Process(double delta)
    {
        if (IsColliding())
        {
            var collider = GetCollider();
            if (collider is InteractionArea area)
            {   
                // Only show interaction label if the hitscan is colliding with the interaction area
                _interactLabel.Show();

                // Actually call interact method in collided area
                if (Input.IsActionJustPressed("Interact"))
                {
                    area.Interact();
                }
            }
        }
        else
        {
            _interactLabel.Hide();
        }
    }
}
