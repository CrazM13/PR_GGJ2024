using Godot;
using System;

public partial class IdeaButton : Button {

	[Export] private CutsceneManager cutscene;

	public override void _Ready() {
		base._Ready();

		
	}

	public void GetNewIdea() {
		IdeaManager ideas = IdeaManager.Instance;
		ideas.ChooseIdeas();
		int index = ideas.GetIdeaIndex();

		this.Text = ideas.GetIdea(index).Text;
	}

	public void OnPress() {



		cutscene.PlayScene("Prompt");
	}

}
