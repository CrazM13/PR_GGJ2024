using Godot;
using System;
using System.Collections.Generic;

public class IdeaManager {

	private const string PATH_TO_FILE = "res://Assets/TextData/IdeaCSV.tres";//"res://Assets/TextData/IdeaCSV.txt";

	private static IdeaManager instance;
	public static IdeaManager Instance {
		get {
			instance ??= new IdeaManager();

			return instance;
		}
	}

	private List<Idea> ideas;

	private int[] choices;

	private RandomNumberGenerator rng;

	private IdeaManager() {
		ideas = new List<Idea>();
		LoadIdeas();

		choices = new int[3];

		rng = new RandomNumberGenerator();
	}

	public void ChooseIdea(int choice) {
		choices[choice] = rng.RandiRange(0, ideas.Count - 1);
	}

	public int GetIdeaIndex(int choice) {
		return choices[choice];
	}

	public Idea GetIdea(int index) {
		return ideas[index];
	}

	public void SetChoice(int index, int idea) {
		choices[index] = idea;
	}

	private void LoadIdeas() {
		//FileAccess file = FileAccess.Open(PATH_TO_FILE, FileAccess.ModeFlags.Read);
		//
		//// Discard header
		//file.GetLine();
		//while (!file.EofReached()) {
		//	string line = file.GetLine();
		//	if (line != string.Empty) {
		//		string[] values = line.Split(',');
		//		ideas.Add(new Idea(values[0], (byte) (float.Parse(values[1]) * 255), (byte) (float.Parse(values[2]) * 255), (byte) (float.Parse(values[3]) * 255)));
		//	}
		//}
		//file.Close();

		TextResource resource = GD.Load<TextResource>(PATH_TO_FILE);

		for (int i = 1; i < resource.Lines.Length; i++) {
			string[] values = resource.Lines[i].Split(',');

			ideas.Add(new Idea(values[0], (byte) (float.Parse(values[1]) * 255), (byte) (float.Parse(values[2]) * 255), (byte) (float.Parse(values[3]) * 255)));
		}

	}

}
