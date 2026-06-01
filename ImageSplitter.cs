using Godot;
using System;

public partial class ImageSplitter : Node
{
	private Sprite2D sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Image image = Image.LoadFromFile("icon.svg");
		sprite = GetNode<Sprite2D>("DisplaySprite");
		SplitImage(image);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SplitImage(Image image)
	{
		sprite.Texture = ImageTexture.CreateFromImage(image);
	}
}
