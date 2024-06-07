using Godot;
using System;

public partial class HeartFull : TextureRect
{
	// Reference au node TextureRect
	private TextureRect textureRect;
	private int max_heart = 3 ; 
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	

	// Ajuster la taille du TextureRect en fonction de max_heart
		Size = new Vector2(53 * max_heart, 45);
		 
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_monster_collision_with_bottom()
	{
		max_heart = max_heart - 1 ; 
		Size = new Vector2(53 * max_heart, 45);
	}
	
	private void _on_bee_collision_with_bottom()
	{
		max_heart = max_heart - 1 ; 
		Size = new Vector2(53 * max_heart, 45);
	}
}



