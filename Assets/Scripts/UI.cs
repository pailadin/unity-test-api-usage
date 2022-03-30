using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using System;

public class UI : MonoBehaviour
{
    public RectTransform container;
    public GameObject resultPrefab;
    public List<GameObject> resultObjects = new List<GameObject>();

    void Start()
    {
        PreLoadRecordObjects();
    }

    void PreLoadRecordObjects(int amount = 10)
    {
        for (int x = 0; x < amount; ++x)
            CreateNewResultObject();
    }

    GameObject CreateNewResultObject()
    {
        GameObject resultObject = Instantiate(resultPrefab, container.transform);
        resultObjects.Add(resultObject);

        resultObject.SetActive(false);

        return resultObject;
    }

    public void SetResults(JSONNode results)
    {
        DeactivateAllResultObjects();

        for (int x = 0; x < results.Count; ++x)
        {
            GameObject resultObject = x < resultObjects.Count ? resultObjects[x] : CreateNewResultObject();
            resultObject.SetActive(true);

            TextMeshProUGUI quoteObject = resultObject.transform.Find("Quote").GetComponent<TextMeshProUGUI>();

            string quote = results[x]["quote"];
            string character = ((string)(results[x]["character"])).Replace("\"", "");
            string anime = ((string)(results[x]["anime"])).Replace("\"", "");

            quoteObject.text = $"{quote} --{character}, {anime}";
        }

        container.sizeDelta = new Vector2(container.sizeDelta.x, GetContainerHeight(results.Count + 2));
    }

    public void DeactivateAllResultObjects()
    {
        foreach (GameObject resultObject in resultObjects)
            resultObject.SetActive(false);
    }

    float GetContainerHeight(int count)
    {
        float height = 0.0f;

        height += count * (resultPrefab.GetComponent<RectTransform>().sizeDelta.y + 1);
        height += count * container.GetComponent<VerticalLayoutGroup>().spacing;

        return height;
    }
}
