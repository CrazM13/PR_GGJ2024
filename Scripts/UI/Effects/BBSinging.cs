using Godot;
using System;

public partial class BBSinging : RichTextEffect {

	private string bbcode = "Singing";

	[Export] float volume = 1;

	public override bool _ProcessCustomFX(CharFXTransform charFX) {

		float currentVolume = volume;
		if (charFX.Env.ContainsKey("vol")) {
			currentVolume = charFX.Env["vol"].As<float>();
		}

		float time = (float) charFX.ElapsedTime * currentVolume;
		int index = charFX.RelativeIndex;

		float yOff = Mathf.Cos(time + (index * 0.1f));

		charFX.Offset = new Vector2(0, yOff * currentVolume);

		return true;
	}

}
