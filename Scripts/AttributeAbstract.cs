using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Coinin art�s�n� etkilecek nesneler bu classtan kal�t�m yaparlar.
/// </summary>
public abstract class AttributeAbstract
{
    protected float attributeConstant;          // Her �ge coinin art�s�na bu de�i�ken ile orant�l� olarak etkileyecektir
    protected int level;                        // �genin kac�nc� levelde oldu�unu temsil eder
    protected int price;                        // �genin baslang�c fiyat�n� temsil eder
    protected int priceIncreaseAmount;          // �genin her level artt�ktan sonra ka� birim pahalanaca��n� temsil eder
    protected int maxLevel;                     // �genin ulasabilece�i max leveli temsil eder
    protected bool reachMaxLevel;               // �genin max levele ulas�p ulasmad���n� kontrol eden kontrol de�i�keni
    public abstract void ChangeCoinConstant(Text text); // Bu fonksiyonun i�i kal�t�m yapan class taraf�ndan doldurularak coinin art�� h�z� de�i�tirilecektir.

}
