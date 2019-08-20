using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    
    public void SpawnEnemy(Vector3 position)
    {
        Instantiate(_enemy, position, Quaternion.identity);
    }

}
