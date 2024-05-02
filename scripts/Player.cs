using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public string CurrentDirection = "idle";
	// public const float JumpVelocity = -400.0f;

	// // Get the gravity from the project settings to be synced with RigidBody nodes.
	// public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _Ready()
	{

	}
	public override void _PhysicsProcess(double delta)
	{
		PlayerMovement(delta);
		// // Add the gravity.
		// if (!IsOnFloor())
		// 	velocity.Y += gravity * (float)delta;

		// // Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// 	velocity.Y = JumpVelocity;

		// // Get the input direction and handle the movement/deceleration.
		// // As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		// if (direction != Vector2.Zero)
		// {
		// 	velocity.X = direction.X * Speed;
		// }
		// else
		// {
		// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		// }
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
}
