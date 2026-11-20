$InvList[JailGun] = 1;
$MobileInvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;

$AutoUse[JailGun] = false;
$WeaponAmmo[JailGun] = "";

addWeapon(JailGun);

LightningData JailBolt
{	bitmapName = "lightningNew.bmp";
	damageType = $JailDamageType;
	boltLength = 10.0;
	coneAngle = 1.0;
	damagePerSec = 0.01;
	energyDrainPerSec = 60.0;
	segmentDivisions = 1;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};




//plasmatic
//from april fool version.. .
function jailbolt::damageTarget(%targetPl, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterPl)
{

	%shooterTeam = GameBase::getTeam(%shooterPl);
	%targetTeam = GameBase::getTeam(%targetPl);
	
	%shooterClient = Player::getClient(%shooterPl);
	%targetClient = Player::getClient(%targetPl);
	if(%targetPL.invulnerable == true || $jailed[%targetPL] == true) {
		//Client::sendMessage(%shooterClient,0,"Quit that.~wError_Message.wav");
		return;
		}		
	if(getObjectType(%targetPl) != "Player")
		return;
	if(%shooterTeam == %targetTeam)
		return;

	if($JailPosition[%shooterTeam] != "0 0 0")
	{
		%shooterName = Client::getName(%shooterClient);
		%targetname = Client::getName(%targetClient);
		// ann 2.2 20% chance of malfunctioning -plasmatic
		if(floor(getrandom() * 100) < 80)
		{
			ToJail(%targetClient, %shooterTeam);	//plasmatic
			
			bottomprint(%targetClient,"Your Punk Ass Has Been Placed Under Arrest By " @ Client::getName(%shooterClient) @ ", Your sentence will last for 30 seconds", 30);
			Messageall(0,Client::getName(%targetClient)@" Was judged GUILTY by "@Client::getName(%shooterClient));
	//		echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
		}
		else
		{
			ToJail(%shooterClient, %shooterTeam);	//plasmatic
			
			bottomprint(%targetClient,"Your Punk Ass Has Been Placed Under Arrest By your malfunctioning gun..", 30);
			Messageall(0,Client::getName(%shooterClient)@"'s jail gun malfunctioned...");
	//		echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
		}		
		return true;
	}
	else
	{
		Client::sendMessage(%shooterClient,0,"No Jail Tower Deployed~wError_Message.wav");
		return false;
	}
}

ItemImageData JailGunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 2;
	projectileType = jailbolt;
	minEnergy = 5;
	maxEnergy = 80;
	reloadTime = 2.0;
	fireTime = 1.5;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};

ItemData JailGun
{
	heading = $InvHead[ihWea];
	description = "Jailers Gun";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "energyrifle";
	hadowDetailMask = 4;
	imageType = JailGunImage;
	price = 385;
	showWeaponBar = true;
};

function Jailgun::MountExtras(%player,%weapon)
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>You are the judge and jury with this little device.  Requires a Jail to be deployed.");
}
