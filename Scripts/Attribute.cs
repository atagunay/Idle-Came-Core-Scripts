using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coin artýsýný etkileyen örnek bir öge. Attribute classýndan kalýtým yaparak ChangeCoinConstant fonksiyonunun içi doldurulur.
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
    /// Nesnenin reachMaxLevel deðiþkeninin deðerini döndürür
    /// Java da ki get fonksiyonu görevinde kullanýlmakltadýr
    /// </summary>
    /// <returns>bool</returns>
    public bool getReachMaxLevel()
    {
        return this.reachMaxLevel;
    }

    /// <summary>
    /// Override edilmesi zorunlu olan fonksiyondur
    /// Ürünün satýn alýnýp alýnamayacaðýný kontrol eder
    /// Eðer satýn alýnabilirse total coini azaltýr
    /// Öge satýn alýndýðý icin total coin çarpaný arttýrýlýr
    /// Ögenin yeni fiyatý level ile doðru orantýlý bir sekilde arttýrýlýr
    /// </summary>
    /// <param name="text"></param>
    public override void ChangeCoinConstant(Text text)
    {
        // Ögenin sayýn alýnýp alýnamayacaðýna karar veren yapý
        if(Coin.totalCoin > this.price && level != maxLevel)
        {
            Coin.totalCoin = Coin.totalCoin - this.price;                           // Öge satýn alýnýrsa total coin azaltýlýr
            
            Coin.coinConstant = Coin.coinConstant + this.attributeConstant;         // Coin çarpaný arttýrýlýr
            Debug.Log("Coin constant" + Coin.coinConstant);

            level = level + 1;                                                      // level arttýrýlýr

            // Max levele ulasýp ulasmadýðýný kontrol eden yapýdýr
            if (level == maxLevel)
            {
                text.text = "COMPLETED";                                            // Eger max levele ulasýldýysa texte COMPLETED yazdýrýlýr 
                this.reachMaxLevel = true;                                          // kontrol deðiþkeninin deðeri true yapýlýr
            }
            else
            {
                this.price = this.price + priceIncreaseAmount * level;              // Eðer level artmaya devam ediyorsa fiyat arttýrýlýr

                text.text = "Motor -" + "LVL" + (level + 1) + " - " + price + "TL"; // Ve yeni bilgiler texte yazdýrýlýr 
            }
        }
    }
}
