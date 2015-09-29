using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZoneGenerator : MonoBehaviour 
{
	private class ZoneObject
	{
		public ZoneObject(GameObject _obj, Vector2 _pos)
		{
			this.zoneObject = _obj;
			this.cubeLocation = new Vector3(_pos.x, _pos.y, -_pos.x - _pos.y);
		}

		public GameObject zoneObject;
		public Vector3 cubeLocation;
	}

	public GameObject[] gameTiles; 
	public float[] tileProbabilities;

	private List<List<ZoneObject>> zones;

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
		xOffset = hexRadius * Mathf.Sqrt(3)/2;
		yOffset = hexRadius * 0.75f;

		zones = new List<List<ZoneObject>>();
		zones.Add(GenerateHexZone());

	}

	private List<ZoneObject> GenerateRectZone()
	{
		List<ZoneObject> zone = new List<ZoneObject>();
		Vector2 currPos = Vector2.zero;

		for(int i = 0; i < Mathf.Sqrt(numberOfTiles); i++)
		{
			for(int j = 0; j < Mathf.Sqrt(numberOfTiles); j++)
			{
				int tileNum = DetermineRandomTile();
				
				currPos = HexOffset(i, j);
				
				if(isOnMap(currPos))
				{
					Vector3 worldPos = new Vector3(currPos.x, Random.Range(-heightVariance, heightVariance), currPos.y);
					
					GameObject currHex = Instantiate(gameTiles[tileNum], worldPos, Quaternion.identity) as GameObject;
					currHex.transform.Rotate(new Vector3(-90.0f, 90.0f, 0.0f));
					currHex.transform.parent = this.transform;

					zone.Add (new ZoneObject(currHex, new Vector2 (i, j)));
				}

			}
		}

		return zone;
	}

	private List<ZoneObject> GenerateHexZone()
	{
		List<ZoneObject> zone = new List<ZoneObject>();

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

				zone.Add (new ZoneObject(currHex, new Vector2 (q, r)));
	
				i++;
			}
		}

		return zone; 
	}

	private Vector3 CalculateWorldPosition(Vector3 _cubeCoords)
	{
		//        return new ScreenCoordinate(scale * (r-q) * SQRT_3_2, scale * (0.5*(r+q) - s));
		Vector3 coords = Vector3.zero;
		coords.x = yOffset / 1.70f * (_cubeCoords.y - _cubeCoords.x);
		coords.y = 0.0f; //Random.Range(-heightVariance, heightVariance);
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

	private List<ZoneObject> GetNeighbors(ZoneObject _obj)
	{
		List<ZoneObject> neighbors = new List<ZoneObject>();

		return neighbors;
	}
}
