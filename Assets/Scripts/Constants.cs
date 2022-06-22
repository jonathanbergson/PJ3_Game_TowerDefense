using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public struct Tags
    {
        public const string Shoot = "Shoot";
        public const string Zombie = "Zombie";
        public const string LevelSpawn = "LevelSpawn";
        public const string LevelTarget = "LevelTarget";
    }

    public enum Scenes
    {
        Main,
        Level01,
        Level02,
        Level03
    }

    public enum Levels
    {
        Level01,
        Level02,
        Level03
    }

    public enum Dificulties
    {
        Easy,
        Medium,
        Hard
    }

    public struct LevelSettings
    {
        public string Name;
        public int MaxHealth;
        public Vector3 SpawnPosition;
        public Vector3 TargetPosition;
        public List<Wave> WaveEasy;
    }

    public static LevelSettings Level01Settings = new LevelSettings
    {
        Name = "Level 01",
        MaxHealth = 10,
        SpawnPosition = new Vector3(-18,1,-26),
        TargetPosition = new Vector3(-40,1,10),
        WaveEasy = new List<Wave>
        {
            new Wave { ZombieCount = 2, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 2, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 8f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 8f },
        }
    };

    public static LevelSettings Level02Settings = new LevelSettings
    {
        Name = "Level 02",
        MaxHealth = 10,
        SpawnPosition = new Vector3(-22,1,24),
        TargetPosition = new Vector3(-10,1,-24),
        WaveEasy = new List<Wave>
        {
            new Wave { ZombieCount = 3, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 8f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 8f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 2f },
        }
    };

    public static LevelSettings Level03Settings = new LevelSettings
    {
        Name = "Level 03",
        MaxHealth = 10,
        SpawnPosition = new Vector3(-42,1,8),
        TargetPosition = new Vector3(-10,1,-17),
        WaveEasy = new List<Wave>
        {
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 4f },

            new Wave { ZombieCount = 4, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 4f },

            new Wave { ZombieCount = 8, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 8, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 2f },

            new Wave { ZombieCount = 12, DelayTimeToSpawn = 8f },
            new Wave { ZombieCount = 8, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 12, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 8, DelayTimeToSpawn = 4f },

            new Wave { ZombieCount = 16, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 16, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 16, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 16, DelayTimeToSpawn = 4f },

            new Wave { ZombieCount = 20, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 20, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 20, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 20, DelayTimeToSpawn = 4f },
        }
    };

    public class Wave
    {
        public int ZombieCount { get; set; }
        public float DelayTimeToSpawn { get; set; }
    }
}
