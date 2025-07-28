using Godot;
using System;

public partial class GroundControl : Node3D
{
	[ExportGroup("Assets")]
	[Export]
	public PackedScene GroundGrass { get; set; }
	[Export]
	public PackedScene[] GroundPaths{ get; set; }
	[Export]
	public PackedScene[] GroundRivers{ get; set; }

	[ExportGroup("Scene")]
	[Export]
	public Node3D TilesHolder{ get; set; }

	public override void _Ready()
	{
		GreenField();
	}

	public override void _Process(double delta)
	{
	}

	public void GreenField()
	{
		Utilities.RemoveChildren(TilesHolder);

		Node3D NewChild;
		for (int i = -5; i <= 5; i++)
		{
			for (int j = -5; j <= 5; j++)
			{
				NewChild = GroundGrass.Instantiate<Node3D>();
				NewChild.Position = new Vector3(i, 0, j);

				TilesHolder.AddChild(NewChild);
			}
		}
	}
}
