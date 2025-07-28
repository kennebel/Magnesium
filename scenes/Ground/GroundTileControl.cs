using Godot;
using System;

public partial class GroundTileControl : Node3D
{
    [Export]
    public WorldControl NotifyClick { get; set; }
    [Export]
    public CollisionObject3D Collider { get; set; }

    public override void _Ready()
    {
        Collider.InputEvent += TheInput;
    }

    private void TheInput(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx)
    {
        if (NotifyClick != null && (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left))
        {
            NotifyClick.TileClicked(this);
        }
    }
}
