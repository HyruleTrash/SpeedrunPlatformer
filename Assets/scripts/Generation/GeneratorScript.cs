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
        public float sizeW;
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
}
