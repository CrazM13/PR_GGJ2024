using Godot;
using System;

public struct Idea {

	public string Text;
	public byte Niceness;
	public byte ResourceCost;
	public byte Randomness;

	public Idea(string text, byte niceness = 0, byte cost = 0, byte randomness = 0) {
		Text = text;
		Niceness = niceness;
		ResourceCost = cost;
		Randomness = randomness;
	}

}
