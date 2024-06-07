using Godot;
using System;

public partial class Counter : Label
{
	 private int coins = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Text = coins.ToString() ; 
	}
	
	private void _on_coin_colleted()
	{
		coins = coins + 1 ; 
		Text = coins.ToString() ; 
		
	}
	
}















