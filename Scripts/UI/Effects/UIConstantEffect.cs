using Godot;
using System;

public partial class UIConstantEffect : Control {

	[Export] private UIEffect effect;

	private float animationTime;

	public override void _Process(double delta) {
		animationTime += (float) delta;
		effect?.PlayEffect(this, animationTime);
	}
}
