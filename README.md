# MC_SVSkillPointPerLevel  
  
Backup your save before using any mods.  
  
Uninstall any mods and attempt to replicate issues before reporting any suspected base game bugs on official channels.  
  
A quick and dirty mod.  If you set a decimal "skill points per level" value, you should note the following.  If you use only whole numbers, it will be fine.    
1. Mod will let you set a new skill points per level.  
2. If that value is not a whole number, the remainder is saved e.g. if you set 1.5 per level it will give you 1 the first time you level up, next level it will give you 2 (1.5 + 0.5 remaining from last level).  
3. That remainder storage will only work properly for one save at a time the way it's currently setup (i.e. the dirty way I'm saving the data).  The remainder will also carry from one save to another.  
  
Install  
=======  
1. Install BepInEx - https://docs.bepinex.dev/articles/user_guide/installation/index.html Stable version 5.4.21 x86.  
2. Run the game at least once to initialise BepInEx and quit.  
3. Download latest mod release.  
4. Place MC_SVSkillPointsPerLevel.dll in .\SteamLibrary\steamapps\common\Star Valor\BepInEx\plugins\  
  
Configuration  
=============  
Default modded skill points per level is 2.  
  
After you run the game with the mod installed, a new file will be created:  
.\SteamLibrary\steamapps\common\Star Valor\BepInEx\config\mc.starvalor.skillpointperlevel.cfg  
  
Change points per level to whatever you want.  
  
[1. Settings]
  
Skill points per level (can be decimal).  
Setting type: Single  
Default value: 2  
Points per level = 2.0  
