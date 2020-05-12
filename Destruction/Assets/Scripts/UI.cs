using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
  public Text text;
  public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      text.text = player.transform.position.z.ToString();
    }
}
