using Godot;
using System;

public partial class chest : StaticBody3D
{   
	World1 world1Script; 
	World2 world2Script; 
	
	public override void _Ready()
	{
		world1Script = GetNode<World1>("/root/World1");
		world2Script = GetNode<World2>("/root/World2");
		world1Script.facingChest = false;
		world2Script.facingChest2 = false; 
		GetNode<Label3D>("Instruction").Visible = false;
	}
	
	private void _on_area_3d_area_entered(Area3D area)
	{
		if (area.Name == "Area3DSophia" || area.Name == "Area3DGobot" || area.Name == "Area3DGDbot")
		{
			GD.Print("Devant le coffre");
			if (GetNode<Node3D>("../..").Name == "world2"){
				world2Script.facingChest2 = true;
				
				if(world2Script.destroyedMobs2 != 6){
					GetNode<Label3D>("Instruction").Text = "You need to kill all the monsters";
				}else{
					GetNode<Label3D>("Instruction").Text = "Tap [E] to open the chest";
				}
			}
			else{
				GD.Print($"{GetNode<Node3D>("../..").Name}");
				world1Script.facingChest = true;
			}
			
			GetNode<Label3D>("Instruction").Visible = true;
		}
	}

	private void _on_area_3d_area_exited(Area3D area)
	{
		if (area.Name == "Area3DSophia" || area.Name == "Area3DGobot" || area.Name == "Area3DGDbot")
		{
			GD.Print("Pas Devant le coffre");
			if (GetNode<Node3D>("../..").Name == "world2"){
				world2Script.facingChest2 = false;
			}else{
				world1Script.facingChest = false;
			}
			
			GetNode<Label3D>("Instruction").Visible = false;
		} 
	}
}
