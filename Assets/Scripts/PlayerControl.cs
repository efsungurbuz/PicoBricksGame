using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform hedefObjeninTransformu;

    private void OnMouseDown()
    {
        Işınlan();
    }

    private void Işınlan()
    {
        transform.position = hedefObjeninTransformu.position;
    }
}




