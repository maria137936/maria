using Godot;
using System;

public partial class menuefin : Node2D
{
	private World1 world1Script;
	private World2 world2Script;
	

	private void _on_try_again_pressed()
	{
		world1Script = GetNode<World1>("/root/World1");
		world1Script.destroyedMobs = 0 ; 
		world2Script = GetNode<World2>("/root/World2");
		world2Script.destroyedMobs2 = 0 ;
		GetTree().ChangeSceneToFile("res://Scenes/world2.tscn");
		
	}

	private void _on_restart_pressed()
	{
		
		GetTree().ChangeSceneToFile("res://Scenes/world_1.tscn");
	}


	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}

	}



