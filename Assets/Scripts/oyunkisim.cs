using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class oyunkisim : MonoBehaviour
{
    [SerializeField] private float hiz = 10.2f;
    [SerializeField] private float ivme = 0.2f;
    [SerializeField] private float donmehiz = 200f;
    private int direksiyon;

    [SerializeField] private TMP_Text tmp;
    [SerializeField] private float skorcarpan;
    private float skor;

    public const string yuksekskoranahtar = "YuksekSkor";
    public const string skoranahtar = "Skor";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hiz+=ivme*Time.deltaTime;
        skor+=skorcarpan*Time.deltaTime;
        tmp.text = "Puan: " + Mathf.FloorToInt(skor).ToString();
        transform.Rotate(0f,direksiyon*donmehiz*Time.deltaTime,0f);
        transform.Translate(Vector3.forward*hiz*Time.deltaTime);
    }
    public void DireksiyonDeger(int deger){
        direksiyon = deger;
    }
    private void OnTriggerEnter(Collider carpma){
        if(carpma.CompareTag("engel")){
            SceneManager.LoadScene(0);
        }
        if(carpma.CompareTag("odul")){
            Destroy(carpma.gameObject);
            skor+=10;
        }
    }
    private void OnDestroy(){
        PlayerPrefs.SetInt(skoranahtar,Mathf.FloorToInt(skor));
        int sonyuksekskor = PlayerPrefs.GetInt(yuksekskoranahtar,0);
        if(skor>sonyuksekskor){
            PlayerPrefs.SetInt(yuksekskoranahtar,Mathf.FloorToInt(skor));
        }
    }  // Bu kısımda en yüksek skor ve simdikiskor shared pref4erences olarak uygulamaya ekleniyor ve kaydediliyor.
}
