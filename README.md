<div align="center">
  
  <h1>🧙‍♂️ Dungeon Wizard<br><sub><sup>Top‑Down 2D Dungeon Crawler</sup></sub></h1>
  
  <p>
    <strong>Second Unity project</strong> – a compact two‑level wizard crawler exploring: responsive 2D movement, mouse‑aim shooting, timed enemy spawning, scene progression, animation‑driven death flow, and a simple upgrade loop.
  </p>
  
  <p>
    <img alt="Engine" src="https://img.shields.io/badge/Unity-2021.3.16f1-black?logo=unity&logoColor=white" />
    <img alt="Genre" src="https://img.shields.io/badge/Genre-Top%20Down%20Action-purple" />
    <img alt="Status" src="https://img.shields.io/badge/Scope-Learning%20Prototype-blue" />
    <img alt="Language" src="https://img.shields.io/badge/C%23-Scripts-green" />
  </p>
  
  <p>
    <em>Built to practice foundational gameplay loops rather than full content scope.</em>
  </p>
  <hr/>
</div>

### 📑 Table of Contents
1. Overview  
2. Screenshots  
3. Core Features  
4. Controls  
5. Technical Implementation Highlights  
6. What I Learned  
7. Project Structure  
8. How to Run  
9. Possible Future Improvements  
10. Credits / Assets

---

## 1. 🧭 Overview
You play as a roaming wizard exploring small dungeon rooms. Enemies spawn in waves until a quota for that room is depleted; clearing a room transitions you to the next scene. You can fire magical projectiles ("fireballs") toward the mouse cursor. A collectible grants a multi‑shot upgrade (two quick successive shots) to reinforce progression and feedback. The project emphasizes foundational Unity 2D concepts rather than content scope.

### Core Pillars
| Pillar | Summary |
|--------|---------|
| Input Loop | WASD + cursor aim driving player & hand rotation |
| Enemy Pressure | Timer-based random dual‑point spawns reduce remaining quota per room |
| Feedback | Death animations & scene transitions reinforce progress/failure |
| Progression | Sequential scenes model linear dungeon advancement |

---

## 2. 🖼️ Screenshots
All raw images included in the repository (inside `Top Down Game Submission Photos/`).

<p align="center">
  <img src="Top%20Down%20Game%20Submission%20Photos/image.png" alt="Screenshot 1" width="45%"/>
  <img src="Top%20Down%20Game%20Submission%20Photos/image2.png" alt="Screenshot 2" width="45%"/>
</p>
<p align="center">
  <img src="Top%20Down%20Game%20Submission%20Photos/image%203.png" alt="Screenshot 3" width="45%"/>
  <img src="Top%20Down%20Game%20Submission%20Photos/image4.png" alt="Screenshot 4" width="45%"/>
</p>
<p align="center">
  <img src="Top%20Down%20Game%20Submission%20Photos/22.png" alt="Screenshot 5" width="60%"/>
</p>

> (If publishing to GitHub Pages or an external README viewer, verify paths & URL encoding for spaces.)

---

## 3. ⚔️ Core Features
| Feature | Description | Script |
|---------|-------------|--------|
| Movement | 8‑directional Rigidbody2D velocity driving smooth traversal | `topdownplayer.cs` |
| Aiming & Rotation | Hand object rotates toward mouse via screen‑space delta | `handrotate.cs` |
| Fireballs | Single shot by default; upgraded coroutine multi‑shot | `handrotate.cs` / `bullet.cs` |
| Enemy AI | Distance‑gated chase using MoveTowards | `EnemyChase.cs` |
| Spawn System | Random timer (2–6s) dual spawn; per‑room counters | `GameManager.cs` |
| Room Progression | Scene advancement when quota hits zero | `GameManager.cs` |
| Death Handling | Animation events trigger destruction & scene transition | Player & Enemy scripts |
| Camera Follow | Smoothed positional lerp + boundary clamp | `camerafollow.cs` |
| Power‑Up | Pickup toggles multi‑shot capability | `handrotate.cs` |
| UI Flow | Menu → Controls → Game → Win/Lose | `buttonmanager.cs` |

---

## 4. 🎮 Controls
| Action | Input |
|--------|-------|
| Move   | WASD / Arrow Keys (Input axes `Horizontal` / `Vertical`) |
| Aim    | Mouse cursor (rotates hand / firePoint) |
| Fire   | Left Mouse Button (single or multi‑shot) |
| Quit / Restart | (Handled via scene buttons; no explicit key shortcut implemented) |

---

## 5. 🛠️ Technical Implementation Highlights
### Player Movement & Animation
`topdownplayer.cs` handles axis polling, animator parameter updates, walking state toggling, and horizontal sprite flipping via scale inversion.

### Hand / Weapon Rotation & Shooting
`handrotate.cs` calculates mouse delta each frame via `Camera.main.WorldToScreenPoint` and `Mathf.Atan2` → Euler Z rotation. Shooting supports upgrade path: a single shot by default, a coroutine–based timed double shot after collecting the power‑up.

