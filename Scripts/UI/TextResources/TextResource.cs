using Godot;
using System;

public partial class TextResource : Resource {

	[Export] public string[] Lines { get; private set; }

	public void Write(string[] lines) {
		this.Lines = lines;
	}

	public string Read(int line) {
		return Lines[line];
	}

}
