using Godot;
using System;

public partial class TextSplices : Resource {

	[Export] public string Key { get; set; }

	[Export] public string[] Values { get; set; }

	private RandomNumberGenerator rng = new();

	public string GetRandomSplice() {
		return Values[rng.RandiRange(0, Values.Length - 1)];
	}
}
