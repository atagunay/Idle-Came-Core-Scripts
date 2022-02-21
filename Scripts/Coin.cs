using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static float coinConstant = 0.5f; // Coin �arpan�, total coin bu �arpan kadar artar.
    public static int coinIncreaseTime = 1;  // Coinin ka� saniyede bir artmas� gerekti�ini belirtir.
    public static float totalCoin = 0;       // total coini tutan de�i�ken
    private static float tapConstant = 1;    // Her tap yap�ld���nda coinin ne kadar artaca��n� belirtir. 

    [SerializeField]
    private Text coinText; // Total coinin yazd�r�ld��� Text �gesi.

    private void Start()
    {
        Debug.Log("constant: " + coinConstant);
        StartCoroutine(ConstantIenumerator());  // Coinin s�rekli artaca�� i�lemler ba�lat�l�yor.
    }

    /// <summary>
    /// totalCoin, coinIncreaseTime s�rede artt�r�l�r.
    /// </summary>
    /// <returns></returns>
    IEnumerator ConstantIenumerator()
    {
        // Sonsuz d�ng�
        while (true)
        {
            yield return new WaitForSeconds(coinIncreaseTime); // coinIncreaseTime kadar bekle 
            IncreaseCoin();     // Total coin artt�r�l�yor
            PrintTotalCoin();   // Total coin kullan�c�ya yazd�r�l�yor
        }
       
             
    }

    /// <summary>
    /// Her Tap yap�ld���nda total coin artt�r�l�r ve sonras�nda ekrana bast�r�l�r.
    /// </summary>
    public void IncreaseCoinWithTap()
    {
        totalCoin = totalCoin + tapConstant;
        PrintTotalCoin();
    }

    /// <summary>
    /// Total coin artt�r�l�t
    /// </summary>
    private void IncreaseCoin()
    {
        totalCoin = (totalCoin + coinConstant);
    }

    /// <summary>
    /// Total coin ekrana bast�r�l�r
    /// </summary>
    private void PrintTotalCoin()
    {
        // Float olan total coin int turunden bast�r�l�r.
        coinText.text = ((int)totalCoin).ToString();
    }

    /// <summary>
    /// Yeni bir �lkeye a��ld���nda kullan�lacak fonksiyon. Suan reset g�revini g�r�yor. �lerleyen zamanlarda parametreler alarak
    /// �zellestirilecek.
    /// </summary>
    public void Reset()
    {
        totalCoin = 0;
        coinConstant = 0.5f;
        coinIncreaseTime = 2;
        tapConstant = 1;

    }

}
