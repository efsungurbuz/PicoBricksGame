using UnityEngine;

public class PlayerPositionConstraint : MonoBehaviour
{
    public Transform[] kus1Objects;
    public Transform[] kus2Objects;
    public Transform[] kus3Objects;
    public Transform[] kus4Objects;
    public Transform[] kus5Objects;
    public Transform[] kus6Objects;

    private float minX;
    private float maxX;

    private void Start()
    {
        // Başlangıçta geçerli minX ve maxX değerlerini ayarlayın
        minX = transform.position.x;
        maxX = transform.position.x;

        // Oyuncunun başlangıç pozisyonunu -12.5 olarak ayarlayın
        transform.position = new Vector3(-12.5f, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        // minX ve maxX değerlerini güncelleyin
        UpdateMinMaxPositions(kus1Objects);
        UpdateMinMaxPositions(kus2Objects);
        UpdateMinMaxPositions(kus3Objects);
        UpdateMinMaxPositions(kus4Objects);
        UpdateMinMaxPositions(kus5Objects);
        UpdateMinMaxPositions(kus6Objects);

        // Eğer Kus1, Kus2 ve Kus3 objeleri sahneden yok olmuşsa minX değerini 258.7'ye güncelleyin
        if (AreObjectsDestroyed(kus1Objects) && AreObjectsDestroyed(kus2Objects) && AreObjectsDestroyed(kus3Objects))
        {
            minX = 258.7f;
        }

        // Eğer Kus4, Kus5 ve Kus6 objeleri sahneden yok olmuşsa maxX değerini 516'ya güncelleyin
        if (AreObjectsDestroyed(kus4Objects) && AreObjectsDestroyed(kus5Objects) && AreObjectsDestroyed(kus6Objects))
        {
            maxX = 516f;
        }

        // Oyuncunun pozisyonunu sınırlayın
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, -1f, 1f); // İleri yönde hareketi sınırla
        transform.position = clampedPosition;
    }

    private void UpdateMinMaxPositions(Transform[] objects)
    {
        foreach (Transform obj in objects)
        {
            if (obj != null)
            {
                minX = Mathf.Min(minX, obj.position.x);
                maxX = Mathf.Max(maxX, obj.position.x);
            }
        }
    }

    private bool AreObjectsDestroyed(Transform[] objects)
    {
        foreach (Transform obj in objects)
        {
            if (obj != null)
            {
                return false;
            }
        }
        return true;
    }
}
