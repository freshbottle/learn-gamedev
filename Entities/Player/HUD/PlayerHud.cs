using Godot;
using System;

namespace Entities.Player.HUD;
public partial class PlayerHud : CanvasLayer
{
    private ProgressBar _healthBar;
    private ColorRect _crosshair;

    public override void _Ready()
    {
        _healthBar = GetNode<ProgressBar>("HealthBar");
        _crosshair = GetNode<ColorRect>("Crosshair");
    }
}
