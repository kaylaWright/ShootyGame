using UnityEngine;
using System.Collections;

public class ZoneGenerator : MonoBehaviour 
{

	public GameObject[] gameTiles; 
	public float[] tileProbabilities;

	public int numberOfTiles = 100;

	private float hexRadius;
	private float xOffset = 0.0f;
	private float yOffset = 0.0f;

	public float heightVariance = 2.0f;

	void Awake () 
	{
		float hexWidth = gameTiles[0].GetComponent<MeshRenderer>().bounds.size.x;
		hexRadius = hexWidth / Mathf.Sqrt(4);

		xOffset = hexRadius * Mathf.Sqrt(3);
		yOffset = hexRadius * 1.5f;

		for(int i = 0; i < Mathf.Sqrt(numberOfTiles); i++)
		{
			for(int j = 0; j < Mathf.Sqrt(numberOfTiles); j++)
			{
				int tileNum = DetermineRandomTile();

				Vector2 currPos = HexOffset(i, j);
				Vector3 worldPos = new Vector3(currPos.x, Random.Range(-heightVariance, heightVariance), currPos.y);

				GameObject currHex = Instantiate(gameTiles[tileNum], worldPos, Quaternion.identity) as GameObject;
				currHex.transform.Rotate(new Vector3(-90.0f, 90.0f, 0.0f));
				currHex.transform.parent = this.transform;
			}
		}
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
}
