using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int Tcoins=0;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Coin"))
            Tcoins = PlayerPrefs.GetInt("Coin");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(20*Time.deltaTime,0,0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.tag=="Player")
        {
            PlayerManager.numberofCoins += 1;
            Tcoins += 1;
            PlayerPrefs.SetInt("Coin",Tcoins);
            Destroy(gameObject);

            FindObjectOfType<AudioManager>().PlaySound("Coinscollection");
        }
    }
}
