using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class UIEffect : Resource {

	#region Inspector
	// Global properites
	[Export] private float speed = 1;
	[Export] private float strength = 1;

	// Animation Settings
	[ExportGroup("Animations")]

	// Grow/Stretch
	[Export, ExportSubgroup("Grow")] private bool growAnimation = false;
	[Export] private float growthSpeed = 1;
	[Export] private bool squashMode = false;
	[Export] private float squashOffset = 0.5f;
	[Export] private Curve growthCurve;

	// Rotation
	[Export, ExportSubgroup("Rotate")] private bool rotateAnimation = false;
	[Export] private float rotateSpeed = 1;
	[Export] private Curve rotateCurve;
	#endregion

	public void PlayEffect(Control target, float animationTime) {

		if (growAnimation) PlayGrowth(target, animationTime);
		if (rotateAnimation) PlayRotate(target, animationTime);

	}

	public void ResetEffect(Control target) {

		if (growAnimation) target.Scale = Vector2.One;
		if (rotateAnimation) target.RotationDegrees = 0;

	}

	private void PlayGrowth(Control target, float animationTime) {
		if (growthCurve == null) return;

		Vector2 scale;

		if (squashMode) {
			scale = new Vector2(growthCurve.Sample((animationTime * speed * growthSpeed) % 1), growthCurve.Sample(((animationTime * speed * growthSpeed) + squashOffset) % 1));
		} else {
			scale = Vector2.One * growthCurve.Sample((animationTime * speed * growthSpeed) % 1);
		}

		target.Scale = new Vector2((strength * scale.X) + (1 - strength), (strength * scale.Y) + (1 - strength));
	}

	private void PlayRotate(Control target, float animationTime) {
		if (rotateCurve == null) return;

		float rotation;

		rotation = strength * rotateCurve.Sample((animationTime * speed * rotateSpeed) % 1);

		target.RotationDegrees = rotation;
	}

}
