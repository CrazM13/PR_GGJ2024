using Godot;
using System;

public partial class TextBox : Label {

	[Export] private float speed = 1;
	[Export] private TextSplices[] spliceData;

	private string targetText = string.Empty;
	private float progress = 0;

	public void SetText(string text, bool animate = false) {
		if (spliceData != null && spliceData.Length > 0) text = SpliceText(text);

		if (animate) {
			targetText = text;
			progress = 0;
		} else {
			this.Text = targetText = text;
			progress = text.Length + 1;
		}
	}

	public void DisplayIdea(int ideaIndex, bool animate = false) {
		IdeaManager ideas = IdeaManager.Instance;
		SetText(ideas.GetIdea(ideaIndex).Text, animate);
	}

	public void DisplayChoice(int choice, bool animate = false) {
		IdeaManager ideas = IdeaManager.Instance;
		SetText(ideas.GetIdea(ideas.GetIdeaIndex(choice)).Text, animate);
	}

	public override void _Process(double delta) {
		base._Process(delta);

		if (progress < targetText.Length) {
			progress += (float) delta * speed;
			int index = Mathf.FloorToInt(progress);

			this.Text = targetText[..index];
		}

		if (Input.IsMouseButtonPressed(MouseButton.Left)) {

		}

	}

	private string SpliceText(string text) {
		foreach (TextSplices splice in spliceData) {
			text = text.Replace($"[{splice.Key}]", splice.GetRandomSplice());
		}

		return text;
	}

}
