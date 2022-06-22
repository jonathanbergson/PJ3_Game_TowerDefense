using System;
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
        public string name;
        public int maxHealth;
        public Vector3 spawnPosition;
        public Vector3 targetPosition;
        public List<Wave> waveEasy;
    }

    public static LevelSettings Level01Settings = new LevelSettings
    {
        name = "Level 01",
        maxHealth = 100,
        spawnPosition = new Vector3(-18,1,-26),
        targetPosition = new Vector3(-40,1,10),
        waveEasy = new List<Wave>
        {
            new Wave { ZombieCount = 2, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 2, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 3, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 6f },
        }
    };

    public static LevelSettings Level02Settings = new LevelSettings
    {
        name = "Level 02",
        maxHealth = 14,
        spawnPosition = new Vector3(-22,1,24),
        targetPosition = new Vector3(-10,1,-24),
        waveEasy = new List<Wave>
        {
            new Wave { ZombieCount = 3, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 2f },
        }
    };

    public static LevelSettings Level03Settings = new LevelSettings
    {
        name = "Level 03",
        maxHealth = 12,
        spawnPosition = new Vector3(-10, 1, -4),
        targetPosition = new Vector3(0, 0, 0),
        waveEasy = new List<Wave>
        {
            new Wave { ZombieCount = 3, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 4f },
            new Wave { ZombieCount = 4, DelayTimeToSpawn = 2f },
            new Wave { ZombieCount = 6, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 8, DelayTimeToSpawn = 6f },
            new Wave { ZombieCount = 8, DelayTimeToSpawn = 4f },
        }
    };

    public class Wave
    {
        public int ZombieCount { get; set; }
        public float DelayTimeToSpawn { get; set; }
    }
}
