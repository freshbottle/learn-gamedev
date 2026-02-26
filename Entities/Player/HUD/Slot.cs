using Godot;
using Scripts;
using Scripts.Resources.Items;
using System;

namespace Entities.Player.HUD;

[GlobalClass]
public partial class Slot : Panel
{
    [Export]
    public ItemStack Stack { get; set; }
    
    [Export(PropertyHint.Range, "1, 4, ")]
    
    private int _slotNumber;
    
    private TextureRect _textureRect;
    
    private Label _slotLabel;

    private Label _amountLabel;


    public override void _Ready()
    {
        _textureRect = GetNode<TextureRect>("TextureRect");
        _slotLabel = GetNode<Label>("SlotLabel");
        _amountLabel = GetNode<Label>("AmountLabel");
        _slotLabel.Text = _slotNumber.ToString();
    }

    public void SetItem()
    {
        _textureRect.Texture = Stack.ConsumableItem.Image;
        _amountLabel.Text = Stack.Amount.ToString();
    }

    public void SetNumber(int number)
    {
        _slotNumber = number;
        _slotLabel.Text = _slotNumber.ToString();
    }
}
