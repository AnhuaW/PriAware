using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ComponentHolderProtocol = Unity.VisualScripting.ComponentHolderProtocol;

public class CubeRandomization : MonoBehaviour
{
    public GameObject[] gameObjects; // Assign 16 GameObjects in the Unity Inspector

    void Start()
    {
        if (gameObjects.Length != 16)
        {
            Debug.LogError("Please assign exactly 16 GameObjects to the list.");
            return;
        }

        // Generate a shuffled list of numbers from 0 to 15
        List<int> numbers = new List<int>();
        for (int i = 0; i < 16; i++)
        {
            numbers.Add(i);
        }
        Shuffle(numbers);

        // Assign each number to a GameObject
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].name = "Cube_" + numbers[i]; // Rename object with the assigned number
            //gameObjects[i].AddComponent<NumberHolder>().assignedNumber = numbers[i];
            gameObjects[i].GetComponent<CubeTextureManager>().index = numbers[i];
            gameObjects[i].GetComponent<CubeTextureManager>().mapTexture();
        }
    }

    // Fisher-Yates shuffle algorithm to randomize the list
    void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[rand];
            list[rand] = temp;
        }
    }
}
