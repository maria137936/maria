using Godot;
using System;

public partial class DoorSystem : Node3D
{
	[Export] public StaticBody3D closedDoor;
	private World1 world1Script;

	public override void _Ready()
	{
		world1Script = GetNode<World1>("/root/World1");
		
	}

	private void _on_area_3d_area_entered(Area3D area)
	{
		GD.Print("Devant la porte");
		if (world1Script.haveKey && world1Script.destroyedMobs == 3)
		{
			closedDoor.QueueFree();
			world1Script.haveKey = false;
			GD.Print(world1Script.destroyedMobs) ;
			ShowEndLevelMenu();
			
		}
		
	}
	
	
	
	

	private async void ShowEndLevelMenu()
	{
		GD.Print("Affichage du menu de fin de niveau car tous les monstres sont morts et la porte est ouverte.");
		await ToSignal(GetTree().CreateTimer(3.0f), "timeout");
		Input.MouseMode = Input.MouseModeEnum.Visible;
		GetTree().ChangeSceneToFile("res://Scenes/end_menu1.tscn");
	}
}




