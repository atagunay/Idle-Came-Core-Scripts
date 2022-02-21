using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coin art�s�n� etkileyen �rnek bir �ge. Attribute class�ndan kal�t�m yaparak ChangeCoinConstant fonksiyonunun i�i doldurulur.
/// </summary>
public class Attribute : AttributeAbstract
{
    /// <summary>
    /// Constructor
    /// </summary>
    public Attribute(float attributeConstant, int priceIncreaseAmount, int level, int maxLevel, int price)
    {
        this.attributeConstant = attributeConstant;
        this.priceIncreaseAmount = priceIncreaseAmount;
        this.level = level;
        this.price = price;
        this.maxLevel = maxLevel;
        this.reachMaxLevel = false;
    }

    /// <summary>
    /// Nesnenin reachMaxLevel de�i�keninin de�erini d�nd�r�r
    /// Java da ki get fonksiyonu g�revinde kullan�lmakltad�r
    /// </summary>
    /// <returns>bool</returns>
    public bool getReachMaxLevel()
    {
        return this.reachMaxLevel;
    }

    /// <summary>
    /// Override edilmesi zorunlu olan fonksiyondur
    /// �r�n�n sat�n al�n�p al�namayaca��n� kontrol eder
    /// E�er sat�n al�nabilirse total coini azalt�r
    /// �ge sat�n al�nd��� icin total coin �arpan� artt�r�l�r
    /// �genin yeni fiyat� level ile do�ru orant�l� bir sekilde artt�r�l�r
    /// </summary>
    /// <param name="text"></param>
    public override void ChangeCoinConstant(Text text)
    {
        // �genin say�n al�n�p al�namayaca��na karar veren yap�
        if(Coin.totalCoin > this.price && level != maxLevel)
        {
            Coin.totalCoin = Coin.totalCoin - this.price;                           // �ge sat�n al�n�rsa total coin azalt�l�r
            
            Coin.coinConstant = Coin.coinConstant + this.attributeConstant;         // Coin �arpan� artt�r�l�r
            Debug.Log("Coin constant" + Coin.coinConstant);

            level = level + 1;                                                      // level artt�r�l�r

            // Max levele ulas�p ulasmad���n� kontrol eden yap�d�r
            if (level == maxLevel)
            {
                text.text = "COMPLETED";                                            // Eger max levele ulas�ld�ysa texte COMPLETED yazd�r�l�r 
                this.reachMaxLevel = true;                                          // kontrol de�i�keninin de�eri true yap�l�r
            }
            else
            {
                this.price = this.price + priceIncreaseAmount * level;              // E�er level artmaya devam ediyorsa fiyat artt�r�l�r

                text.text = "Motor -" + "LVL" + (level + 1) + " - " + price + "TL"; // Ve yeni bilgiler texte yazd�r�l�r 
            }
        }
    }
}
