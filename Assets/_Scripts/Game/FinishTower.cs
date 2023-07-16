using _Scripts.SO;
using UnityEngine;

namespace _Scripts.Game
{
    public class FinishTower : MonoBehaviour
    {
        [SerializeField] private GameObject _brickPrefab;
        [SerializeField] private float _minYScale;
        [SerializeField] private float _maxYScale;
        [SerializeField] private ColorMaterialsConfig _colorsConfig;
        [SerializeField] private int _numberOfBricks;
    
        private void Start()
        {
            BuildTower();
        }
    
        private void BuildTower()
        {
            Vector3 spawnPosition = transform.position + Vector3.up * transform.localScale.y;
        
            for (int i = 0; i < _numberOfBricks; i++)
            {
                float yScale = Random.Range(_minYScale, _maxYScale);
                Material colorMaterial = _colorsConfig.Materials[Random.Range(0, _colorsConfig.Materials.Length)];
            
                GameObject brick = Instantiate(_brickPrefab, spawnPosition, Quaternion.identity);
                brick.transform.parent = gameObject.transform;
                var localScale = brick.transform.localScale;
                localScale = new Vector3(localScale.x, yScale, localScale.z);
                brick.transform.localScale = localScale;
                brick.GetComponent<Renderer>().material = colorMaterial;
            
                spawnPosition.y += yScale;
            }
        }
    }
}