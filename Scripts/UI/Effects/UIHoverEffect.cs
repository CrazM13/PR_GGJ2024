using Godot;
using System;

public partial class UIHoverEffect : Control {

	[Export] private UIEffect effect;
	[Export] private bool resetOnMouseExit = false;
	[Export] private bool manualConnect = false;

	public bool IsHovered { get; set; } = false;
	private bool wasHovered = false;

	private float animationTime;

	public override void _Ready() {
		base._Ready();

		if (!manualConnect) {
			this.MouseEntered += OnMouseEnter;
			this.MouseExited += OnMouseExit;
		}
	}
	
	public override void _Process(double delta) {

		if (IsHovered) {

			animationTime += (float) delta;
			effect?.PlayEffect(this, animationTime);

		} else if (wasHovered && !IsHovered) {

			if (resetOnMouseExit) animationTime = 0;
			effect?.ResetEffect(this);

		}
	
		wasHovered = IsHovered;
	}

	public void OnMouseEnter() {
		IsHovered = true;
	}

	public void OnMouseExit() {
		IsHovered = false;
	}
}
