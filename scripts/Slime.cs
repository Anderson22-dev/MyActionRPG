using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	public const float Speed = 150.0f;
	public bool PlayerDetected = false;
	public AnimatedSprite2D AnimatedSprite;

	public override void _Ready(){
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{

		if (PlayerDetected)
		{
			Position += (Player.PlayerPosition - Position)/Speed;
			AnimatedSprite.Play("walk");

			if(Player.PlayerPosition.X < Position.X)AnimatedSprite.FlipH = true;
			else AnimatedSprite.FlipH = false;
			
		}
		else AnimatedSprite.Play("idle");
		

	}

	private void OnDetectionAreaBodyEntered(Node2D body)
	{
		if (body.Name == "Player") PlayerDetected = true;
	}


	private void OnDetectionAreaBodyExited(Node2D body)
	{
		PlayerDetected = false;
	}
	
}



