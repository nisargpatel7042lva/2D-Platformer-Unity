# Level Creation Guide - 2D Platformer

## Overview
I've created a **LevelManager** system that automatically detects and manages 3 levels based on scene build index:
- Scene 1: Level 1 (Easy)
- Scene 2: Level 2 (Medium)
- Scene 3: Level 3 (Hard)

## Steps to Create Level 2 & Level 3

### Step 1: Duplicate the Level Scene
1. In Unity Editor, right-click on `Assets/Scenes/Level.unity`
2. Select "Duplicate" 
3. Rename to `Level2.unity`
4. Repeat and create `Level3.unity`

### Step 2: Add Scenes to Build Settings
1. Go to **File > Build Settings**
2. Verify the order is:
   - Scene 0: Menu
   - Scene 1: Level
   - Scene 2: Level2
   - Scene 3: Level3

### Step 3: Adjust Level 2 (Medium Difficulty)

**Make these changes in Level2.unity in the Unity Editor:**

#### Platform Design:
- Add 2-3 additional platforms with small gaps
- Create a section with narrower platforms (half the original width)
- Add one area requiring precise timing to jump

#### Obstacles:
- Place 2-3 SnowMan enemies:
  - One at first gap section
  - One in middle area
  - One near the exit
- Add more IceBox obstacles in a cluster

#### Collectibles:
- Increase coin count by 30% more scattered across level
- Place 2 gems in harder-to-reach areas
- Distribute health pickups strategically

#### Layout Tips:
- Keep the exit trigger but make it slightly higher
- Add background objects (trees) for visual depth
- Use tileset variations #5-10 for different look

### Step 4: Adjust Level 3 (Hard Difficulty)

**Make these changes in Level3.unity in the Unity Editor:**

#### Platform Design:
- **Very narrow platforms** (1/3 original width) in sections
- Create **vertical climbing sections** with platforms above/below
- Add platforms that require **double-jumping** to reach
- Include a **spike gauntlet** pattern - narrow gaps with ice blocks

#### Obstacles:
- Place 5-6 SnowMan enemies strategically:
  - Scattered throughout main platforms
  - Concentrated in mid-level section
- Add **clusters of IceBox obstacles** that force specific paths
- Add more variety with environmental hazards

#### Enemy Movement:
- Consider adding patrol patterns if you code it
- Place enemies at platform junctions

#### Collectibles:
- Increase coins by 50% more (smaller/harder to spot)
- Place 3-4 gems in very challenging spots
- Minimal health pickups - only 1-2

#### Visual Design:
- Use different tileset variations (#12-18) for dramatic look
- Add DecorativeObjects for visual interest
- Make layout feel more "intense"

#### Challenge Progression:
1. Easy start with platform section (warm up)
2. Medium - introduce more enemies + narrow platforms
3. Hard - multiple jumps + precision sections
4. Very Hard - combined challenges at end
5. Exit is highest point (reward for beating level)

### Step 5: Update UI Panels

For the Level Complete panel, you may want to add bonus stars/ratings:
- ⭐⭐⭐ All coins collected
- ⭐⭐ Most coins collected  
- ⭐ Level completed

Update `ExitTrigger.cs` if you want to show this.

### Step 6: Test & Balance

1. Play each level in Editor
2. Time how long each takes (easy: ~1 min, medium: ~1.5 min, hard: ~2-3 min)
3. Adjust difficulty as needed:
   - Too hard? Move platforms closer, add more health
   - Too easy? Reduce coins, add more enemies

## Script Integration

The new scripts automatically handle:
- **LevelManager**: Tracks current level and difficulty
- **LevelDifficultyAdjuster**: Can toggle difficulty-specific GameObjects
- **Events.cs**: Updated with Level1(), Level2(), Level3(), NextLevel()

### Using LevelDifficultyAdjuster in Your Scenes

For obstacles that should only appear in certain difficulties:
1. Create empty GameObjects for difficulty groups:
   - "MediumObstacles" (appears in Level 2+)
   - "HardObstacles" (appears in Level 3 only)
2. Add LevelDifficultyAdjuster component to a manager GameObject
3. Drag obstacle groups into the inspector arrays
4. The script automatically enables/disables based on level

## Level Design Recommendations

| Aspect | Level 1 | Level 2 | Level 3 |
|--------|---------|---------|---------|
| Platform Count | 8-10 | 12-15 | 15-20 |
| Enemy Count | 1-2 | 3-4 | 5-6 |
| Platform Width | Normal | Normal/Narrow | Very Narrow |
| Coin Count | 15-20 | 25-30 | 35-40 |
| Gem Count | 1-2 | 2-3 | 3-4 |
| Est. Clear Time | ~1 min | ~1.5 min | ~2-3 min |

## Navigation Flow

```
Menu → Level 1 (Easy)
        ↓
     Level 2 (Medium) - [Next Level] button in complete panel
        ↓
     Level 3 (Hard) - [Next Level] button in complete panel
        ↓
     Menu (Game Complete)
```

## Notes

- Keep **player spawn point** roughly at same location for consistency
- Maintain **visual theme** but increase visual complexity for hard levels
- Test on **target platform** (PC with keyboard, or mobile with touch)
- Consider **checkpoint respawn** locations if adding moving platforms

For any scripted difficulty adjustments later, use:
```csharp
if (LevelManager.instance.IsHardMode())
{
    // Apply hard mode changes
}
```
