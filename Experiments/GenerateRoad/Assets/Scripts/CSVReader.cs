using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class CSVReader : MonoBehaviour
{
    public TextAsset csvFile; // Drag your CSV file here in inspector
    public List<string[]> csvData = new List<string[]>();
    

    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] records = csvFile.text.Split('\n');

        foreach (string record in records)
        {
            csvData.Add(record.Split(','));
        }

        // Optionally print the data to the console
        foreach (var data in csvData)
        {
            Debug.Log(string.Join("|", data));
        }
    }
}
