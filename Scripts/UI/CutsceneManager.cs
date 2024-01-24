using Godot;
using System;

public partial class CutsceneManager : AnimationPlayer {

	[Export] private string[] sceneList;

	private int currentScene = 0;

	public override void _Ready() {

		PlayScene(sceneList[currentScene]);

		base._Ready();
	}

	public void MoveToNextScene() {
		if (currentScene < sceneList.Length - 1) {
			currentScene++;
			PlayScene(sceneList[currentScene]);
		}
	}

	public void PlayScene(string scene) {
		this.Stop();
		this.Play(scene);
	}



}
