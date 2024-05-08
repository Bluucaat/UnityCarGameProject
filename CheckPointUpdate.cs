using UnityEngine;

public class CheckPointUpdate : MonoBehaviour

{
    int checkPointCount;
    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] GameObject[] characterPrefabs;
    private Vector3[][] coordArray = {
        new Vector3[]{new Vector3(64.39f, 0.19f, 44.02f), new Vector3(185.57f, 0.176f, 45.03f), new Vector3(73.52057f, 0.176f, 165.4696f), new Vector3(93.25545f, 0.369947f, 207.8114f), new Vector3(214.01f, 0.176f, 165.1f),
        new Vector3(46.07f, 0.1699463f, 107.9f), new Vector3(222.2603F, 0.1699463f, 100.7862f)},
        new Vector3[]{new Vector3(0, 0, 0), new Vector3(0,0,0), new Vector3(0, -90,0), new Vector3(0, 0, 0), new Vector3(0, -90, 0),
        new Vector3(0, -90, 0), new Vector3(0, 180, 0)}
    };
    private int currentCoords = -1;
    private int coordinatesChoice;
    private int characterChoice;
    public void Start()
    {
        GenerateCheckpoint();
    }


    public void GenerateCheckpoint()
    {
        
        
        while (currentCoords == coordinatesChoice)
        {
            coordinatesChoice = (Random.Range(0, coordArray[0].Length));
        }
        currentCoords = coordinatesChoice;
        GameObject newCheckpoint = Instantiate(checkPointPrefab, coordArray[0][coordinatesChoice], Quaternion.identity);
        newCheckpoint.transform.rotation = Quaternion.Euler(coordArray[1][coordinatesChoice]);
        if ((checkPointCount % 2 == 0)) { 
        characterPrefabs = GameObject.FindGameObjectsWithTag("NPC");
        characterChoice = (Random.Range(0, characterPrefabs.Length));
        GameObject newCharacter = Instantiate(characterPrefabs[characterChoice], newCheckpoint.transform.position, Quaternion.identity);
        newCharacter.tag = "ActiveNPC";
        newCharacter.transform.rotation = newCheckpoint.transform.rotation;
        newCharacter.transform.Rotate(0, -90, 0);
            if (newCheckpoint.transform.rotation != Quaternion.Euler(0, -90, 0))
            {
                newCharacter.transform.position = new Vector3(newCharacter.transform.position.x + 3, newCharacter.transform.position.y, newCharacter.transform.position.z);
            }
            else
            {
                newCharacter.transform.position = new Vector3(newCharacter.transform.position.x, newCharacter.transform.position.y, newCharacter.transform.position.z + 3);
            }
        }
        checkPointCount++;
    }
}
