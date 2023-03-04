namespace WS;


internal struct CROP
{
	public float LeftCrop = 0f;
	public float TopCrop = 0f;
	public float RightCrop = 0f;
	public float BottomCrop = 0f;

	public CROP() { }

	public CROP(float leftCrop, float topCrop, float rightCrop, float bottomCrop) : this()
	{
		LeftCrop = leftCrop;
		TopCrop = topCrop;
		RightCrop = rightCrop;
		BottomCrop = bottomCrop;
	}

	public RectangleF ToRect(RectangleF initialRect)
	{
		float x = initialRect.X + LeftCrop;
		float y = initialRect.Y + TopCrop;
		float w = initialRect.Width - (LeftCrop + RightCrop);
		float h = initialRect.Height - (TopCrop + BottomCrop);
		return new(x, y, w, h);
	}
}
