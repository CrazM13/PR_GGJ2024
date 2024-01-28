using Godot;
using System;

public abstract partial class PRBaseUIEffect<T> : Resource where T : Node {

	#region Inspector
	// Global properites
	[Export] private float speed = 1;
	[Export] private float strength = 1;

	// Animation Settings
	[ExportGroup("Animations")]

	// Grow/Stretch
	[Export, ExportSubgroup("Grow")] protected bool growAnimation = false;
	[Export] private float growthSpeed = 1;
	[Export] private bool squashMode = false;
	[Export] private float squashOffset = 0.5f;
	[Export] private Curve growthCurve;

	// Rotation
	[Export, ExportSubgroup("Rotate")] protected bool rotateAnimation = false;
	[Export] private float rotateSpeed = 1;
	[Export] private Curve rotateCurve;
	#endregion

	public abstract void PlayEffect(T target, float animationTime);

	public abstract void ResetEffect(T target);

	protected Vector2 PlayGrowth(float animationTime) {
		if (growthCurve == null) return Vector2.Zero;

		Vector2 scale;

		if (squashMode) {
			scale = new Vector2(growthCurve.Sample((animationTime * speed * growthSpeed) % 1), growthCurve.Sample(((animationTime * speed * growthSpeed) + squashOffset) % 1));
		} else {
			scale = Vector2.One * growthCurve.Sample((animationTime * speed * growthSpeed) % 1);
		}

		return new Vector2((strength * scale.X) + (1 - strength), (strength * scale.Y) + (1 - strength));
	}

	protected float PlayRotate(float animationTime) {
		if (rotateCurve == null) return 0;

		float rotation;

		rotation = strength * rotateCurve.Sample((animationTime * speed * rotateSpeed) % 1);

		return rotation;
	}

}
