using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Yeni bir öge açýldýðýnda açýlan ögenin nesnesi bu class tarafýndan oluþturulacaktýr
/// </summary>
public class AttributeManager : MonoBehaviour
{
    /// <summary>
    /// Nesneler ve ilgili butonlar beraber tutulmasýný saðlayan struct yapýsý
    /// </summary>
    [Serializable]
    private class MotorAndButton
    {
        
        public Button motorButton;      // Ýlgili buton atanýr
        public Attribute attribute;     // Ýlgili nesnenin referansý olusturulur. (Editörde gözükmez)

        // Nesneyi olusturabilmek için constructor fonksiyonuna parametre olarak atanacak veriler alýnýr
        public float attributeConstant; 
        public int priceIncreaseAmount;
        public int level;
        public int maxLevel;
        public int price;

        /// <summary>
        /// Nesneyi olusturucak fonksiyondur.
        /// Start anýnda bu fonksiyon çaðýrýlarak nesne yaratýlýr
        /// </summary>
        public void AttributeCall()
        {
            attribute = new Attribute(attributeConstant, priceIncreaseAmount, level, maxLevel, price);
        }
        
    }

    /// <summary>
    /// Olusturulan Struct yapýsýnýn editörden düzenlenmesini saðlayan referansdýr
    /// Bu olmadan inspector alanýndan veri giriþi saðlanamaz
    /// </summary>
    [SerializeField]
    private MotorAndButton[] motorAndButtons;

    /// <summary>
    /// Hangi motorda kaldýðýmýzý tutan index
    /// </summary>
    private int motorIndex = 0;

    /// <summary>
    /// Oyun baslangýcýnda çalýsýr
    /// </summary>
    private void Start()
    {
        // Tüm struct yapýsýna ait nesnelerin içinde bulunan attribute nesnesi olusturulur
        foreach (var a in motorAndButtons)
        {
            a.AttributeCall();
        }
    }

    /// <summary>
    /// Butoa basýldýðýnda gerçeklesecek iþ kurallarý burada bulunur
    /// </summary>
    public void MotorButton()
    {
        // Strcut yapýsýnýn içinde bulunan attribute nesnesindeki fonksiyon çaðýrýlarak gerekli iþlemlerin yapýlmasý saðlanýr
        // parametre olarak struct yapýsýnda bulunan butonun child elemaný olan text gönderilir
        motorAndButtons[motorIndex].attribute.ChangeCoinConstant(motorAndButtons[motorIndex].motorButton.transform.GetChild(0).gameObject.GetComponent<Text>());
        
        // Ögenin max levele ulasýp ulasmadýðýný denetleyen yapdýrý
        if(motorAndButtons[motorIndex].attribute.getReachMaxLevel() == true)
        {
            // Max levele ulasan ögenin butonunun etkilesimini kapatýr
            motorAndButtons[motorIndex].motorButton.interactable = false;
            
            // Bir sonraki ögeye geçmemizi saðlayan kontrol deðiþkeni 1 arttýrýlýr
            motorIndex = motorIndex + 1;

            // Bir sonraki öge mevcutsa onun butonu etkileþime açýlýr eðer deðilse hata yakalanýr
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

