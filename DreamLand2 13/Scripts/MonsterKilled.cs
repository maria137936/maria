using Godot;
using System;

public partial class MonsterKilled : Label
{
	private int nbrMonsterKilled = 0 ;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Text = nbrMonsterKilled.ToString() ;
	}
	
	private void _on_monster_killed()
	{
		nbrMonsterKilled++ ;
		Text = nbrMonsterKilled.ToString() ;
	}
	private void _on_bee_killed()
	{
		nbrMonsterKilled++ ;
		Text = nbrMonsterKilled.ToString() ;
	}
	
}



