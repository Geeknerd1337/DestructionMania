using UnityEngine;


public class levelselector : MonoBehaviour
{

    public Scenefader scenefader;


    public void Select(string levelName)
    {
        scenefader.Fadeto(levelName);
    }

}
