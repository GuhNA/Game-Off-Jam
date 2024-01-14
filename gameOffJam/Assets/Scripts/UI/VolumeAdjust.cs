using UnityEngine;

public class VolumeAdjust : MonoBehaviour
{
    public AudioSource music;



    public void VolumeAdj(float value)
    {
        music.volume = value;
    }

}
