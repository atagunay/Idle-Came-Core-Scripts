using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static float coinConstant = 0.5f; // Coin çarpaný, total coin bu çarpan kadar artar.
    public static int coinIncreaseTime = 1;  // Coinin kaç saniyede bir artmasý gerektiðini belirtir.
    public static float totalCoin = 0;       // total coini tutan deðiþken
    private static float tapConstant = 1;    // Her tap yapýldýðýnda coinin ne kadar artacaðýný belirtir. 

    [SerializeField]
    private Text coinText; // Total coinin yazdýrýldýðý Text ögesi.

    private void Start()
    {
        Debug.Log("constant: " + coinConstant);
        StartCoroutine(ConstantIenumerator());  // Coinin sürekli artacaðý iþlemler baþlatýlýyor.
    }

    /// <summary>
    /// totalCoin, coinIncreaseTime sürede arttýrýlýr.
    /// </summary>
    /// <returns></returns>
    IEnumerator ConstantIenumerator()
    {
        // Sonsuz döngü
        while (true)
        {
            yield return new WaitForSeconds(coinIncreaseTime); // coinIncreaseTime kadar bekle 
            IncreaseCoin();     // Total coin arttýrýlýyor
            PrintTotalCoin();   // Total coin kullanýcýya yazdýrýlýyor
        }
       
             
    }

    /// <summary>
    /// Her Tap yapýldýðýnda total coin arttýrýlýr ve sonrasýnda ekrana bastýrýlýr.
    /// </summary>
    public void IncreaseCoinWithTap()
    {
        totalCoin = totalCoin + tapConstant;
        PrintTotalCoin();
    }

    /// <summary>
    /// Total coin arttýrýlýt
    /// </summary>
    private void IncreaseCoin()
    {
        totalCoin = (totalCoin + coinConstant);
    }

    /// <summary>
    /// Total coin ekrana bastýrýlýr
    /// </summary>
    private void PrintTotalCoin()
    {
        // Float olan total coin int turunden bastýrýlýr.
        coinText.text = ((int)totalCoin).ToString();
    }

    /// <summary>
    /// Yeni bir ülkeye açýldýðýnda kullanýlacak fonksiyon. Suan reset görevini görüyor. Ýlerleyen zamanlarda parametreler alarak
    /// özellestirilecek.
    /// </summary>
    public void Reset()
    {
        totalCoin = 0;
        coinConstant = 0.5f;
        coinIncreaseTime = 2;
        tapConstant = 1;

    }

}
