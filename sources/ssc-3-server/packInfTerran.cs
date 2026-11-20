//Inf. Terran boom
$InvList[InfTerranPack] = 1;
$RemoteInvList[InfTerranPack] = 1;
$VehicleInvList[InfTerranPack] = 1;

ItemImageData InfTerranPackImage 
{
  shapeFile = "plasma";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  firstPerson = false;
};

ItemData InfTerranPack 
{
  description = "Infestation Juices";
  shapeFile = "plasma";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = InfTerranPackImage;
  price = 200;
  hudIcon = "plasma";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function InfTerranPack::onUse(%player,%item) 
{
//  echo(%item@" "@Player::getMountedItem(%player,$BackpackSlot));
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else
  {
    Player::SetItemCount(%player,InfTerranPack,0);
    %client=Player::GetClient(%player);
    Projectile::SpawnProjectile(InfTerranBoom, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
//    echo(%player@" fired at "@%player.launchat);
  }
}

function InfTerranPack::onDrop(%player,%item) 
{
//  echo("ImRec::OnDrop("@%player@","@%item@")");
  if($matchStarted) 
  {
    Item::onDrop(%player,%item);
            //Projectile::SpawnProjectile(InfTerranBoom, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);
            Projectile::SpawnProjectile(InfTerranBoom, GameBase::GetMuzzleTransform(%player), %this, 0, %client.LaunchAt);
	    deleteObject(%item);
  }
}

function InfTerranPack::onMount(%player,%item) 
{
  //%client = Player::getClient(%player);
  //Bottomprint(%client, "The photon torpedo will only seek an object that is marked with the Target Marking Laser.");
}
