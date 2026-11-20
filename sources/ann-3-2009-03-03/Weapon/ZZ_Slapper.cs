
// Slapper. April 2004 by Plasmatic

// $build must be set = true in annihilation.cs
// for this to load. 

if($build)
{
	$InvList[Slapper] = 1;
	$MobileInvList[Slapper] = 1;
	$RemoteInvList[Slapper] = 1;
	
				
	//	$ItemMax[armormBuilder, Slapper] = 1;
	//	$ItemMax[armorfBuilder, Slapper] = 1;
	
	$AutoUse[Slapper] = false;
	
	
	// addWeapon(Slapper);
	
	ItemImageData SlapperImage 
	{
		shapeFile = "sniper";
		mountPoint = 0;
		weaponType = 0;	//0 single, 1 rotating, 2 sustained, 3disc
	//	ammoType = SlapperShells;
		reloadTime = 0.05;
		accuFire = false;
		fireTime = 0.05;
	//	sfxFire = SoundFireGrenade;	//sfxFire = SoundFireShotgun;
		sfxActivate = SoundPickUpWeapon;
	};
	
	ItemData Slapper 
	{
		description = "Slapper";
		shapeFile = "sniper";
		hudIcon = "ammopack";
		className = "Tool";	//className = "Weapon"; 	//tools dont take weapon slots -Plas
		heading = $InvHead[ihtool];
		shadowDetailMask = 4;
		imageType = SlapperImage;
		showWeaponBar = true;
		price = 85;
	};
	
	function Slapper::MountExtras(%player,%weapon) 
	{	
		%client = Player::getclient(%player);
		%setting = %client.slapperSetting;
		if(!%setting)
			%client.slapperSetting = 0;
		%setting = %client.slapperSetting;
	//	if(%client.weaponHelp)
			Bottomprint(%client, "<jc>"@%weapon.description@": <f2>Set to deploy# "@%Setting@": <f1>"@String::getSubStr($Deployable[$Slapper::DeployableMax-%Setting], 7, 40)@".<f2> Press the One or Six keys to cycle.");
	
	}
	
	function SlapperImage::onFire(%player, %slot) 
	{	
		%client = Player::getclient(%player);	
		if($debug)
			echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
			
		if(!GameBase::getLOSInfo(%player,7)) 
		{
			//Client::sendMessage(%client,0,"Deploy position out of range");
			playSound(Soundpackuse,getboxcenter(%player));
			return false;
		}
	
		//lets deploy some stuff -Plasmatic
	
		Player::trigger(%player, $WeaponSlot, false);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);	
		%newobj = Projectile::spawnProjectile(LaserTrail,%trans,%player,%vel);	
			
		%setting = %client.slapperSetting;	
		%shape = $Deployable[$Slapper::DeployableMax-%Setting];
		%name = String::getSubStr(%shape, 7, 40);
		%rot = GameBase::getRotation(%player);
		%obj = newObject("","StaticShape",%shape,true);
	
		addToSet("MissionCleanup/deployed/Barrier", %obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%player));
		GameBase::setPosition(%obj,$los::position);
		GameBase::setRotation(%obj,%rot);
		Gamebase::setMapName(%obj,%name@" "@Client::getName(%client));
	//	Client::sendMessage(%client,0,%name@" Deployed");
		Bottomprint(%client, "<jc><f1>"@%name@" Deployed",3);
	
		GameBase::startFadeIn(%obj);
		playSound(SoundPickupBackpack,$los::position);
		playSound(ForceFieldOpen,$los::position);		
	}
	
	LaserData LaserTrail
	{
	   laserBitmapName   = "laserpulse.bmp";	//paintPulse.bmp";	//laserPulse.bmp";
	//   hitName           = "fusionex.dts";	//shockwave_large.dts";	//laserhit.dts";
	
	   damageConversion  = 0.0;
	   baseDamageType    = 0;
	
	   beamTime          = 0.75;
	
	//	   lightRange        = 2.0;
	//	   lightColor        = { 1.0, 0.25, 0.25 };
	//   lightRange        = 2.0;
	//   lightColor        = { 0.25, 1.0, 0.25 };
	
	   detachFromShooter = true;	//false; 
	//   hitSoundId        = SoundLaserHit;
	};
	
	function Slapper::Mode(%player,%rotate)
	{
		%rotate = -%rotate;
		%client = Player::getclient(%player);
		%setting = %client.slapperSetting;
		%setting += %rotate;
	//	if(!$Deployable[%Setting])
	//		%setting = 0;
		if(%setting < 0)
			%setting = $Slapper::DeployableMax;
		if(%setting > $Slapper::DeployableMax)
			%setting = 0;
		%client.slapperSetting = %setting;
	
		%weapon = Slapper;
		Bottomprint(%client, "<jc>"@%weapon.description@": <f2>Set to deploy# "@%setting@": <f1>"@String::getSubStr($Deployable[$Slapper::DeployableMax-%Setting], 7, 40)@".<f2> Press the One or Six keys to cycle.");
		
	}
	
	
	// Let's tear through entities and define everything as a static... -Plasmatic
	
		%consolemode = $Console::LogMode; 
		$Console::LogMode = "2"; 
		echo("!! Starting Slapper data block export !!");
		%file = File::FindFirst("*.dts");
		%count = 0;
		while(%file != "")
		{	
			%shape = File::getBase(%file);		
			%file = File::FindNext("*.dts");
			%nopass = false;
			%end = false;
			for(%i = 0; !%end ; %i++)
			{
				// rejects list -plasmatic //arrow50 arrow25 
				%word = getword("teleporter ammopad command pulse trail shield plant newdoor tree2 hover armor tumult steamvent plume exp ex mflame lflame laserhit hflame fusionbolt flash fiery enbolt chainspk sprk shockwave rsmoke plastrail plasmatrail plasmaex",%i);
				%find = String::findSubStr(%shape,%word);
				
				if(%find != -1)
					%nopass = true;
				if(%nopass || %word == -1 || %word = "")
					%end = true;
			}
			if(!%nopass)
			{
				echo("+ #"@%count@" Defining static: "@%shape);
				$Deployable[%count] = "Slapper"@%shape;
	
				//define this up -Plasmatic
				%description = "Slapper "@%shape;
				%Data = 	"StaticShapeData Slapper"@%shape@ 
					" { "@
						"shapeFile = \""@%shape@"\";"@
						"debrisId = defaultDebrisSmall;"@
						"maxDamage = 1;"@
						"visibleToSensor = false;"@
						"isTranslucent = true;"@
						"description = \""@%description@"\";"@
					"};"; 		
					
				eval(%Data);
				
				// calculating damage on retardedly redundant slappered stuff may overload server -Plasmatic
				%function = "function Slapper"@%shape@"::onDestroyed(%this) { }";
				eval(%function);
				
				%function = "function Slapper"@%shape@"::onDamage(%this,%type,%value)"@
					" { "@
						"%damageLevel = GameBase::getDamageLevel(%this);"@
						"%dValue = %damageLevel + %value;"@
						"GameBase::setDamageLevel(%this,%dValue);"@							
					"}";
				eval(%function);			
	
				%count++;			
			}	
			else
			{
				echo("- Skipping "@%shape);
			}
				
		}
		
		$Console::LogMode = %consolemode; 
		echo("Finishing Slapper datablock export. " @ %count @ " .dts files loaded");
		$Slapper::DeployableMax = %count-1;
}
