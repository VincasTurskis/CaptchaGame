using Godot;
using System;

public partial class ImageSplitter : Node
{
	private Sprite2D sprite;
	private Sprite2D[] slices = new Sprite2D[6];

	[Export]
	private int sliceCountX;
	[Export]
	private int sliceCountY;
	

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

		int globalOffsetX = 0;
		int globalOffsetY = 200;

		int sliceWidth = originalWidth/sliceCountX;
		int sliceHeight = originalHeight/sliceCountY;
		for (int i = 0; i < sliceCountY; i++)
		{
			for (int j = 0; j < sliceCountX; j++)
			{
				int newSliceWidth = sliceWidth;
				int curSliceNo = (i*sliceCountX) + j;
				int positionX = sliceWidth * j;
				int positionY = sliceHeight * i;
				int posXOffset = 0;
				if(j == (sliceCountX - 1))
				{
					newSliceWidth = sliceWidth + originalWidth % sliceCountX;
					posXOffset = originalWidth % sliceCountX / 2;
				}
				Rect2I rect = new Rect2I(positionX, positionY, newSliceWidth, sliceHeight);
				Image slice = image.GetRegion(rect);
				slices[curSliceNo] = GetNode<Sprite2D>("Slice"+(curSliceNo + 1));
				slices[curSliceNo].Texture = ImageTexture.CreateFromImage(slice);
				slices[curSliceNo].Position = new Vector2(positionX + posXOffset + globalOffsetX, positionY + globalOffsetY);
			}
		}
	}
}
