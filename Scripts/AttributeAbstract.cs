using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coinin artýsýný etkilecek nesneler bu classtan kalýtým yaparlar.
/// </summary>
public abstract class AttributeAbstract
{
    protected float attributeConstant;          // Her öge coinin artýsýna bu deðiþken ile orantýlý olarak etkileyecektir
    protected int level;                        // Ögenin kacýncý levelde olduðunu temsil eder
    protected int price;                        // Ögenin baslangýc fiyatýný temsil eder
    protected int priceIncreaseAmount;          // Ögenin her level arttýktan sonra kaç birim pahalanacaðýný temsil eder
    protected int maxLevel;                     // Ögenin ulasabileceði max leveli temsil eder
    protected bool reachMaxLevel;               // Ögenin max levele ulasýp ulasmadýðýný kontrol eden kontrol deðiþkeni
    public abstract void ChangeCoinConstant(Text text); // Bu fonksiyonun içi kalýtým yapan class tarafýndan doldurularak coinin artýþ hýzý deðiþtirilecektir.

}
