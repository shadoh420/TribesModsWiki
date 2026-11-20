///-----------------------------------------------
/// description = "JailGun";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

addPluginWeapon(Mortar, JailGun);
$AutoUse[Vulcan] = True;



ItemImageData JailGunImage
{
          shapeFile = "shotgun";
           mountPoint = 0;

           weaponType = 2;
           projectileType = jailbolt;


           minEnergy = 5;
           maxEnergy = 80;
           reloadTime = 4.0;

          lightType = 3;
          lightRadius = 2;
          lightTime = 1;
          lightColor = { 0.25, 0.25, 0.85 };

          sfxActivate = SoundPickUpWeapon;
          sfxFire     = SoundELFIdle;
};
ItemData JailGun
{
   heading = "bWeapons";
        description = "Jailers Gun";
        className = "Weapon";
        shapeFile  = "repairgun";
        hadowDetailMask = 4;
        imageType = JailGunImage;
        price = 385;
        showWeaponBar = true;
};