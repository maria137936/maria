using Godot;
using System;

public partial class SelectionArea : Area3D
{
	private Node character ; 
	[Signal]
	public delegate void CharacterSelectedSignalEventHandler(string myString);
	private Node3D character_selection_scene; 

	public override void _Ready()
	{
		character = GetParent();
		character_selection_scene = GetTree().Root.GetNode<Node3D>("CharacterSelection");
		// Connecter le signal à la méthode CharacterSelected dans character_selection_scene
		if (character_selection_scene != null)
		{
			var callable = new Callable(character_selection_scene, nameof(character_selection.CharacterSelected));
			Connect(nameof(CharacterSelectedSignal), callable);
		}else{
			GD.Print("character_selection_scene est null");
		}
		switch(character.Name){
			case "Playersophia":
				character.GetNode<AnimationPlayer>("mini_sophia/AnimationPlayer").Play("idle");
				break;
			case "PlayerGobot":
				character.GetNode<AnimationPlayer>("gobot/AnimationPlayer").Play("Idle");
				break;
			case "PlayerGDbot":
				character.GetNode<AnimationPlayer>("gdbot/AnimationPlayer").Play("Idle");
				break;
			default:
				break;
		}
	}

	private void _on_input_event(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shape_idx)
	{
		if (Input.IsActionPressed("mouse_click")){
			EmitSignal(SignalName.CharacterSelectedSignal,character.Name );
			GetNode<MeshInstance3D>("Selection").Show();
		}

	}

}



