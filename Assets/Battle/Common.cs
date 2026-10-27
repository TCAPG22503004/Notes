public static class Common{ 

	static laneParameter lane;
	static float xMin, xMax, yMin, yMax;


	// init
	public static void Init(laneParameter l) {

		lane =  l;
		xMin = -l.length / 2;
		xMax =  l.length / 2;
		yMin =  l.y[2];
		yMax =  l.y[0];

		return;
	}


	// movement
	public static void SetPosAndLane(ref float x, ref float y, ref Parameter p, float dx, float dy, float delta) {

		// fitting lane
		if (dy == 0) {

			float distance = lane.y[p.lane] - y;
	
			if (System.Math.Abs(distance) < delta) {
				dy = distance;
			}
			else if (distance > 0) {
				dy = delta;
			}
			else {
				dy = -delta;
			}
		}


		// set pos
		x += dx;
		y += dy;

		if      (x < xMin) x = xMin;
		else if (x > xMax) x = xMax;
		if      (y < yMin) y = yMin;
		else if (y > yMax) y = yMax;


		// set lane
		if (dy != 0) {

			int nearest = 0;
			float distance = 999;

			for (int i = 0; i < 3; i++) {
				float d = System.Math.Abs(y - lane.y[i]);
				if (d < distance) {
					distance = d;
					nearest = i;
				}
			}

			if (p.lane != nearest) {
				p.lane = nearest;
			}

		}

		return;
	}
}
