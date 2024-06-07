using Godot;
using System;

public partial class world_1 : Node3D
{
	private PackedScene player;
	Global globalScript;
	
	public override void _Ready()
	{
		globalScript = GetNode<Global>("/root/Global");
		GetPlayerCharacter();
		var player_ins = (CharacterBody3D)player.Instantiate();
		switch(globalScript.playerCharacter){
			case "Playersophia":
				player_ins.Name = "PlayerSophiaCtrl";
				break;
			case "PlayerGobot":
				player_ins.Name = "PlayerGobotCtrl";
				break;
			case "PlayerGDbot":
				player_ins.Name = "PlayerGDbotCtrl";
				break;
			default:
				player_ins.Name = "PlayerSophiaCtrl";
				break;
		}
		AddChild(player_ins);
		player_ins.Position = GetNode<Marker3D>("PlayerPosition").Position;
		
	}
	
	public void GetPlayerCharacter(){
		switch(globalScript.playerCharacter){
			case "Playersophia":
				player = GD.Load<PackedScene>("res://Prefabs/player_sophia_ctrl.tscn");
				break;
			case "PlayerGobot":
				player = GD.Load<PackedScene>("res://Prefabs/player_gobot_ctrl.tscn");
				break;
			case "PlayerGDbot":
				player = GD.Load<PackedScene>("res://Prefabs/player_gdbot_ctrl.tscn");
				break;
			default:
				player = GD.Load<PackedScene>("res://Prefabs/player_sophia_ctrl.tscn");
				break;
		}
	}
}
