using Godot;
using System;

public partial class key : Node3D
{
	private void _on_area_3d_area_entered(Area3D area)
	{
		string col = area.GetParent().Name;
		GD.Print(col);
		GD.Print(area.Name);
		
		if (col == "PlayerSophiaCtrl" || col == "PlayerGobotCtrl" || col == "PlayerGDbotCtrl")
		{
			var world1Script = GetNode<World1>("/root/World1");
			world1Script.haveKey = true;
			QueueFree();
		}
	}
	public override void _Process(double delta)
	{
		RotateY((float)delta * 5);
	}

}


