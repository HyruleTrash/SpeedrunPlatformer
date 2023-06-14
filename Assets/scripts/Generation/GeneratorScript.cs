using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    [System.Serializable]
    public class LevelChunk
    {
        public GameObject LevelObject;
        public int Difficulty;
        public string theme;
        public int sizeW;
    }
    [System.Serializable]
    public class LevelTheme
    {
        public string theme;
        public LevelChunk[] Level;
    }

    [SerializeField]
    public LevelTheme[] Levels;

    public GameObject Player;
    public GameObject Camera;


    int currentDifficulty = 0;
    string currentTheme = "";
    int distance = 0;
    int lastLevelId = -1;

    private void Start()
    {
        // pick random theme for start
        currentTheme = Levels[Random.Range(0, Levels.Length)].theme;

        // load three start level chunks
        for (int i = 0; i < 3; i++)
        {
            GenerateNewLevelChunk();
        }
    }

    private void Update()
    {
        // loop through existing levels and delete if they are to far away
        int currentChildCount = transform.childCount;
        for (int i = 0; i < currentChildCount; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<LevelInfo>().sizeW + transform.GetChild(i).transform.position.x + 4 < Camera.transform.GetChild(0).transform.position.x)
            {
                Destroy(transform.GetChild(i).gameObject);
                GenerateNewLevelChunk();
            }
        }
    }

    //creates a new chunk
    public void GenerateNewLevelChunk()
    {
        // get data for levels
        int themeID = GetIdFromTheme(currentTheme);
        int gottenId = Random.Range(0, Levels[themeID].Level.Length);
        LevelChunk gottenLevel = Levels[themeID].Level[gottenId];

        // make sure level fits
        while (gottenLevel.Difficulty != currentDifficulty && gottenId == lastLevelId)
        {
            gottenId = Random.Range(0, Levels[themeID].Level.Length);
            gottenLevel = Levels[themeID].Level[gottenId];
            if (gottenLevel.Difficulty == currentDifficulty && gottenId != lastLevelId)
            {
                break;
            }
        }

        // set found level and instantiate
        lastLevelId = gottenId;
        GameObject LevelInstance = Instantiate(gottenLevel.LevelObject, new Vector3(distance, 0, 0), new Quaternion(), transform);

        // set LevelData
        LevelInstance.GetComponent<LevelInfo>().Difficulty = Levels[themeID].Level[gottenId].Difficulty;
        LevelInstance.GetComponent<LevelInfo>().theme = Levels[themeID].Level[gottenId].theme;
        LevelInstance.GetComponent<LevelInfo>().sizeW = Levels[themeID].Level[gottenId].sizeW;
        LevelInstance.GetComponent<LevelInfo>().Player = Player;

        // set distance
        distance += gottenLevel.sizeW + 1;
    }

    // gets the id of the corresponding theme
    public int GetIdFromTheme(string theme)
    {
        for (int i = 0; i < Levels.Length; i++)
        {
            if (Levels[i].theme == theme)
            {
                return i;
            }
        }
        return -1;
    }
}
