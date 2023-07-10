using UnityEngine;

namespace _Scripts.SO
{
    [CreateAssetMenu(menuName = "SO/Color Materials Config", fileName = "ColorMaterialsConfig", order = 0)]
    public class ColorMaterialsConfig : ScriptableObject
    {
        [SerializeField] private Material[] _materials;

        public Material[] Materials => _materials;
    }
}