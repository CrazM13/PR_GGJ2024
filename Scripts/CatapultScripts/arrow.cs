using Godot;
using System;


public partial class arrow : Sprite2D
{
    [Export] public Sprite2D Window;
    [Export] public Vector2 mousePosition;
    private float rotationAngle;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        mousePosition = GetViewport().GetMousePosition();
        Vector2 rotationDifference = new Vector2(mousePosition.X - Window.Position.X, mousePosition.Y - Window.Position.Y);
        rotationAngle = MathF.Atan2(rotationDifference.Y, rotationDifference.X);
        GD.Print(rotationAngle);
        if (rotationAngle > -1 && rotationAngle < .5) 
        {
            this.Rotation = rotationAngle;
        }

        //this.Rotate(MathF.Atan2(rotationDifference.Y, rotationDifference.X));
    }

    public float getRotation()
    {
        return rotationAngle;
    }
}
