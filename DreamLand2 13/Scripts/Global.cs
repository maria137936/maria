using Godot;
using System;

public partial class Global : Node
{
	public string playerCharacter { get; private set; }
	
	// propriété
	public void SetPlayerCharacter(string name) {
		playerCharacter = name;
	}
}
