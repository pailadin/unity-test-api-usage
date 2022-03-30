using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Text;
using System;
using System.Linq;
using SimpleJSON;

public class AppManager : MonoBehaviour
{
    public enum SearchType
    {
        Random = 0,
        Title = 1,
        Character = 2,
    }

    [SerializeField] private string baseQuotesUrl = "https://animechan.vercel.app/api/quotes";
    [SerializeField] private string titleQuotesEndpoint = "/anime?title=";
    [SerializeField] private string characterQuotesEndpoint = "/character?name=";

    [SerializeField] private TextMeshProUGUI input;

    private UI ui;
 
    private void Start()
		{
			  ui = GetComponent<UI>();
		}

    IEnumerator GetData(string url)
    {       
        UnityWebRequest webReq = new UnityWebRequest();
        webReq.downloadHandler = new DownloadHandlerBuffer();
        webReq.url = url;

        yield return webReq.SendWebRequest();

        string rawJson = Encoding.Default.GetString(webReq.downloadHandler.data);

        if (rawJson == "{\"error\":\"No related quotes found!\"}")
        {
            ui.DeactivateAllResultObjects();
        }
        else
        {
            JSONNode results = JSON.Parse(rawJson);

            if (results.Count > 0)
            {
                ui.SetResults(results);
            }
            else
            {
                ui.DeactivateAllResultObjects();
            }
        }
    }

    public void PerformSearch(SearchType searchType)
    {
        // https://forum.unity.com/threads/textmesh-pro-ugui-hidden-characters.505493/#post-3358461:
        string searchTerm = input.text.Trim((char)8203);;
        string url = baseQuotesUrl;

        if (!String.IsNullOrWhiteSpace(searchTerm))
        {
            if (searchType == SearchType.Title)
            {
                url = baseQuotesUrl + titleQuotesEndpoint + searchTerm;
            }
            else if (searchType == SearchType.Character)
            {
                url = baseQuotesUrl + characterQuotesEndpoint + searchTerm;
            }
        }

        StartCoroutine("GetData", url);
    }

    public void PerformSearchByCharacter()
    {
        PerformSearch(SearchType.Character);
    }

    public void PerformSearchByTitle()
    {
        PerformSearch(SearchType.Title);
    }
}
