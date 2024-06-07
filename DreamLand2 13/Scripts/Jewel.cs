using Godot;
using System;

public partial class Jewel : Node3D
{
	
	private void _on_area_3d_area_entered(Area3D area)
{
	string col = area.GetParent().Name;
		GD.Print(col);
		GD.Print(area.Name);
		
		if (col == "PlayerSophiaCtrl" || col == "PlayerGobotCtrl" || col == "PlayerGDbotCtrl")
		{
			GD.Print("entrer la boucle de col");
			var world2Script = GetNode<World2>("/root/World2");
			world2Script.haveJewel = true;
			QueueFree();
			if (world2Script.destroyedMobs2 == 6 && world2Script.haveJewel )
			{
				GD.Print("dans la boucle showendmenufin");
				ShowEndLevelMenufin();
			}else{
				GD.Print($"pas pu montrer le menu de fin . nombre de monstre tuée : {world2Script.destroyedMobs2}");
			}
		}
	}
	public override void _Process(double delta)
	{
		RotateY((float)delta * 5);
	}
	
	private async void ShowEndLevelMenufin()
	{
		GD.Print("Affichage du menu de fin de niveau car on a trouvé jewel.");
		Input.MouseMode = Input.MouseModeEnum.Visible;
		GetTree().ChangeSceneToFile("res://Scenes/menuefin.tscn");
	}

}




