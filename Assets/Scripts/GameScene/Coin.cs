using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour
{
    public void TapCoin()
    {

        FindObjectOfType<CoinTapUIManager>().UpdateScore(1);
        GameManager.instance.score++;
        Debug.Log("Score: " + GameManager.instance.score);
        Destroy(gameObject);

    } 
}