using Godot;
using System;

public partial class CubeWireframeControl : Node3D
{
    [Export]
    public Node3D VisualItem{ get; set; }
    [Export]
    public float OffsetAmount{ get; set; }
    [Export]
    public bool Offset
    {
        get { return _Offset; }
        set
        {
            _Offset = value;

            if (_Offset)
            {
                VisualItem.Position = new Vector3(0, OffsetAmount, 0);
            }
            else
            {
                VisualItem.Position = Vector3.Zero;
            }
        }
    }

    private bool _Offset = false;
}
