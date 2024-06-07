using Godot;
using System;

public partial class moving_platform_animated : Node3D
{
	[Export] AnimationPlayer animator;
	
	public void PlayAnim()
	{
		
		animator.Play("bloc_ping_pong");
	}

}
