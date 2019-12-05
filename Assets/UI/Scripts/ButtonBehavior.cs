using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject character;
    private SaveData saveData;
    public void SaveGame()
    {
        List<Attribute> attributes = new List<Attribute>();
        foreach (Attribute attribute in character.GetComponents<Attribute>())
        {
            attributes.Add(attribute);
        }
        saveData = gameObject.AddComponent<SaveData>();
        saveData.attributes = attributes;
        saveData.playerPosition = character.transform.position;
        saveData.playerRotation = character.transform.rotation;
    }
    public void LoadGame()
    {
        //character.transform.position = aaa.playerPosition;
        //character.transform.rotation = aaa.playerRotation;
    }
}
