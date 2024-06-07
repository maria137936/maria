using Godot;
using System;

public partial class end_menu1 : Control
{
	private Label _scorelabel;
	private Label _enemieslabel;
	private World1 world1Script;
	
	public override void _Ready()
	{
		
		_scorelabel = GetNode<Label>("scorelabel");
		_enemieslabel = GetNode<Label>("enemieslabel");

	 
		UpdateUI();
	}

	private void UpdateUI()
	{
	   
		 var world1Script = GetNode<World1>("/root/World1");

	   
		if (world1Script != null)
		{
			_scorelabel.Text = "Score: " + world1Script.GetScore().ToString();
			_enemieslabel.Text = "Enemies Killed: " + world1Script.destroyedMobs.ToString();
		}
	}

	private void _on_next_level_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/world2.tscn");
	}


	private void _on_restart_pressed()
	{
		world1Script = GetNode<World1>("/root/World1");
		world1Script.destroyedMobs = 0 ; 
		GetTree().ChangeSceneToFile("res://Scenes/world_1.tscn");
	}

	private void _on_quit_pressed()
	{
		 GetTree().Quit();
	}
}






