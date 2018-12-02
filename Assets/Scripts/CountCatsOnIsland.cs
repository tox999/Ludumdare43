using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCatsOnIsland : MonoBehaviour {

    public float weightOfAllCatsOnIsland = 0;
    [SerializeField] int catLayer = 18;

	void Update()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            weightOfAllCatsOnIsland += collision.gameObject.GetComponent<CatAttack>().catStats.weight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == catLayer)
        {
            weightOfAllCatsOnIsland -= collision.gameObject.GetComponent<CatAttack>().catStats.weight;
        }
    }
}
