using Godot;
using System;

public partial class PlayRandom : AudioStreamPlayer {

	[Export] private AudioStream[] audioOptions;

	private RandomNumberGenerator rng = new RandomNumberGenerator();

	
	public void PlayRandomAudio() {
		if (audioOptions != null && audioOptions.Length > 0) {
			this.Stream = audioOptions[rng.RandiRange(0, audioOptions.Length - 1)];
			this.Play(0);
		}
	}

}
