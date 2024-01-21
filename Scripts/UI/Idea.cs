using Godot;
using System;

public struct Idea {

	public string Text;
	public int Niceness;
	public int ResourceCost;
	public int Funnyness;

	public Idea(string text, int niceness = 0, int cost = 0, int funnyness = 0) {
		Text = text;
		Niceness = niceness;
		ResourceCost = cost;
		Funnyness = funnyness;
	}

}
