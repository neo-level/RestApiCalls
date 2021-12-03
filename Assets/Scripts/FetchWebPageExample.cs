using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FetchWebPageExample : MonoBehaviour
{
    private IEnumerator Start()
    {
        var request = UnityWebRequest.Get("https://www.google.com/");
        yield return request.SendWebRequest();

        Debug.Log(request.result == UnityWebRequest.Result.Success ? request.downloadHandler.text : request.error);
    }
}
