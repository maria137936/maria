using Godot;
using System;

public partial class paused_menu : Control
{	
	private World1 world1Script;
	private World2 world2Script;
	
	
	private void Set_paused(bool value) 
	{
		GetTree().Paused = value ;
		if (value) 
		{
			Show() ; 
		}
		else 
		{
			Hide() ;
		}
	}
	
	public override void _Ready() 
	{
		ProcessMode = Node.ProcessModeEnum.WhenPaused;
		Set_paused(false);
	}
	
	private void _on_resume_btn_pressed()
	{
		GD.Print("bouton resume") ;
		Set_paused(false) ;
	}


	private void _on_restart_btn_pressed()
	{
		
		string currentScenePath = GetTree().CurrentScene.SceneFilePath;
		GD.Print(currentScenePath) ;
		if (!string.IsNullOrEmpty(currentScenePath))
		{
			Set_paused(false);
			world1Script = GetNode<World1>("/root/World1");
			world1Script.destroyedMobs = 0 ; 
			world2Script = GetNode<World2>("/root/World2");
			world2Script.destroyedMobs2 = 0 ; 
			GetTree().ReloadCurrentScene();
		}
		
	}

	private void _on_quit_btn_pressed()
	{
		Set_paused(false);
		GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
	}

	private void _on_pause_btn_pressed()
	{
		Set_paused(true);
	}
	
}









