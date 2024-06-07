using Godot;
using System;

public partial class Mob1 : CharacterBody3D
{
	[Signal]
	public delegate void CollisionWithBottomEventHandler() ; // event quand le joueur est attaqué par le monstre 
	[Signal]
	public delegate void MonsterKilledEventHandler() ;
	int life = 2; 
	[Export]
	public Node3D[] points;
	int actualPoint = 0;
	[Export] float speed = 0.7f;
	[Export] AnimationPlayer animPlayer;
	bool canWait = true;
	private ProgressBar progress_bar;
	
	
	
	public override void _Ready()
	{
		// initalisation de HealthBar
		progress_bar = GetNode<SubViewport>("SubViewport").GetNode<ProgressBar>("HealthBar");
		progress_bar.MaxValue = life;
		UpdateHealthBar();
		animPlayer.Play("walk");
	}
	
	private void _on_area_3d_top_area_entered(Area3D area)
	{
		if (area.Name == "Area3DSophia" || area.Name == "Area3DGobot" || area.Name == "Area3DGDbot" )
		{
			life--;
			UpdateHealthBar();
			if (life <= 0)
			{
				var world1Script = GetNode<World1>("/root/World1");
				world1Script.destroyedMobs++;
				EmitSignal(SignalName.MonsterKilled) ;
				QueueFree();
			}
		}
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		var dir = (points[actualPoint].Position - Position).Normalized();
		dir.Y = 0;
		
		if (Position.DistanceTo(points[actualPoint].Position) >= 0.5f)
		{
			animPlayer.Play("walk");
			Velocity = dir * speed;
			MoveAndSlide(); 
		} else
		{
			if (canWait)
				WaitBeforeContinue();
		}
		
		LookAt(points[actualPoint].GlobalTransform.Origin, Vector3.Up);
		RotateObjectLocal(Vector3.Up, 3.14f);
	}
	
	private async void WaitBeforeContinue()
	{
		canWait = false;
		await ToSignal(GetTree().CreateTimer(2.0f), "timeout");
		GD.Print("2 second delay!");
		actualPoint++;
		if (actualPoint > points.Length - 1)
		{
			actualPoint = 0;
		}
		canWait = true;
	}
	
	private void _on_area_3d_bottom_area_entered(Area3D area)
	{
		if (area.GetParent().HasMethod("TakeDamages"))
		{
			area.GetParent().Call("TakeDamages");
			EmitSignal(SignalName.CollisionWithBottom) ; 
		}
	}
	
	private void UpdateHealthBar()
	{
		progress_bar.Value = life;
	}

}

