using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainObject : MonoBehaviour
{
    private Vector3 startTouchPos, curTouchPos, startDif, currentDif, difDif;
    public bool pause;
    public GameObject successScreen;

    void Start()
    {
        pause = false;
    }

    void Update()
    {
        isSuccess();
        if (!pause)
        {
            // Hareket ettirme kodları

            // Parmak ekrana dokunduğunda olanlar
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0);
                startTouchPos = Camera.main.ScreenToWorldPoint(touch.position); // Parmak ekrana dokunduğu andaki konumu
                startTouchPos.z = 0;
                startDif = (startTouchPos - this.gameObject.transform.position); // Parmak ekrana dokunduğu anda parmağın konumu ile hareket edecek nesnenin konumu arasındaki fark
            }
            // Parmağı ekranda kaydırınca olanlar
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.GetTouch(0);
                curTouchPos = Camera.main.ScreenToWorldPoint(touch.position); // Parmağın şu anki konumu
                curTouchPos.z = 0;
                currentDif = (curTouchPos - this.gameObject.transform.position); // Parmağın şu anki konumu ile nesnenin şu anki konumu arasındaki fark
                difDif = currentDif - startDif; // Ekrana ilk dokunulduğundaki parmak ve nesne arasındaki konum farkı ile şu andaki parmak ve nesne arasındaki konum farkınının farkı. 
                // Bunu yapma sebebim; eğer parmak ile nesne arasındaki fark hep aynı kalırsa kolay bir şekilde hareket ettirilebilir. Hep aynı kalması için de konum farkına göre nesneyi hareket ettiriyorum.

                // Sağa haraket ettirme
                if (currentDif != startDif && difDif.x > difDif.y && difDif.x > 0.3f && difDif.x > 0)
                {
                    this.gameObject.transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
                }
                // Üste hareket ettirme
                else if (currentDif != startDif && difDif.y > difDif.x && difDif.y > 0.3f && difDif.y > 0)
                {
                    this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);
                }
                // Sola hareket ettirme
                else if (currentDif != startDif && -difDif.x > -difDif.y && difDif.x < -0.3f && difDif.x < 0)
                {
                    this.gameObject.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y);
                }
                // Alta hareket ettirme
                else if (currentDif != startDif && -difDif.y > -difDif.x && difDif.y < -0.3f && difDif.y < 0)
                {
                    this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);
                }
            }

            // -- Hareket ettirme kodları --
        }

    }

    public void restart()
    {
        SceneManager.LoadScene(0);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void isSuccess()
    {
        // Bölümü geçmek için ana küpler haricindeki küplerin sayısının kontrolü. Eğer sayı 0 ise bölüm geçildi.
        if (GameObject.FindGameObjectsWithTag("OtherCube").Length == 0 && GameObject.FindGameObjectsWithTag("MainCube").Length == 5)
        {
            successScreen.SetActive(true);
            pause = true;
        }
    }

}
