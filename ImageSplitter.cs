using Godot;
using System;

public partial class ImageSplitter : Node
{
	private Sprite2D sprite;
	private Sprite2D[] slices = new Sprite2D[6];

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Image image = Image.LoadFromFile("icon.svg");
		sprite = GetNode<Sprite2D>("DisplaySprite");
		SplitImage(image);
	}
	
	public void SplitImage(Image image)
	{
		sprite.Texture = ImageTexture.CreateFromImage(image);
		int originalWidth = image.GetUsedRect().Size.X;
		int originalHeight = image.GetUsedRect().Size.Y;
		int sliceWidth = originalWidth/3;
		int sliceHeight = originalHeight/2;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				int curSliceNo = (i*3) + j;
				int positionX = sliceWidth * j;
				int positionY = sliceHeight * i;
				Rect2I rect = new Rect2I(positionX, positionY, sliceWidth, sliceHeight);
				Image slice = image.GetRegion(rect);
				slices[curSliceNo] = GetNode<Sprite2D>("Slice"+(curSliceNo + 1));
				slices[curSliceNo].Texture = ImageTexture.CreateFromImage(slice);
			}
		}
	}
}
