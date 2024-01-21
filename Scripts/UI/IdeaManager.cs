using Godot;
using System;
using System.Collections.Generic;

public class IdeaManager {

	private static IdeaManager instance;
	public static IdeaManager Instance {
		get {
			instance ??= new IdeaManager();

			return instance;
		}
	}

	private List<Idea> ideas;

	private int choice;

	private IdeaManager() {
		ideas = new List<Idea>() {
			new Idea("Test1"),
			new Idea("Test2"),
			new Idea("Test3"),
			new Idea("Test4"),
			new Idea("Test5"),
			new Idea("Test6"),
		};

		choice = 0;
	}

	public void ChooseIdeas() {
		choice = Random.Shared.Next(0, ideas.Count);
	}

	public int GetIdeaIndex() {
		return choice % ideas.Count;
	}

	public Idea GetIdea(int index) {
		return ideas[index];
	}

}
