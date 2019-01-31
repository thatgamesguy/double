using UnityEngine;
using System.Collections;

/// <summary>
/// Spawns new levels when required. Used for the main menu scene.
/// </summary>
public class MenuLevelGenerator : MonoBehaviour
{
	/// <summary>
	/// The initial level sections to generate.
	/// </summary>
    public int initialSectionsToGenerate = 2;

	/// <summary>
	/// Height of each level section.
	/// </summary>
    public float yIncrease = 11.5f;

	/// <summary>
	/// The level prefabs.
	/// </summary>
    public GameObject[] levelPrefabs;

	/// <summary>
	/// A random colour from this selection is chosen for each level section.
	/// </summary>
    public LevelColours[] levelColours;

    private static readonly float[] ADDITIONS = new float[] { -4.4f, 4.4f };

    private float currentY;

    void Start()
    {
        currentY = transform.position.y - yIncrease;


        for(int i = 0; i < initialSectionsToGenerate; i++)
        {
            Generate();
        }
   

    }

    void Update()
    {
        if (IsNewPieceRequired())
        {
            for (int i = 0; i < 2; i++)
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

        GameObject[] levelsToGenerate = new GameObject[] {
         levelPrefabs[Random.Range(0, levelPrefabs.Length)],
         levelPrefabs[Random.Range(0, levelPrefabs.Length)] };

        GenerateLevelSection(levelsToGenerate);
    }

    private void UpdateYPosition()
    {
        currentY += yIncrease;
    }


    private void GenerateLevelSection(GameObject[] prefabs)
    {
        LevelColours levelColour = levelColours[Random.Range(0, levelColours.Length)];

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
