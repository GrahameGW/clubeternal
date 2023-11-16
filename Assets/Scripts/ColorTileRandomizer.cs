using UnityEngine;
using System.Collections.Generic;

namespace ClubEternal
{
    public class ColorTileRandomizer : MonoBehaviour
    {
        [Min(0f)]
        [SerializeField] float changeIntervalSec;
        [SerializeField] List<Color> tileColors;
        [SerializeField] List<SpriteRenderer> tiles;

        private float nextColorChange = 0f;

        private void Update()
        {
            if (Time.time >= nextColorChange)
            {
                RandomizeColors();
                nextColorChange = Time.time + changeIntervalSec;
            }
        }

        private void RandomizeColors()
        {
            foreach (var tile in tiles)
            {
                var index = Random.Range(0, tileColors.Count);
                tile.color = tileColors[index];
            }
        }
    }
}
