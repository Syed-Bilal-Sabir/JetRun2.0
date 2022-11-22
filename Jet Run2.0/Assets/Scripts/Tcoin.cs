using UnityEngine.UI;
using UnityEngine;

public class Tcoin : MonoBehaviour
{
    public Text tcoins;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tcoins.text = "Coin:" + Coin.Tcoins;
    }
}
