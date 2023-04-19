using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct PrebuffSettings
    {
        public float levelY; // Level Y after which prebuffs will be generated
        public PrebuffData[] prebuffData; // Array of prebuff data for each difficulty level
    }

    [System.Serializable]
    public struct PrebuffData
    {
        public GameObject prebuffPrefab; // Prebuff prefab
        public float chance; // Chance of generating the prebuff
    }

    public PrebuffSettings[] settings; // Public struct for the prebuff settings
    
}