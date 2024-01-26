using Godot;
using System;

public partial class BBType : RichTextEffect {

	private string bbcode = "Type";

	[Export] private float strength = 0.1f;

	public override bool _ProcessCustomFX(CharFXTransform charFX) {

		charFX.Offset = new Vector2(0, -strength);

		return true;
	}
}