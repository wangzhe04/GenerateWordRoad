using UnityEngine;
using System.Collections.Generic;

public class WordToCubes : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab of the cube you want to instantiate.
    public float cubeSize = 1f;  // Size of each cube.
    public float spacing = 1.2f; // Space between each cube.

    public Vector3 startPos; // Starting position of the first cube.

    private Dictionary<char, bool[,]> letterMaps = new Dictionary<char, bool[,]>();



    private void Start()
    {

        // For simplicity, let's define patterns for just a couple of letters.
        // 'A' represented as an A shape in a 3x3 grid
        letterMaps.Add('A', new bool[,]
        {
            { false, true, false },
            { true, false, true },
            { true, true, true },
            { true, false, true },
            { true, false, true }
        });

        letterMaps.Add('B', new bool[,]
        {
            { true, true, true },
            { true, false, true },
            { true, true, true },
            { true, false, true },
            { true, true, true }
        });

        letterMaps.Add('C', new bool[,]
        {
            { true, true, true },
            { false, false, true },
            { false, false, true },
            { false, false, true },
            { true, true, true }
        });



        

        // Add other letters as needed...

        GenerateWord("ABC", startPos);
    }

    void GenerateWord(string word, Vector3 startPosition)
    {   
        Vector3 currentPos = startPosition;

        // inverse the string to reverse the order of the letters.
        char[] charArray = word.ToCharArray();
        System.Array.Reverse(charArray);
        word = new string(charArray);

        foreach (char letter in word.ToUpper()) // Convert input to uppercase to match our patterns.
        {
            if (letterMaps.ContainsKey(letter))
            {
                GenerateLetter(letter, currentPos);
                currentPos.x += cubeSize * spacing * 5; // Move to the next position for the next letter.
            }
        }
    }

    void GenerateLetter(char letter, Vector3 startPos)
    {
        bool[,] pattern = letterMaps[letter];
        for (int i = 0; i < pattern.GetLength(0); i++)
        {
            for (int j = 0; j < pattern.GetLength(1); j++)
            {
                if (pattern[i, j])
                {
                    Instantiate(cubePrefab, new Vector3(startPos.x + j * cubeSize * spacing, startPos.y + cubeSize / 2, startPos.z + i * cubeSize * spacing), Quaternion.identity);
                }
            }
        }
    }


}
