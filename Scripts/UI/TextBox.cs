using Godot;
using System;

public partial class TextBox : Label {

	[Export] private float speed = 1;

	private string targetText = string.Empty;
	private float progress = 0;

	public void SetText(string text, bool animate = false) {

		if (animate) {
			targetText = text;
			progress = 0;
		} else {
			this.Text = targetText = text;
			progress = text.Length + 1;
		}
		
	}

	public override void _Process(double delta) {
		base._Process(delta);

		if (progress < targetText.Length) {
			progress += (float) delta * speed;
			int index = Mathf.FloorToInt(progress);

			this.Text = targetText[..index];
		}

	}

}
