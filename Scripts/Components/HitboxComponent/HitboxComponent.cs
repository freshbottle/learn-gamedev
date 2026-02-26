using Godot;
using System;

namespace Scripts.Components;
public partial class HitboxComponent : Area3D
{
    [Export]
    private float DamageStats = 2.5f;
    private CollisionShape3D _collisionShape;

    public override void _Ready()
    {
       _collisionShape = GetNode<CollisionShape3D>("CollisionShape3D");
       if (_collisionShape == null) return;
       
       // Only trigger signal if area collided with is a hurtbox.
       // Other areas should be excluded.
       AreaEntered += area =>
       {
           if (area is not HurtboxComponent hurtbox) return;
           hurtbox.TakeDamage(DamageStats);
       };
    }
}
