using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZoneGenerator : MonoBehaviour 
{
	private const float ROOT3DIV2 = 0.866f; 

	private class Zone
	{
		//terrain generation/appearance.
		public int mapSize;
		public int smoothings = 2;
		[Range(0,100)]
		public int randomFillPercent = 50;
		public string seed;
		public int[,] map;

		//terrain contents
		public List<GameObject> terrainContents;
		
		public Zone(int _mapSize) 
		{
			mapSize = _mapSize;
			seed = Random.seed.ToString();
			GenerateMap();

			terrainContents = new List<GameObject>();
		}
		
		void GenerateMap()
		{
			map = new int[mapSize, mapSize];

			RandomFillMap();
			
			for (int i = 0; i < smoothings; i ++) 
			{
				SmoothMap();
			}
			
			ProcessMap ();
			
			int borderSize = 1;
			int[,] borderedMap = new int[mapSize + borderSize * 2, mapSize + borderSize * 2];
			
			for (int x = 0; x < borderedMap.GetLength(0); x ++) 
			{
				for (int y = 0; y < borderedMap.GetLength(1); y ++) 
				{
					if (x >= borderSize && x < mapSize + borderSize && y >= borderSize && y < mapSize + borderSize) 
					{
						borderedMap[x,y] = map[x-borderSize,y-borderSize];
					}
					else 
					{
						borderedMap[x,y] =1;
					}
				}
			}
		}
		
		void ProcessMap() {
			List<List<Coord>> wallRegions = GetRegions (1);
			int wallThresholdSize = 5;
			
			foreach (List<Coord> wallRegion in wallRegions) {
				if (wallRegion.Count < wallThresholdSize) {
					foreach (Coord tile in wallRegion) {
						map[tile.tileX,tile.tileY] = 0;
					}
				}
			}
			
			List<List<Coord>> roomRegions = GetRegions (0);
			int roomThresholdSize = 10;
			List<Room> survivingRooms = new List<Room> ();
			
			foreach (List<Coord> roomRegion in roomRegions) {
				if (roomRegion.Count < roomThresholdSize) {
					foreach (Coord tile in roomRegion) {
						map[tile.tileX,tile.tileY] = 1;
					}
				}
				else {
					survivingRooms.Add(new Room(roomRegion, map));
				}
			}
			survivingRooms.Sort ();
			survivingRooms [0].isMainRoom = true;
			survivingRooms [0].isAccessibleFromMainRoom = true;
			
			ConnectClosestRooms (survivingRooms);
		}
		
		void ConnectClosestRooms(List<Room> allRooms, bool forceAccessibilityFromMainRoom = false) {
			
			List<Room> roomListA = new List<Room> ();
			List<Room> roomListB = new List<Room> ();
			
			if (forceAccessibilityFromMainRoom) {
				foreach (Room room in allRooms) {
					if (room.isAccessibleFromMainRoom) {
						roomListB.Add (room);
					} else {
						roomListA.Add (room);
					}
				}
			} else {
				roomListA = allRooms;
				roomListB = allRooms;
			}
			
			int bestDistance = 0;
			Coord bestTileA = new Coord ();
			Coord bestTileB = new Coord ();
			Room bestRoomA = new Room ();
			Room bestRoomB = new Room ();
			bool possibleConnectionFound = false;
			
			foreach (Room roomA in roomListA) {
				if (!forceAccessibilityFromMainRoom) {
					possibleConnectionFound = false;
					if (roomA.connectedRooms.Count > 0) {
						continue;
					}
				}
				
				foreach (Room roomB in roomListB) {
					if (roomA == roomB || roomA.IsConnected(roomB)) {
						continue;
					}
					
					for (int tileIndexA = 0; tileIndexA < roomA.edgeTiles.Count; tileIndexA ++) {
						for (int tileIndexB = 0; tileIndexB < roomB.edgeTiles.Count; tileIndexB ++) {
							Coord tileA = roomA.edgeTiles[tileIndexA];
							Coord tileB = roomB.edgeTiles[tileIndexB];
							int distanceBetweenRooms = (int)(Mathf.Pow (tileA.tileX-tileB.tileX,2) + Mathf.Pow (tileA.tileY-tileB.tileY,2));
							
							if (distanceBetweenRooms < bestDistance || !possibleConnectionFound) {
								bestDistance = distanceBetweenRooms;
								possibleConnectionFound = true;
								bestTileA = tileA;
								bestTileB = tileB;
								bestRoomA = roomA;
								bestRoomB = roomB;
							}
						}
					}
				}
				if (possibleConnectionFound && !forceAccessibilityFromMainRoom) {
					CreatePassage(bestRoomA, bestRoomB, bestTileA, bestTileB);
				}
			}
			
			if (possibleConnectionFound && forceAccessibilityFromMainRoom) {
				CreatePassage(bestRoomA, bestRoomB, bestTileA, bestTileB);
				ConnectClosestRooms(allRooms, true);
			}
			
			if (!forceAccessibilityFromMainRoom) {
				ConnectClosestRooms(allRooms, true);
			}
		}
		
		void CreatePassage(Room roomA, Room roomB, Coord tileA, Coord tileB) 
		{
			Room.ConnectRooms (roomA, roomB);

			List<Coord> line = GetLine(tileA, tileB);
			foreach(Coord c in line)
			{
				DrawCircle(c, 2);
			}
		}

		void DrawCircle(Coord _c, int _r)
		{
			for(int x = -_r; x <= _r; x++)
			{
				for(int y = -_r; y <= _r; y++)
				{
					if(x * x + y * y <= _r * _r)
					{
						int realX = _c.tileX + x; 
						int realY = _c.tileY + y; 

						if(IsInMapRange(realX, realY))
						  {
							map[realX, realY] = 0;
						}
					}
				}
			}
		}

		List<Coord> GetLine(Coord from, Coord to) {
			List<Coord> line = new List<Coord> ();
			
			int x = from.tileX;
			int y = from.tileY;
			
			int dx = to.tileX - from.tileX;
			int dy = to.tileY - from.tileY;
			
			bool inverted = false;
			int step = System.Math.Sign (dx);
			int gradientStep = System.Math.Sign (dy);
			
			int longest = Mathf.Abs (dx);
			int shortest = Mathf.Abs (dy);
			
			if (longest < shortest) {
				inverted = true;
				longest = Mathf.Abs(dy);
				shortest = Mathf.Abs(dx);
				
				step = System.Math.Sign (dy);
				gradientStep = System.Math.Sign (dx);
			}
			
			int gradientAccumulation = longest / 2;
			for (int i =0; i < longest; i ++) {
				line.Add(new Coord(x,y));
				
				if (inverted) {
					y += step;
				}
				else {
					x += step;
				}
				
				gradientAccumulation += shortest;
				if (gradientAccumulation >= longest) {
					if (inverted) {
						x += gradientStep;
					}
					else {
						y += gradientStep;
					}
					gradientAccumulation -= longest;
				}
			}
			
			return line;
		}

		List<List<Coord>> GetRegions(int tileType) 
		{
			List<List<Coord>> regions = new List<List<Coord>>();
			int[,] mapFlags = new int[mapSize, mapSize];
			
			for (int x = 0; x < mapSize; x ++) {
				for (int y = 0; y < mapSize; y ++) {
					if (mapFlags[x,y] == 0 && map[x,y] == tileType) {
						List<Coord> newRegion = GetRegionTiles(x,y);
						regions.Add(newRegion);
						
						foreach (Coord tile in newRegion) {
							mapFlags[tile.tileX, tile.tileY] = 1;
						}
					}
				}
			}
			
			return regions;
		}
		
		List<Coord> GetRegionTiles(int startX, int startY) 
		{
			List<Coord> tiles = new List<Coord> ();
			int[,] mapFlags = new int[mapSize, mapSize];
			int tileType = map [startX, startY];
			
			Queue<Coord> queue = new Queue<Coord> ();
			queue.Enqueue (new Coord (startX, startY));
			mapFlags [startX, startY] = 1;
			
			while (queue.Count > 0) {
				Coord tile = queue.Dequeue();
				tiles.Add(tile);
				
				for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++) 
				{
					for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++) 
					{
						if (IsInMapRange(x,y) && (y == tile.tileY || x == tile.tileX)) 
						{
							if (mapFlags[x,y] == 0 && map[x,y] == tileType) 
							{
								mapFlags[x,y] = 1;
								queue.Enqueue(new Coord(x,y));
							}
						}
					}
				}
			}
			
			return tiles;
		}
		
		bool IsInMapRange(int x, int y) 
		{
			return x >= 0 && x < mapSize && y >= 0 && y < mapSize;
		}
		
		
		void RandomFillMap() 
		{
			
			System.Random pseudoRandom = new System.Random(seed.GetHashCode());
			
			for (int x = 0; x < mapSize; x ++) {
				for (int y = 0; y < mapSize; y ++) {
					if (x == 0 || x == mapSize - 1 || y == 0 || y == mapSize -1) 
					{
						map[x,y] = 1;
					}
					else {
						map[x,y] = (pseudoRandom.Next(0,100) < randomFillPercent)? 1: 0;
					
					}
				}
			}
		}
		
		void SmoothMap() 
		{
			for (int x = 0; x < mapSize; x ++) {
				for (int y = 0; y < mapSize; y ++) {
					int neighbourWallTiles = GetSurroundingWallCount(x,y);
					
					if (neighbourWallTiles > 4)
						map[x,y] = 1;
					else if (neighbourWallTiles < 4)
						map[x,y] = 0;
					
				}
			}
		}
		
		int GetSurroundingWallCount(int gridX, int gridY) {
			int wallCount = 0;
			for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX ++) {
				for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY ++) {
					if (IsInMapRange(neighbourX,neighbourY)) {
						if (neighbourX != gridX || neighbourY != gridY) {
							wallCount += map[neighbourX,neighbourY];
						}
					}
					else {
						wallCount ++;
					}
				}
			}
			
			return wallCount;
		}
		
		struct Coord {
			public int tileX;
			public int tileY;
			
			public Coord(int x, int y) {
				tileX = x;
				tileY = y;
			}
		}
		
		
		class Room : System.IComparable<Room>
		{
			public List<Coord> tiles;
			public List<Coord> edgeTiles;
			public List<Room> connectedRooms;
			public int roomSize;
			public bool isAccessibleFromMainRoom;
			public bool isMainRoom;
			
			public Room() {
			}
			
			public Room(List<Coord> roomTiles, int[,] map) {
				tiles = roomTiles;
				roomSize = tiles.Count;
				connectedRooms = new List<Room>();
				
				edgeTiles = new List<Coord>();
				foreach (Coord tile in tiles) {
					for (int x = tile.tileX-1; x <= tile.tileX+1; x++) {
						for (int y = tile.tileY-1; y <= tile.tileY+1; y++) {
							if (x == tile.tileX || y == tile.tileY) {
								if (map[x,y] == 1) {
									edgeTiles.Add(tile);
								}
							}
						}
					}
				}
			}
			
			public void SetAccessibleFromMainRoom() {
				if (!isAccessibleFromMainRoom) {
					isAccessibleFromMainRoom = true;
					foreach (Room connectedRoom in connectedRooms) {
						connectedRoom.SetAccessibleFromMainRoom();
					}
				}
			}
			
			public static void ConnectRooms(Room roomA, Room roomB) {
				if (roomA.isAccessibleFromMainRoom) {
					roomB.SetAccessibleFromMainRoom ();
				} else if (roomB.isAccessibleFromMainRoom) {
					roomA.SetAccessibleFromMainRoom();
				}
				roomA.connectedRooms.Add (roomB);
				roomB.connectedRooms.Add (roomA);
			}
			
			public bool IsConnected(Room otherRoom) {
				return connectedRooms.Contains(otherRoom);
			}
			
			public int CompareTo(Room otherRoom) {
				return otherRoom.roomSize.CompareTo (roomSize);
			}
		}
	}
	
	
	/* MAP FILLER */
	public GameObject[] gameTiles; 
	public GameObject[] wallTiles;
	public float[] tileProbabilities;
	
	private List<Zone> zones;
	
	public int numberOfTiles = 100;

	private float hexRadius;
	private float xOffset = 0.0f;
	private float yOffset = 0.0f;

	public float heightVariance = 2.0f;

	public float sparseness = 0.2f;
	public float landHoles = 10.0f;
	public float lowScatter = -0.25f;
	public float highScatter = 1.5f;

	void Awake () 
	{
		hexRadius = gameTiles[0].GetComponent<MeshRenderer>().bounds.size.x;
		xOffset = hexRadius * ROOT3DIV2;
		yOffset = hexRadius * 0.75f;

		zones = new List<Zone>();
		zones.Add(GenerateRectZone());

	}

	#region generatingzones
	private Zone GenerateRectZone()
	{
		Vector2 currPos = Vector2.zero;
		Zone zone = new Zone((int)Mathf.Sqrt(numberOfTiles));

		int half = (int)Mathf.Sqrt(numberOfTiles) / 2;

		//filling zone map according to generated hexes
		for(int i = -half ; i < half; i++)
		{
			for(int j = -half; j < half; j++)
			{
				int tileNum = DetermineRandomTile();
				
				currPos = HexOffset(i, j);
				
				if(zone.map[i + half, j + half] == 0)
				{
					Vector3 worldPos = new Vector3(currPos.x, Random.Range(-heightVariance, heightVariance), currPos.y);
					
					GameObject currHex = Instantiate(gameTiles[tileNum], worldPos, Quaternion.identity) as GameObject;
					currHex.transform.Rotate(new Vector3(-90.0f, 90.0f, 0.0f));
					currHex.transform.parent = this.transform;
					
					zone.terrainContents.Add(currHex);

				}
				else if(zone.map[i + half, j + half] == 1)
				{
					Vector3 worldPos = new Vector3(currPos.x, 100, currPos.y);

					GameObject currHex = Instantiate(wallTiles[0], worldPos, Quaternion.identity) as GameObject;
					currHex.transform.Rotate(new Vector3(-90.0f, 90.0f, 0.0f));
					currHex.transform.parent = this.transform;
					
					zone.terrainContents.Add(currHex);
				}

			}
		}

		return zone;
	}

	private Zone GenerateHexZone()
	{
		Zone zone = new Zone(numberOfTiles);

		int i = 0;
		int r1 = 0;
		int r2 = 0;

		for (int q = -numberOfTiles / 2; q < numberOfTiles / 2 ; q++) 
		{
			r1 = System.Math.Max(-numberOfTiles / 2, - q - numberOfTiles / 2);
			r2 = System.Math.Min(numberOfTiles / 2, -q + numberOfTiles / 2);

			for(int r = r1; r <= r2; r++)
			{
				int tileNum = DetermineRandomTile();
				Vector3 position = CalculateWorldPosition(new Vector3(q, r, -q-r));

				GameObject currHex = Instantiate(gameTiles[tileNum], position, Quaternion.identity) as GameObject;
				currHex.transform.Rotate(new Vector3(-90.0f, 90.0f, 0.0f));
				currHex.transform.parent = this.transform;

				zone.terrainContents.Add (currHex);
	
				i++;
			}
		}

		return zone; 
	}
	#endregion generatingzones

	#region zoning 
	private Vector3 CalculateWorldPosition(Vector3 _cubeCoords)
	{
		//        return new ScreenCoordinate(scale * (r-q) * SQRT_3_2, scale * (0.5*(r+q) - s));
		Vector3 coords = Vector3.zero;
		coords.x = yOffset / 1.70f * (_cubeCoords.y - _cubeCoords.x);
		coords.y = Random.Range(-heightVariance, heightVariance);
		coords.z = xOffset / 1.70f * (0.5f * (_cubeCoords.y + _cubeCoords.x) - _cubeCoords.z);

		return coords;
	}


	private Vector2 HexOffset(int _x, int _y)
	{
		Vector2 position = Vector2.zero;
		
		if( _y % 2 == 0 ) 
		{
			position.x = _x * xOffset;
			position.y = _y * yOffset;
		}
		else 
		{
			position.x = ( _x + 0.5f ) * xOffset;
			position.y = _y * yOffset;
		}
		
		return position;
	}

	private int DetermineRandomTile()
	{
		int percent = Random.Range(0, 100);

		int rangeStart = 0;

		for(int n = 0; n < gameTiles.Length; n++)
		{
			int endRange = rangeStart + (int)(tileProbabilities[n] * 100);

			if(percent >= rangeStart && percent < endRange)
			{
				return n;
			}

			rangeStart = endRange;
		}

		return Random.Range (0, gameTiles.Length);
	}

	private bool isOnMap(Vector2 _location)
	{
		float xVal = (_location.x / numberOfTiles) * landHoles ;
		float yVal = (_location.y / numberOfTiles) * landHoles ;
		float value = Mathf.PerlinNoise(xVal, yVal);

		return value > (sparseness + sparseness * Random.Range(lowScatter, highScatter)); 
	}

	#endregion zoning

}
