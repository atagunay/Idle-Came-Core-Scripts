using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Yeni bir �ge a��ld���nda a��lan �genin nesnesi bu class taraf�ndan olu�turulacakt�r
/// </summary>
public class AttributeManager : MonoBehaviour
{
    /// <summary>
    /// Nesneler ve ilgili butonlar beraber tutulmas�n� sa�layan struct yap�s�
    /// </summary>
    [Serializable]
    private class MotorAndButton
    {
        
        public Button motorButton;      // �lgili buton atan�r
        public Attribute attribute;     // �lgili nesnenin referans� olusturulur. (Edit�rde g�z�kmez)

        // Nesneyi olusturabilmek i�in constructor fonksiyonuna parametre olarak atanacak veriler al�n�r
        public float attributeConstant; 
        public int priceIncreaseAmount;
        public int level;
        public int maxLevel;
        public int price;

        /// <summary>
        /// Nesneyi olusturucak fonksiyondur.
        /// Start an�nda bu fonksiyon �a��r�larak nesne yarat�l�r
        /// </summary>
        public void AttributeCall()
        {
            attribute = new Attribute(attributeConstant, priceIncreaseAmount, level, maxLevel, price);
        }
        
    }

    /// <summary>
    /// Olusturulan Struct yap�s�n�n edit�rden d�zenlenmesini sa�layan referansd�r
    /// Bu olmadan inspector alan�ndan veri giri�i sa�lanamaz
    /// </summary>
    [SerializeField]
    private MotorAndButton[] motorAndButtons;

    /// <summary>
    /// Hangi motorda kald���m�z� tutan index
    /// </summary>
    private int motorIndex = 0;

    /// <summary>
    /// Oyun baslang�c�nda �al�s�r
    /// </summary>
    private void Start()
    {
        // T�m struct yap�s�na ait nesnelerin i�inde bulunan attribute nesnesi olusturulur
        foreach (var a in motorAndButtons)
        {
            a.AttributeCall();
        }
    }

    /// <summary>
    /// Butoa bas�ld���nda ger�eklesecek i� kurallar� burada bulunur
    /// </summary>
    public void MotorButton()
    {
        // Strcut yap�s�n�n i�inde bulunan attribute nesnesindeki fonksiyon �a��r�larak gerekli i�lemlerin yap�lmas� sa�lan�r
        // parametre olarak struct yap�s�nda bulunan butonun child eleman� olan text g�nderilir
        motorAndButtons[motorIndex].attribute.ChangeCoinConstant(motorAndButtons[motorIndex].motorButton.transform.GetChild(0).gameObject.GetComponent<Text>());
        
        // �genin max levele ulas�p ulasmad���n� denetleyen yapd�r�
        if(motorAndButtons[motorIndex].attribute.getReachMaxLevel() == true)
        {
            // Max levele ulasan �genin butonunun etkilesimini kapat�r
            motorAndButtons[motorIndex].motorButton.interactable = false;
            
            // Bir sonraki �geye ge�memizi sa�layan kontrol de�i�keni 1 artt�r�l�r
            motorIndex = motorIndex + 1;

            // Bir sonraki �ge mevcutsa onun butonu etkile�ime a��l�r e�er de�ilse hata yakalan�r
            try
            {
                motorAndButtons[motorIndex].motorButton.interactable = true;
            }
            catch
            {
                Debug.Log("Array index out");
            }
           
        }
       
    }
    
}

