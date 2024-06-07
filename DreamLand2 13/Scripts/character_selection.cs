using Godot;
using System;

public partial class character_selection : Node3D
{
	string current_selected_character_name ; 
	public readonly PackedScene selection_area = ResourceLoader.Load<PackedScene>("res://Prefabs/selection_area.tscn");
	Global globalScript;
	
	public override void _Ready()
	{
		globalScript = GetNode<Global>("/root/Global");
		foreach(Node3D character in GetNode("Characters").GetChildren() ) {
			var selection_area_ins = selection_area.Instantiate() ;
			character.AddChild(selection_area_ins) ; 
			var selection = selection_area_ins.GetNode<MeshInstance3D>("Selection");
			// Set the scale of the selection independently
			selection.Scale = new Vector3(1 / character.Scale.X, 1 / character.Scale.Y, 1 / character.Scale.Z);
			
		}
		CharacterSelected("Playersophia");
		
	}
	
	public void CharacterSelected(string character_name){
		current_selected_character_name = character_name;
		GetNode<Label>("CharacterLabel").Text = " " + current_selected_character_name.Substring(6);
		foreach (Node3D character in GetNode("Characters").GetChildren())
		{
			
			GD.Print("entered foreach loop");
			var selection = character.GetNode<Area3D>("SelectionArea").GetNode<MeshInstance3D>("Selection");
			if (selection != null)
			{
				GD.Print($"{character.Name}");
				if (character.Name == character_name)
				{
					
					selection.Show(); // Show the selection for the selected character
					GD.Print("show");
				}
				else
				{
					selection.Hide(); // Hide the selection for other characters
					GD.Print("hide");
				}
			}else{
				GD.Print("selection est null");
				
			}
			
		}
	}
	
	private void _on_texture_button_pressed()
	{
		if(current_selected_character_name != null && current_selected_character_name != "" ){
			globalScript.SetPlayerCharacter(current_selected_character_name);
			GetTree().ChangeSceneToFile("res://Scenes/world_1.tscn");
		}
	}
}



