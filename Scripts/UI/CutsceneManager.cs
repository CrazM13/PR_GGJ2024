using Godot;
using System;

public partial class CutsceneManager : AnimationPlayer {

	public void PlayScene(string scene) {
		this.Stop();
		this.Play(scene);
	}

}
