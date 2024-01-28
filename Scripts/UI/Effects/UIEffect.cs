using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class UIEffect : PRBaseUIEffect<Control> {

	public override void PlayEffect(Control target, float animationTime) {

		if (growAnimation) {
			target.Scale = PlayGrowth(animationTime);
		}

		if (rotateAnimation) {
			target.RotationDegrees = PlayRotate(animationTime);
		}

	}

	public override void ResetEffect(Control target) {

		if (growAnimation) target.Scale = Vector2.One;
		if (rotateAnimation) target.RotationDegrees = 0;

	}

}
