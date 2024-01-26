using Godot;
using System;

public partial class arrow : Sprite2D
{
    [Export] public Sprite2D Window;
    [Export] public Vector2 mousePosition;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        mousePosition = GetViewport().GetMousePosition();
        GD.Print(mousePosition);
        Vector2 rotationDifference = new Vector2(mousePosition.X - Window.Position.X, mousePosition.Y - Window.Position.Y);
        GD.Print(rotationDifference);
        this.Rotation = MathF.Atan2(rotationDifference.Y, rotationDifference.X);

        //this.Rotate(MathF.Atan2(rotationDifference.Y, rotationDifference.X));
    }
}
