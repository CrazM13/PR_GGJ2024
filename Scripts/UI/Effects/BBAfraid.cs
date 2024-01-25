using Godot;
using System;

public partial class BBAfraid : RichTextEffect {

	private string bbcode = "Afraid";

	// Global properites
	[Export] private float fear = 1;

	private RandomNumberGenerator rng = new RandomNumberGenerator();

	public override bool _ProcessCustomFX(CharFXTransform charFX) {

		float currentFear = fear;
		if (charFX.Env.ContainsKey("fear")) {
			currentFear = charFX.Env["fear"].As<float>();
		}

		(float xOff, float yOff) = Mathf.SinCos(rng.RandfRange(0, Mathf.DegToRad(360)));

		charFX.Offset = new Vector2(xOff * currentFear, yOff * currentFear);

		return true;
	}

}
