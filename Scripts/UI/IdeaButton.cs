using Godot;
using System;

public partial class IdeaButton : Button {

	[Export] private CutsceneManager cutscene;
	private int ideaIndex = 0;

	public override void _Ready() {
		base._Ready();
	}

	public void GetNewIdea() {
		IdeaManager ideas = IdeaManager.Instance;

		ideas.ChooseIdea(0);
		ideas.ChooseIdea(1);

		ideas.ChooseIdea(2);
		ideaIndex = ideas.GetIdeaIndex(2);

		this.Text = ideas.GetIdea(ideaIndex).Text;
	}

	public void OnPress() {
		IdeaManager ideas = IdeaManager.Instance;

		ideas.SetChoice(2, ideaIndex);

		cutscene.PlayScene("Judging");
	}

}
