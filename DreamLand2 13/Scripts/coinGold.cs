using Godot;
using System;

public partial class coinGold : Node3D
{
	[Signal]
	public delegate void CoinColletedEventHandler();
	
	public override void _Process(double delta)
	{
		RotateY((float)delta * 5);
	}
	
	
//		private void _on_area_3d_area_entered(Area3D area)
//	{	
//		// si on entre en collision avec sophie 
//		if (area.Name == "Area3DSophia") {
//			var world1Script = GetNode<World1>("/root/World1");  // necessaire ? 
//			world1Script.nbCoins++; // necessaire ? 
//
//			EmitSignal(SignalName.CoinColleted);
//			QueueFree();
//		}
//	}	
	
		private void _on_area_body_entered(Node3D body)
		{
			// Tente de caster le Node en CharacterBody3D
			GD.Print(body.Name);
			if (body is CharacterBody3D ) 
			{
				if (body.Name == "PlayerSophiaCtrl" || body.Name == "PlayerGobotCtrl" || body.Name == "PlayerGDbotCtrl" )
				{
					var world1Script = GetNode<World1>("/root/World1");  // necessaire ? 
					world1Script.nbCoins++; // necessaire ? 

					EmitSignal(SignalName.CoinColleted);
					QueueFree();
				}
			}
			
				
			
		}
	
	

	
	
	
}














