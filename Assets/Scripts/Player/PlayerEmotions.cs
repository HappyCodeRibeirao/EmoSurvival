using UnityEngine;
using Affdex;
using System.Collections.Generic;

public class PlayerEmotions : AbstractAffdexListener
{
    public float currentDisgust;
    public float currentContempt;
    public float currentValence;

    public override void onFaceFound(float timestamp, int faceId)
    {
        Debug.Log("Found the face");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        Time.timeScale = 0;
     }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Emotions.TryGetValue(Emotions.Disgust, out currentDisgust);
            faces[0].Emotions.TryGetValue(Emotions.Contempt, out currentContempt);
            faces[0].Emotions.TryGetValue(Emotions.Valence, out currentValence);
        }
    }
}