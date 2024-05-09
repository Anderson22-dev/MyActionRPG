using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public string CurrentDirection = "idle";
	public static Vector2 PlayerPosition;
	public bool SlimeAttackCooldown = true;
	public bool SlimeIsInAttackRange = false;
	public override void _Ready()
	{

	}
	public override void _PhysicsProcess(double delta)
	{
		PlayerPosition = Position;
		PlayerMovement(delta);
		IsHited();
	}
	public void PlayerMovement(double delta){
		Vector2 velocity = Velocity;

		if(Input.IsActionPressed("ui_right")){
			CurrentDirection = "right";
			PlayerAnimation(1);
			velocity.X = Speed;
			velocity.Y = 0;


		} else if(Input.IsActionPressed("ui_left")){
			CurrentDirection = "left";
			PlayerAnimation(1);
			velocity.X = -Speed;
			velocity.Y = 0;


		} else if(Input.IsActionPressed("ui_down")){
			CurrentDirection = "down";
			PlayerAnimation(1);
			velocity.X = 0;
			velocity.Y = Speed;


		} else if(Input.IsActionPressed("ui_up")){
			CurrentDirection = "up";
			PlayerAnimation(1);
			velocity.X = 0;
			velocity.Y = -Speed;


		} else{
			PlayerAnimation(0);
			velocity.X = 0;
			velocity.Y = 0;

		}

		Velocity = velocity;
		MoveAndSlide();

	}

	public void PlayerAnimation(int movement){
		var Direction = CurrentDirection;
		AnimatedSprite2D AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if(Direction == "right"){
			AnimatedSprite.FlipH = false;
			if(movement == 1){
				AnimatedSprite.Play("side_walk");
			} else if(movement == 0){
				AnimatedSprite.Play("side_idle");
			}
		}else if(Direction == "left"){
			AnimatedSprite.FlipH = true;
			if(movement == 1){
				AnimatedSprite.Play("side_walk");
			} else if(movement == 0){
				AnimatedSprite.Play("side_idle");
			}
		}else if(Direction == "down"){
			AnimatedSprite.FlipH = false;
			if(movement == 1){
				AnimatedSprite.Play("front_walk");
			} else if(movement == 0){
				AnimatedSprite.Play("front_idle");
			}
		}else if(Direction == "up"){
			AnimatedSprite.FlipH = false;
			if(movement == 1){
				AnimatedSprite.Play("back_walk");
			} else if(movement == 0){
				AnimatedSprite.Play("back_idle");
			}
		}

	}
	
	private void OnPlayerHitboxBodyEntered(Node2D body)
	{
		if(body.HasMethod("SlimeAttack")) SlimeIsInAttackRange = true;
		GD.Print("Player hitbox body entered");
	}
	private void OnPlayerHitboxBodyExited(Node2D body)
	{
		if(body.HasMethod("SlimeAttack")) SlimeIsInAttackRange = false;
	}

	private void IsHited(){
		if(SlimeIsInAttackRange && SlimeAttackCooldown) GD.Print("Slime attack");
		
	}
}






