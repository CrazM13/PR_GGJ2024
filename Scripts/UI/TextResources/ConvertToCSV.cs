using Godot;
using System;
using System.Collections.Generic;

public partial class ConvertToCSV : Node {

	[Export] private string path;
	[Export] private string newName;

	public override void _Ready() {

		FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
		List<string> lines = new List<string>();

		while (!file.EofReached()) {
			string line = file.GetLine();
			if (line != string.Empty) {
				lines.Add(line);
			}
		}
		file.Close();

		TextResource newResource = new TextResource();
		newResource.Write(lines.ToArray());

		Error e = ResourceSaver.Singleton.Save(newResource, $"res://Assets/TextData/{newName}");
		GD.Print(e);


	}

}
