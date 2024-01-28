using Godot;
using System;

public partial class Launch : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] private Timer changeSceneTimer;
	[Export] private AudioStreamPlayer audio;
	[Export] private PlayRandom scream;

    [Export] public int VelocityX;
    [Export] public int VelocityY;
    private bool isSpawned = false;
    private Node victim;
	private Node Peffect;

	private bool wasMousePressed = true;

    public override void _Ready()
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
		bool isMousePressed = Input.IsMouseButtonPressed(MouseButton.Left);

		if (!wasMousePressed && isMousePressed)
        {
			if (isSpawned == false)
			{
				// DEBUG // GD.Print("Space is pressed.");
				isSpawned = true;
				PackedScene scene = GD.Load<PackedScene>("res://Assets/Launch/victim.tscn");
				PackedScene effect = GD.Load<PackedScene>("res://Assets/Catapult Assets/Shatter_Effect.tscn");
				Node node = scene.Instantiate();
                GpuParticles2D PE = effect.Instantiate() as GpuParticles2D;
				AddChild(node);
				GetNode("/root").AddChild(PE);
				PE.Position = this.GlobalPosition;
				PE.Emitting = true;
				victim = node;
				Peffect = PE;
				

				changeSceneTimer.Start();
				audio.Play();
				scream.PlayRandomAudio();
			}
        }

		wasMousePressed = isMousePressed;

	}
}
