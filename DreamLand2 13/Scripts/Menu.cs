using Godot;
using System;

public partial class Menu : Control
{
	
	public override void _Ready()
	{
		GetNode<Menu>("StartButton").GrabFocus();
	}
	private void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/world_1.tscn");
	}
	private void _on_quit_button_pressed()
	{
		 GetTree().Quit();
	}
	
	private void _on_character_selection_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/character_selection.tscn");
	}
	
	private void _on_help_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/rules.tscn");
	}
	
}












