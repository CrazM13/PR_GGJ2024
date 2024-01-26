using Godot;
using System;

public partial class SpriteConstantEffect : Sprite2D {

	[Export] private float timeOffset = 1;
	[Export] private SpriteEffect effect;

	private float animationTime;

	public override void _Ready() {

		animationTime = timeOffset;

		base._Ready();
	}

	public override void _Process(double delta) {
		animationTime += (float) delta;
		effect?.PlayEffect(this, animationTime);
	}
}