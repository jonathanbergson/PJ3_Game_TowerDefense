using System;
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
    }

    public static LevelSettings Level01Settings = new LevelSettings
    {
        name = "Level 01",
        maxHealth = 100,
        spawnPosition = new Vector3(-18,1,-26),
        targetPosition = new Vector3(-40,1,10),
    };

    public static LevelSettings Level02Settings = new LevelSettings
    {
        name = "Level 02",
        maxHealth = 12,
        spawnPosition = new Vector3(-10, 1, -4),
        targetPosition = new Vector3(-10,1,10),
    };

    public static LevelSettings Level03Settings = new LevelSettings
    {
        name = "Level 02",
        maxHealth = 12,
        spawnPosition = new Vector3(-10, 1, -4),
        targetPosition = new Vector3(0, 0, 0),
    };

    public static readonly Tuple<int, float>[] Level01WaveEasy =
    {
        Tuple.Create(3, 6f),
        Tuple.Create(5, 12f),
        Tuple.Create(20, 10f),
    };
}
