using Godot;
using System;

public partial class victim : RigidBody2D
{
    [Export] public float speed = 20.0f;
    public Vector2 mousePosition;
    public Vector2 velocity;
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    public Vector2 slowingDrift = new Vector2(0, 5000);
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        mousePosition = GetViewport().GetMousePosition();
        velocity = new Vector2((this.GlobalPosition.X-mousePosition.X)*speed*-.2f, (this.GlobalPosition.Y-mousePosition.Y)*speed *-.2f);

		this.LinearVelocity = velocity;
	}


    public override void _PhysicsProcess(double delta)
    {
		//GD.Print(this.Position);

		//this.Position += new Vector2(velocity.X * (float) delta, velocity.Y * (float) delta);

        //velocity.Y += gravity * (float)delta * 2;
        //if (velocity.X > 0)
        //{
        //    velocity.X += -0.2f;
        //    if (velocity.X < 0) 
        //    { 
        //        velocity.X = 0;
        //    }
        //}
    }
}
