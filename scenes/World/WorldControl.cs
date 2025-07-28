using Godot;
using System;

public partial class WorldControl : Node
{
    [Export]
    public PackedScene WireframeCube { get; set; }
    [Export]
    public Node3D UIElementsHolder { get; set; }

    public Node3D ClickedOn{ get; set; }
    public CubeWireframeControl SelectionIndicator { get; set; }

    public override void _Ready()
    {
        SelectionIndicator = WireframeCube.Instantiate<CubeWireframeControl>();
        UIElementsHolder.AddChild(SelectionIndicator);
        SelectionIndicator.Visible = false;
    }

    public override void _Process(double delta)
    {
    }

    public void TileClicked(Node3D clicked)
    {
        GD.Print("Clicked nameD: ", clicked.Name);
        if (clicked == ClickedOn)
        {
            ClickedOn = null;
            SelectionIndicator.Visible = false;
        }
        else
        {
            ClickedOn = clicked;
            SelectionIndicator.GlobalPosition = ClickedOn.GlobalPosition;
            SelectionIndicator.Visible = true;

            SelectionIndicator.Offset = ClickedOn is GroundTileControl;
        }
    }
}
