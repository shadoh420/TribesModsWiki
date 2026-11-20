//--------------------------------------------------------------------------
// Beacon Mods- used for weapon fire modes
//--------------------------------------------------------------------------
$ChangeWepTime = 3;


function changeWeaponMode8(%player,%clientId)
{
  %clientId = Player::getClient(%player);
  %client = Player::getClient(%player);
//--------------------------------------------------------------------------
// MD-1024
//--------------------------------------------------------------------------
      if (Player::getMountedItem(%player, $WeaponSlot) == Rifle)
      {
           if(%clientId.Rifle >= 2)
               %clientId.Rifle = -1;

          %clientId.Rifle += 1;

      if(%clientId.Rifle == 0)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MD-1024  -> [1/3]<f2> Standard\", 5);", 0);
      }
          //
      else if(%clientId.Rifle == 1)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MD-1024  -> [2/3]<f2> Explosive\", 5);", 0);
      }
      else if(%clientId.Rifle == 2)
      {
          Client::sendMessage(%clientId,0,"~wDryfire1.wav");
		  schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>MD-1024  -> [3/3]<f2> HP\", 5);", 0);
      }
      //else
      //    schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Error! (Weapon::InvalidMode) defaulting to Standard.\", 5);", 0);
//----END----------------------------------------------------------------------
//----END----------------------------------------------------------------------
//----END----------------------------------------------------------------------
      }
      //}
       //else
       //schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>Error! (Weapon::NoModes) No modes availiable to change.\", 5);", 0);
}

