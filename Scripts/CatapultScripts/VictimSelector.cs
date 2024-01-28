using Godot;
using System;

public partial class VictimSelector : AnimatedSprite2D {
	
	private RandomNumberGenerator rng = new RandomNumberGenerator();

	public override void _Ready() {

		//byte targetNiceness = (byte)rng.RandiRange(0, 255);
		//byte targetCost = (byte)rng.RandiRange(0, 255);
		//byte targetRandomness = (byte)rng.RandiRange(0, 255);
		//
		//int targetDifference = 0;
		//int selected = 0;
		//
		//for (int i = 0; i < 3; i++) {
		//	IdeaManager ideas = IdeaManager.Instance;
		//
		//	Idea idea = ideas.GetIdea(ideas.GetIdeaIndex(i));
		//
		//	int dif = rng.RandiRange(0, 16);
		//
		//	dif += Mathf.Abs(idea.Niceness - targetNiceness);
		//	dif += Mathf.Abs(idea.ResourceCost - targetCost);
		//	dif += Mathf.Abs(idea.Randomness - targetRandomness);
		//
		//	if (targetDifference > dif) {
		//		selected = i;
		//		targetDifference = dif;
		//	}
		//	
		//}
		//
		//this.Animation = $"BP{selected + 1} Panic";
		this.Animation = $"BP{rng.RandiRange(0, 2)} Panic";
	}
}
