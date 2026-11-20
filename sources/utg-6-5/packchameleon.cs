//------------------------------------|
// Author: {-o-}Plasmatic
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin8420@adelphia.net
// Aim: Dustin8420
//------------------------------------|
ItemImageData ChameleonPackImage 
{
	shapeFile  = "ammoPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy  = 0.1;
	maxEnergy  = 12;
	sfxFire    = SoundShieldOn;
	firstPerson = false;
};

ItemData ChameleonPack 
{
	description = "God Pack_v1.996";
	shapeFile   = "ammoPack";
	className   = "Backpack";
	shadowDetailMask = 4;
	imageType        = ChameleonPackImage;
	price            = 175;
	hudIcon          = "shieldpack";
	showWeaponBar    = true;
	hiliteOnActive   = true;
	validateShape    = false;
};

function ChameleonPackImage::onActivate(%player, %imageSlot) 
{
	%c = Player::getClient(%player);
	%p = Client::getOwnedObject(%c);
	%name = Client::getName(%c);
	
	%p.shieldStremgth = 250;
	Player::setSensorSupression(%p, 10);
	GameBase::startFadeOut(%p);
    
	if(getNumTeams() > 2 || $UnCvrA || $UnCvrB) 
	{
		if(getNumTeams() > 2) 
		{
			Client::sendMessage(%clientId, 0, "Can't go use your powers with more then 2 teams~waccess_denied.wav");
			Player::decItemCount(%clientId, Player::getMountedItem(%clientId, $BackpackSlot));
			return;
		}
	}
	
	%p.cloakable = "";
	if(Client::getTeam(%c) == 0) 
	{
		$UnCvrA = %c;
		%c.OrigTeam = 5;
		teamMessages(1, 0, %name @" Asks for help from the gods", -2, "", "");
		Client::setinitialTeam(%c, 1);
		GameBase::setTeam(%c, 1);
		Client::setinitialTeam(%c, 0);
	}
	else
	{
		$UnCvrB = %c;
		%c.OrigTeam = 6;
		teamMessages(1, 1, %name @" Asks for help from the gods", -2, "", "");
		Client::setinitialTeam(%c, 0);
		GameBase::setTeam(%c, 0);
		Client::setinitialTeam(%c, 1);
	}
}

function ChameleonPackImage::onDeactivate(%player,%imageSlot) 
{	
	%c = Player::getClient(%player);
	%p = Client::getOwnedObject(%cl);
    %p.shieldStrength = 0;
    Player::setSensorSupression(%p, 0);
    GameBase::startFadein(%p);
    
	if(%c.OrigTeam != 5 && %c.OrigTeam != 6) 
	{ return; }
	if(%c.OrigTeam == 5) 
	{ $UnCvrA = ""; GameBase::setTeam(%c, 0); }
	else if(%c.OrigTeam == 6)
	{ $UnCvrB = ""; GameBase::setTeam(%c, 1); }
	%p.cloakable = true;
	%c.OrigTeam = "";
	Client::sendMessage(%c, 0, "God's help has run out");
}