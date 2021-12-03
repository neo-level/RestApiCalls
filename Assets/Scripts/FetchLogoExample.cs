using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FetchLogoExample : MonoBehaviour
{
    private IEnumerator Start()
    {
        string url = "https://upload.wikimedia.org/wikipedia/commons/8/8a/Official_unity_logo.png";

        var request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.downloadHandler is DownloadHandlerTexture textureHandler)
            {
                var texture2D = textureHandler.texture;
            
                var spriteRenderer = GetComponent<SpriteRenderer>();
                var rect = new Rect(0, 0, texture2D.width, texture2D.height);
            
                spriteRenderer.sprite = Sprite.Create(texture2D, rect, Vector2.zero);
            }
        }
        else
        {
            Debug.Log(request.error);
        }
    }
}