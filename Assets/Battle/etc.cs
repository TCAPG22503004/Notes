public static class etc {

	public static int SetLane(float oy) {

		int nearest = 0;
		float minY = 999;

		for (int i = 0; i < 3; i++) {

			float y = System.Math.Abs(oy - laneParameter.Instance.LaneY[i]);

			if (y < minY) {
				nearest = i;
				minY = y;
			}
		}

		return nearest;

	}


	public static void ToTrapezoid(float ox, float oy, ref float x, ref float y) {

		float yMax = laneParameter.Instance.LaneY[0];
		float yMin = laneParameter.Instance.LaneY[2];

		// correct velocity x
		float dy = yMin - yMax;
		float normalizedY = (1 / dy * oy) - (yMax / dy);
		float ratio = (1 + ((laneParameter.Instance.LenRatio-1) * normalizedY));
		x *= ratio;

		// add x when |y| > 0 and correct direction
		float maxLength = laneParameter.Instance.TopLength / 2 * ratio;
		float normalizedX = ox / maxLength;
		UnityEngine.Debug.Log(ratio);
		bool b1 = (yMax - oy < 0.0001) && (y > 0);
		bool b2 = (oy - yMin < 0.0001) && (y < 0);
		if (!b1 && !b2 && x == 0) x += ratio * -normalizedX * y;

		// into stage
		x += ox;
		y += oy;
		normalizedY = (1 / dy * y) - (yMax / dy);
		ratio = (1 + ((laneParameter.Instance.LenRatio-1) * normalizedY));

		float xMax = laneParameter.Instance.TopLength / 2 * ratio;
		float xMin = -xMax;
		// already defined in first
//		float yMax = laneParameter.Instance.LaneY[0];
//		float yMin = laneParameter.Instance.LaneY[2];

		if (x > xMax) x = xMax;
		if (x < xMin) x = xMin;
		if (y > yMax) y = yMax;
		if (y < yMin) y = yMin;
		
		return;
	}

}
