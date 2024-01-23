using Godot;
using System;

public partial class SceneManager : Node {

	public void ChangeScene(string path) {
		GetTree().ChangeSceneToFile(path);
	}

	public void Quit() {
		GetTree().Quit();
	}

}

