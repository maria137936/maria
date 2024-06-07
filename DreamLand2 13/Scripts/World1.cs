using Godot;
using System;

public partial class World1 : Node
{
	public bool facingChest = false;
	public bool haveKey = false;
	public int destroyedMobs = 0;
	public int nbCoins = 0;
	
	
	 public override void _Ready()
	{
		AddUserSignal("CoinsChanged");
		destroyedMobs = 0;
	}
	
	public void AddCoin()
{
	nbCoins++;
	// Supposons que vous avez une référence à GUI stockée dans une variable gui
	
}
	public void PrintScore()
	{
		int score= 0;
		score += nbCoins * 10;
		score += destroyedMobs * 100;
		GD.Print("Score final = " + score);
	}
	public int GetScore()
	{
		int score = nbCoins * 10 + destroyedMobs * 100;
		return score;
	}
	
	
}
