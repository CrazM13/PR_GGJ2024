using Godot;
using System;
using System.Collections.Generic;

public partial class TextSplices : Resource {

	[Export] public string Key { get; set; }

	public List<string> Values { get; set; }
	[Export] private TextResource file;

	private RandomNumberGenerator rng = new();

	public void Initialize() {
		//FileAccess file = FileAccess.Open(pathToText, FileAccess.ModeFlags.Read);
		Values = new List<string>();
		//
		//// Discard header
		//file.GetLine();
		//while (!file.EofReached()) {
		//	string line = file.GetLine();
		//	if (line != string.Empty) {
		//		Values.Add(line);
		//	}
		//}
		//file.Close();

		for (int i = 1; i < file.Lines.Length; i++) {
			Values.Add(file.Lines[i]);
		}
	}

	public string GetRandomSplice() {
		return Values[rng.RandiRange(0, Values.Count - 1)];
	}
}
