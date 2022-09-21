using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class anamenu : MonoBehaviour
{
    public const string yuksekskoranahtar = "YuksekSkor";
    public const string skoranahtar = "Skor";
    
    [SerializeField] TMP_Text yuksekskoryazi;
    [SerializeField] TMP_Text skoryazi;
    // Start is called before the first frame update
    void Start()
    {   
        int yuksekskor = PlayerPrefs.GetInt(yuksekskoranahtar,0);
        //ikinci değer eğer değer alınamazsa yani yoksa değeri 0 olarak vermeyi sağlar
        int skor = PlayerPrefs.GetInt(skoranahtar,0);
        
        yuksekskoryazi.text = "En Yüksek Skorunuz: "+ yuksekskor.ToString(); 
        skoryazi.text = "Skorunuz: "+ skor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Tekrar(){
        SceneManager.LoadScene(1);
    }
}
