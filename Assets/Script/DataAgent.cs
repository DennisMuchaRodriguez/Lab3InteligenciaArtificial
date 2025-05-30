using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
public class Data
{
    [Range(0f, 1f)]  
    public float value;
    public float valueMax=1;
    public float time;
    public float timeRate;
    public float timeFrameRate =0;
    public Data() { 
    
    
    }
}
public class DataAgent : MonoBehaviour
{
    public Data Energy = new Data();
    public Data Sleep = new Data();
    public Data WC = new Data();
    Coroutine CoroutineEnergy=null;
    Coroutine CoroutineSleep=null;
    public bool CantLoadEnergy { get => CoroutineEnergy == null; }
    public bool CantLoadSleep { get => CoroutineSleep == null; }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator LoadEnergyTime(float time)
    {

        while(time>0)
        {
            time--;
            Energy.value = Mathf.Lerp(Energy.value, Energy.valueMax, Time.deltaTime * 20f);
            yield return new WaitForSecondsRealtime(1);
        }
        Energy.value = Energy.valueMax;
        StopCoroutine(CoroutineEnergy);
        CoroutineEnergy = null;

    }
    public void LoadEnergy()
    {
        if(CoroutineEnergy==null)
            CoroutineEnergy = StartCoroutine(LoadEnergyTime(Energy.time));
    }

    public void DiscountEnergy()
    {
        if(Energy.timeFrameRate > Energy.timeRate)
        {
            Energy.timeFrameRate = 0;
            Energy.value-=0.03f;
        }
        Energy.timeFrameRate += Time.deltaTime;
    }
    IEnumerator LoadSleepTime(float time)
    {

        while (time > 0)
        {
            time--;
            Sleep.value = Mathf.Lerp(Sleep.value, Sleep.valueMax, Time.deltaTime * 20f);
            yield return new WaitForSecondsRealtime(1);
        }
        Sleep.value = Sleep.valueMax;
        StopCoroutine(CoroutineSleep);
        CoroutineSleep = null;

    }
    public void LoadSleep()
    {
        if (CoroutineSleep == null)
            CoroutineSleep = StartCoroutine(LoadSleepTime(Sleep.time));
    }
    public void DiscountSleep()
    {
        if (Sleep.timeFrameRate > Sleep.timeRate)
        {
            Sleep.timeFrameRate = 0;
            Sleep.value -= 0.04f;
        }
        Sleep.timeFrameRate += Time.deltaTime;
    }
}
