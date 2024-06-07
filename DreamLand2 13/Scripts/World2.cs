using Godot;
using System;

public partial class World2 : Node
{
	
	public bool facingChest2 = false;
	public bool haveJewel = false;
	public int destroyedMobs2 = 0;
	public int nbCoins2 = 0;
	
	 public override void _Ready()
	{
		AddUserSignal("CoinsChanged");
		destroyedMobs2 = 0;
	}
	
	public void AddCoin()
{
	nbCoins2++;
	
	
}
	public void PrintScore()
	{
		int score= 0;
		score += nbCoins2 * 10;
		score += destroyedMobs2 * 100;
		GD.Print("Score final = " + score);
	}
	public int GetScore()
	{
		int score = nbCoins2 * 10 + destroyedMobs2 * 100;
		return score;
	}
}

