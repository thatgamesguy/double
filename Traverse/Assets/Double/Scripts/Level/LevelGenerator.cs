using UnityEngine;

/// <summary>
/// Spawns new levels when required.
/// </summary>
public class LevelGenerator : MonoBehaviour 
{
	/// <summary>
	/// Instructions UI object.
	/// </summary>
    public Instructions instructions;

	/// <summary>
	/// When score greater than this, harder levels will be spawned.
	/// </summary>
    public int scoreUntilHarderLevels = 2;

	/// <summary>
	/// The initial level sections to generate.
	/// </summary>
	public int initialSectionsToGenerate = 2;

	/// <summary>
	/// Height of each level section.
	/// </summary>
    public float yIncrease = 11.5f;

	public GameObject initialLevel;

	/// <summary>
	/// The initial level pool. Easier levels to be spawned at start of game should be added to this array.
	/// </summary>
    public GameObject[] initialLevels;

	/// <summary>
	/// The level prefabs.
	/// </summary>
    public GameObject[] levelPrefabs;

	/// <summary>
	/// A random colour from this selection is chosen for each level section.
	/// </summary>
	public LevelColours[] levelColours;

	private static readonly float[] ADDITIONS = new float[]{-4.4f, 4.4f};

	private float currentY;

	void Start ()
    {
		currentY = transform.position.y - yIncrease;

		GenerateInitialLevels();
        Generate();
	}

	void Update()
	{
		if(IsNewPieceRequired())
		{
			for(int i = 0; i < 2; i++)
			{
				Generate();
			}
		}
	}

	/// <summary>
	/// Generate level sections and increases Y position to compensate.
	/// </summary>
	public void Generate()
	{
		UpdateYPosition();

		GameObject[] levelPrefabsToGenerate = new GameObject[2];

		if(Score.instance.GetScore() <= scoreUntilHarderLevels)
		{
			levelPrefabsToGenerate[0] = initialLevels[Random.Range(0, initialLevels.Length)];
			levelPrefabsToGenerate[1] = initialLevels[Random.Range(0, initialLevels.Length)];
		}
		else
		{
			levelPrefabsToGenerate[0] = levelPrefabs[Random.Range(0, levelPrefabs.Length)];

			//10% chance to have same level on both sides
			if(Random.value <= 0.1)
			{
				levelPrefabsToGenerate [1] = levelPrefabsToGenerate [0];
			}
			else
			{
				levelPrefabsToGenerate[1] = levelPrefabs[Random.Range(0, levelPrefabs.Length)];
			}

		}

		GenerateLevelSection(levelPrefabsToGenerate);
	}

	private void GenerateInitialLevels()
	{
		UpdateYPosition();

        GameObject[] intialLevelsToGenerate = new GameObject[] { initialLevel, initialLevel };
        LevelColours levelColour = levelColours[Random.Range(0, levelColours.Length)];
        GenerateLevelSection(intialLevelsToGenerate, levelColour);

        instructions.SetColours(levelColour);
	}


    private void UpdateYPosition()
    {
        currentY += yIncrease;
    }


    private void GenerateLevelSection(GameObject[] prefabs)
    {
		LevelColours levelColour = levelColours[Random.Range (0, levelColours.Length)];

        GenerateLevelSection(prefabs, levelColour);
			
    }

    private void GenerateLevelSection(GameObject[] prefabs, LevelColours levelColour)
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject level = (GameObject)Instantiate(prefabs[i]);
            level.transform.position = new Vector2(transform.position.x + ADDITIONS[i], currentY);
            level.transform.SetParent(transform, false);



            level.GetComponent<LevelColour>().UpdateColours(
                levelColour.fromColour, levelColour.toColour,
                (i == 0) ? Position.Left : Position.Right);

        }
    }


    private bool IsNewPieceRequired()
	{
		return transform.parent.position.y <= -(currentY - yIncrease);
	}
}

/// <summary>
/// Holds colours for each level section.
/// </summary>
[System.Serializable]
public class LevelColours
{
	public Color fromColour;
	public Color toColour;
}

