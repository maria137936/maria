using Godot;
using System;


public partial class PlayerGDbotController : CharacterBody3D
{
	[Export] int life = 3; // Vie du player
	[Export] float speed = 20f; // Vitesse de marche
	float extraSpeed = 1f;
	[Export] float acceleration = 15f;
	[Export] float airAcceleration = 5f;
	[Export] float gravity = 1f; // Force de la gravité
	[Export] float maxTerminalVelocity = 55f;
	[Export] float jumpForce = 20f; // Vitesse du saut
	int score = 10 ;
	
	
	[Export(PropertyHint.Range, "0.1,1.0")]  
	float mouseSensivity = 0.3f;
	[Export(PropertyHint.Range, "-90,0,1")] 
	float minPitch = 0f;
	[Export(PropertyHint.Range, "0,90,1")] 
	float maxPitch = 90f;
	bool bounce = false; // Rebondir sur un mob
	
	Vector3 velocity; // Vitesse + direction
	float yVelocity;
	[Export]Node3D cameraPivot;
	[Export]Camera3D camera;
	[Export]AnimationPlayer animationPlayer;
	
	private World1 world1Script;
	private World2 world2Script;
	
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		animationPlayer.Play("Idle");
	}
	
	public override void _Process(double delta)
	{
		if ( Position.Y < 1)
		{
			Restart(); 
		}
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion motionEvent)
		{
			Vector3 rotDeg = RotationDegrees;
			rotDeg.Y -= motionEvent.Relative.X * mouseSensivity;
			RotationDegrees = rotDeg;
			
			rotDeg = cameraPivot.RotationDegrees;
			rotDeg.X -= motionEvent.Relative.Y * -mouseSensivity;
			rotDeg.X = Mathf.Clamp(rotDeg.X, minPitch, maxPitch);
			cameraPivot.RotationDegrees = rotDeg; 
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		HandleMovement(delta);
		if (Input.IsActionJustPressed("action"))
		{
			var world1Script = GetNode<World1>("/root/World1");
			var world2Script = GetNode<World2>("/root/World2"); 

			if (world1Script.facingChest)
			{
				GD.Print("J'ouvre un coffre dans le monde 1");
				GetParent().GetNode<StaticBody3D>("InteractableObjects/chest").QueueFree();
			}
			if (world2Script.facingChest2 &&  world2Script.destroyedMobs2 == 6)
			{
				GD.Print("J'ouvre un coffre dans le monde 2");
				GetParent().GetNode<StaticBody3D>("InteractableObjects/chest").QueueFree();
			}
		}

		
	}
	private async void HandleMovement(double delta)
	{
		Vector3 direction = new Vector3(0,0,0);
		
		if (Input.IsActionPressed("move_up"))
			direction += Transform.Basis.Z;
		if (Input.IsActionPressed("move_down"))
			direction -= Transform.Basis.Z;
		if (Input.IsActionPressed("move_left"))
			direction += Transform.Basis.X;
		if (Input.IsActionPressed("move_right"))
			direction -= Transform.Basis.X;
		if (Input.IsActionPressed("run")) {
			extraSpeed = 3f;
		} else {
			extraSpeed = 2f;
		}
	
		direction = direction.Normalized();
		
		float accel = IsOnFloor() ? acceleration : airAcceleration;
		velocity = direction * speed * accel * extraSpeed; 
		
		if (bounce)
		{
			yVelocity = jumpForce;
			bounce = false;
		}
		else
		{
			if (IsOnFloor())
			{
				yVelocity = -0.01f; 
			}
			else
			{
				yVelocity = Mathf.Clamp(yVelocity-gravity, -maxTerminalVelocity, maxTerminalVelocity);
				animationPlayer.Play("fall");
				
			}
		}
		
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			yVelocity = jumpForce;
			
		
		velocity.Y = yVelocity;
		Velocity = velocity;
		MoveAndSlide();
		
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			// GD.Print("I collided with ", ((Node)collision.GetCollider()).Name);
		}

		
		if (direction != new Vector3(0,0,0) && IsOnFloor())
		{
			if (extraSpeed == 3f)
			{
				animationPlayer.Play("run");
			}
			else 
			{
				animationPlayer.Play("walk");
			}
		} 
		else if (direction == new Vector3(0,0,0) && IsOnFloor())
		{
			animationPlayer.Play("Idle");
		}
		
		
	}
	
	public void TakeDamages()
	{
		GD.Print("TakeDamages!");
		
		life --;
		
		if (life <= 0)
			world1Script = GetNode<World1>("/root/World1");
			world1Script.destroyedMobs = 0 ; 
			world2Script = GetNode<World2>("/root/World2");
			world2Script.destroyedMobs2 = 0 ; 
			GetTree().ReloadCurrentScene();
	}


	private void _on_area_3d_gdbot_area_entered(Area3D area)
	{
		if (area.Name == "Area3DTop")
		{
			bounce = true ;
		}
	}

	public void Restart()
	{
		world1Script = GetNode<World1>("/root/World1");
		world1Script.destroyedMobs = 0 ; 
		GetTree().ReloadCurrentScene();
	}
		
			
}

















