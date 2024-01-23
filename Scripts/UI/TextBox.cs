using Godot;
using System;
using System.Collections.Generic;

public partial class TextBox : Label {

	[Export] private CutsceneManager cutscene;
	[Export] private float speed = 1;
	[Export] private TextSplices[] spliceData;

	private string targetText = string.Empty;
	private float progress = 0;

	private Queue<string> textQueue = new Queue<string>();

	private bool wasInputDown = false;
	private bool allowInput = false;

	private float currentSpeedModifier = 1;

	public void AllowInput(bool allowInput) {
		this.allowInput = allowInput;
	}

	public void SetText(string text) {
		if (text != string.Empty) {
			if (spliceData != null && spliceData.Length > 0) text = SpliceText(text);

			targetText = text;
			progress = 0;
		} else {
			this.Text = targetText = text;
			progress = 0;
		}

		currentSpeedModifier = 1;
	}

	public void QueueText(string text) {
		textQueue.Enqueue(text);

		if (targetText == string.Empty) {
			SetText(textQueue.Dequeue());
		}
	}

	public void QueueTexts(params string[] texts) {
		foreach (string text in texts) textQueue.Enqueue(text);

		if (targetText == string.Empty) {
			SetText(textQueue.Dequeue());
		}
	}

	public void DisplayIdea(int ideaIndex) {
		IdeaManager ideas = IdeaManager.Instance;
		SetText(ideas.GetIdea(ideaIndex).Text);
	}

	public void DisplayChoice(int choice) {
		IdeaManager ideas = IdeaManager.Instance;
		SetText(ideas.GetIdea(ideas.GetIdeaIndex(choice)).Text);
	}

	public override void _Process(double delta) {
		base._Process(delta);

		if (progress < targetText.Length) {
			progress += (float) delta * speed * currentSpeedModifier;
			int index = Mathf.FloorToInt(progress);

			this.Text = targetText[..index];
		}

		if (allowInput) {
			bool isInputDown = Input.IsMouseButtonPressed(MouseButton.Left);

			if (isInputDown && !wasInputDown) {
				if (progress < targetText.Length) {
					currentSpeedModifier = 2f;
				} else {

					if (textQueue.Count > 0) {
						SetText(textQueue.Dequeue());
					} else {
						SetText(string.Empty);
						cutscene?.MoveToNextScene();
					}
				}
			}

			wasInputDown = isInputDown;
		}
	}

	private string SpliceText(string text) {
		foreach (TextSplices splice in spliceData) {
			text = text.Replace($"[{splice.Key}]", splice.GetRandomSplice());
		}

		return text;
	}

}
