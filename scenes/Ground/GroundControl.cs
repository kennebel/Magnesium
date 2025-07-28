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
	[Export]
	public WorldControl World { get; set; }

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
		var MinMax = 15;

		int Count = 0;
		for (int i = -MinMax; i <= MinMax; i++)
		{
			for (int j = -MinMax; j <= MinMax; j++)
			{
				NewChild = GroundGrass.Instantiate<Node3D>();
				NewChild.Position = new Vector3(i, 0, j);
				NewChild.Name = "Ground Grass " + Count.ToString();

				TilesHolder.AddChild(NewChild);

				((GroundTileControl)NewChild).NotifyClick = World;

				Count++;
			}
		}
	}
}
