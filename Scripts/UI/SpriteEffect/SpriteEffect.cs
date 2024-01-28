using Godot;
using System;

public partial class SpriteEffect : PRBaseUIEffect<Sprite2D> {

	public override void PlayEffect(Sprite2D target, float animationTime) {

		if (growAnimation) {
			target.Scale = PlayGrowth(animationTime);
		}

		if (rotateAnimation) {
			target.RotationDegrees = PlayRotate(animationTime);
		}

	}

	public override void ResetEffect(Sprite2D target) {

		if (growAnimation) target.Scale = Vector2.One;
		if (rotateAnimation) target.RotationDegrees = 0;

	}

}
