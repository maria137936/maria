using Godot;
using System;

public partial class buttonRound : Node3D
{
	
	[Export] moving_platform_animated platform;

	public override void _Ready(){
		platform = GetNode<moving_platform_animated>("../MovingPlatformAnimated");
	}
	private void _on_area_3d_area_entered(Area3D area)
	{
		GD.Print("area provenant de bouton") ;
		string col = area.GetParent().Name;
		GD.Print("Area entered by: " + col); // Debug log
	
		if (col == "PlayerSophiaCtrl" || col == "PlayerGobotCtrl" || col == "PlayerGDbotCtrl")
		{
			GetNode<MeshInstance3D>("buttonRound2/knob").QueueFree();
			GD.Print("Button pressed, playing animation."); // Debug log
			platform.PlayAnim();
		}
	}

	
}