### Projectile Motion
`bullet.cs` applies constant velocity in `Update()` along its local right vector; relies on Rigidbody2D. Destroyed on any collision (impact VFX stubbed for later – commented out instantiation).

### Enemy AI & Death
`EnemyChase.cs` finds the Player by tag (robust fallback). Movement uses `Vector2.MoveTowards` while within an engagement distance threshold. On collision, collider is disabled (prevents duplicate hits) and a death animation plays before destruction via animation event.

### Enemy Spawning & Room Progression
`GameManager.cs` manages three counters (room1enemy / room2enemy / room3enemy). A timer governs spawn cadence (randomly reset 2–6 seconds) and spawns two enemies at slightly offset vertical positions. When a room’s count reaches zero, the next scene loads (hard‑coded scene indices / names). Demonstrates scene management & state gating.

### Camera System
`camerafollow.cs` lerps camera position toward player each FixedUpdate, then clamps within defined rectangular bounds for framing consistency.

### UI / Menu Flow
`buttonmanager.cs` exposes public methods for Unity UI Buttons to call `SceneManager.LoadScene(...)` for Start, Controls, and Back navigation.

### Animation Events
Both player (`topdownplayer`) and enemy (`EnemyChase`) implement `OnAnimationEnd()` method callbacks tied to the end of death animations to manage cleanup & scene change smoothly.

---

## 6. 📚 What I Learned (Skill Highlights)
This project helped solidify several Unity fundamentals:
1. Scene Management – loading sequential rooms & menus with `SceneManager`.
2. Animator Workflows – parameter setting (float/bool), triggering death animations, and using animation events as lifecycle hooks.
3. 2D Physics & Movement – Rigidbody2D velocity control in FixedUpdate vs input sampling in Update, plus simple camera smoothing + bounds.
4. Player Feedback Loops – upgrade (multi‑shot) and death handling to reinforce progression & challenge.
5. AI Basics – pursuit behavior using distance checks and normalization.
6. Spawning Systems – timed + randomized spawn points with per‑room quotas controlling pacing.
7. Code Organization – separating concerns across small single‑purpose scripts (input, shooting, camera, AI, spawning, UI buttons).
8. Coroutines – sequencing actions over time for multi‑shot firing cadence.
9. Transform Math – converting world space to screen space for rotational aiming toward the mouse.
10. Iterative Debugging – using tags (`Player`, `Enemy`, `speedboost`) and logging collisions for verifying interactions.

---

## 7. 🗂️ Project Structure (Key Folders)
```
Assets/
  Scripts/           Core gameplay logic (player, enemy, shots, camera, managers)
  Animation/         Death animations (enemy & player) and other clips
  Sprites/           2D art & tiles (not enumerated here)
  Prefabs/           Likely contains enemy, bullet, player, power‑up
  Scenes/            Room1, Room2, Room3, Menu, Controls, Win/Lose scenes
Top Down Game Submission Photos/  Screenshots used in README
ProjectSettings/     Unity project configuration & version (2021.3.16f1)
Packages/            Package manifest & lock for reproducible environment
```

---

## 8. 🚀 How to Run
1. Open with Unity Editor version **2021.3.16f1** (LTS series recommended). Opening in a newer LTS should work but verify animation & physics settings.
2. Open the main menu scene (likely index 1 based on script usage) or directly open `Room1` to begin.
3. Enter Play Mode.
4. Move with WASD, aim with mouse, left‑click to shoot. Collect the upgrade pickup to enable the double‑shot.

To build:
- Go to File → Build Settings → Ensure all scenes (Menu, Controls, Room1, Room2, Room3, Win/Lose) are added in the correct order → Build.

---

## 9. 🔮 Possible Future Improvements
- Health system (currently instant death on collision) with UI hearts or bar.
- Enemy variety (ranged, slower tank, fast chaser) & spawn weighting curves.
- Wave UI feedback (remaining enemies, room clear banner).
- Audio design: casting SFX, enemy death, ambient dungeon loop.
- Particle effects for fireball impact (re‑enable & implement `impactEffect`).
- Object pooling for bullets/enemies to reduce instantiation overhead.
- Data‑driven spawn configuration (ScriptableObjects) instead of hard‑coded counters.
- Minimap or fog of war for exploration feel.
- Difficulty scaling (spawn rate, enemy speed) per room.
- Gamepad twin‑stick aiming (right stick) support.

---

## 10. 🙌 Credits / Assets
- Code & gameplay design: (Your Name Here – update this line!)
- Unity 2021.3.16f1 LTS.
- Any third‑party sprite, font, or SFX assets used (add attributions if applicable).

If you plan to open-source this: add a license (e.g., MIT) and clarify which assets are excluded from redistribution if any.

---

### 🧵 Reflection
As a second Unity project, the focus was intentionally on mastering the loop of: input → motion/aim → spawn → engage → die/transition, rather than expanding feature scope. The result is a compact sandbox demonstrating reliable integration of core 2D systems and a foundation for more advanced roguelite or action RPG mechanics.

---

Feel free to open an issue or reach out with suggestions for next steps or refactors.
