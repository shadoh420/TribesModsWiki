$InvList[SAMPack] = 0;
$InvList[HowitzerPack] = 0;
$InvList[TwentyPack] = 0;
$InvList[GrapplePack] = 0;
$InvList[PortGenPack] = 0;
$InvList[AAPack] = 0;
$InvList[DeployableInvPack] = 0;

$RemoteInvList[PortGenPack] = 0;
function Extraction::shootDown(%target)
{
	%trans1 = "-0.335332 -0.032761 0.941529 0.937285 0.089306 0.336928 -0.095122 0.995465 0.000759 -22.308963 -27.185667 38.750194";
	%trans2 = "-0.186365 0.028087 0.982078 0.970477 -0.150511 0.188468 0.153108 0.988209 0.000791 -40.741058 40.603511 38.552654";
	%trans3 = "-0.178016 0.061895 0.982078 0.926219 -0.326490 0.188467 0.332305 0.943171 0.000791 36.440643 110.597717 69.961135";
	%trans4 = "-0.157346 -0.050146 0.986269 0.941151 0.294893 0.165142 -0.299126 0.954213 0.000795 9.157129 -65.976676 50.302764";
	schedule("Extraction::shootDownNow(\""@%target@"\",\""@%trans1@"\");",getrandom()*4);
	schedule("Extraction::shootDownNow(\""@%target@"\",\""@%trans2@"\");",getrandom()*4);
	schedule("Extraction::shootDownNow(\""@%target@"\",\""@%trans3@"\");",getrandom()*4);
	schedule("Extraction::shootDownNow(\""@%target@"\",\""@%trans4@"\");",getrandom()*4);
}

function Extraction::shootDownNow(%target,%trans)
{
	%projectile = Projectile::spawnProjectile("Stinger2Missile", %trans, 2048, "0 0 0", %target);
	warningMessage(GameBase::getControlClient(%target), %projectile);
	%projectile.owner = 2048;

}
function Extraction::LoadSpecSquad(%ct)
{
	if(%ct == 0)
	{
	
	%name = "SpecSquad";
	%root = "ExtractionPoint";
	%rootgroup = NameToId("MissionGroup\\AIs");
	ExtractionPoint::SpecSquad();
	//eval("function "@%root@"::"@%name@"() {}");
	%delaygroup = nameToId("SpecNewDelay");
	addtoset(%rootgroup, %delaygroup);
	renameObject(%delaygroup, "SpecSquad");
	}
	else
	   %delaygroup = NameToId("MissionGroup\\AIs\\SpecSquad");
	if(%ct == 2)
	{
	eval("function ExtractionPoint::SpecSquad() {}");
	}
	%num = group::objectcount(%delaygroup);
	
	for(%x = 0; %x<%num;%x++)
	{
		
		%path = group::GetObject(%delaygroup,%x);
		%ainame = AAI::spawn(%path,-1);
		%ai = AI::GetObject(%ainame);
		%aiCL = AI::GetId(%ainame);
		%aiObj = Client::getOwnedObject(%aiCL);
		if(%x == 0)
		{
		%leader = %aiCL;
		AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);
		} else {
		AI::DirectiveFollow(%aiName, %leader, 0, 1024);
		AI::SetVar(%ainame, seekoff, "-2.5 "@2.5*(2*(%x - 1) - 1)@" 0");
		}
		$ExtractionNapalmGroup = $ExtractionNapalmGroup @ %aicl @ " ";

		%ainame.PatshsGroup = %path;
		
		//AAI::TestPatrolResume(%aiName,%ai,%aiCL,%aiObj);
		if(getrandom() < 0.33)
		{
			schedule("player::setitemcount("@%aiObj@",Stinger, 1);", 1);
			schedule("player::setitemcount("@%aiObj@", StingerClip, 2);", 1);
			schedule("Player::MountItem("@%aiObj@", Stinger, 0);", 1);
		}				
	}

	
}

function Extraction::RunNap()
{
	//exec("DF_Extraction AIFiles\\31 ExtractionPoint.cs");
	schedule("Extraction::Killthem();", 29);
	$ExtractionNapalmGroup = "";
	Extraction::LoadSpecSquad(0);
	schedule("Extraction::LoadSpecSquad(1);", 2);
	//schedule("Extraction::LoadSpecSquad(2);", 4);
	schedule("AirStrike::NapalmStrike2();", 2);
	

}

function Extraction::HurtMe(%this)
{
	//echo("Hurting "@%this);
	gamebase::setdamagelevel(%this, 5.5);
	SmokeEffects(%this);
	//vehicle::ondamage(%this,$ImpactDamageType, 6.0);

}

function Extraction::Killthem()
{
	while(getword($ExtractionNapalmGroup, %x) != -1)
	{
	%aicl = getword($ExtractionNapalmGroup, %x); 
	%x++;	
	%pos = gamebase::getposition(%aicl);
	if(%pos != "0 0 0")
	{
		echo("Hurting "@%aicl);
		gamebase::applydamage(%aicl, 22, 0.75, %pos, "0 0 0", "0 0 0", 2049);
	}
	
	}
}

function Extraction::GetAim(%this)
{
	
	%x = 0;
	%cumpos = "0 0 0";

	%count = 0;
	while(getword($ExtractionNapalmGroup, %x) != -1)
	{
	%aicl = getword($ExtractionNapalmGroup, %x); 
	%x++;	
	%pos = gamebase::getposition(%aicl);
	if(%pos != "0 0 0")
	{
	%count++;
	%cumpos = vector::add(%cumpos, %pos);
	}
	
	}

	%targetpos = vector::add(((getword(%cumpos, 0)/%count)@" "@(getword(%cumpos, 1)/%count)@" 0"), "40 5 20");
	
	%markgroup = nametoid("MissionCleanup/AirStrikePath"@%this);
	
	
	%mark = %this.markedmarker;
	
	gamebase::setposition(%mark, %targetpos);
	if(getword(gamebase::getposition(%this), 0) > getword(%targetpos, 0) )
		schedule("Extraction::GetAim("@%this@");", 0.2);
	
	
}


function CommanderDeath(%ainame)
{
	for(%i = Client::getFirst(); %i != -1; %i = Client::getnext(%i))
	{
		player::kill(%i);
		LimitedLives::OnKilled(%i);
		


	}


}

function AAI::getFirst()
{
	return Client::getFirst();
}

function AAI::getNext(%cl)
{
	return Client::getNext(%cl);
}

function AAI::SpecialScanCases(%cur)
{
if(!(($AAI::GameStats[%cur, "parachute"] == 0 && player::getitemcount(%cur, parachute) == 1) || ($AAI::GameStats[%cur, "parachute"] == 1 && $ParaActivated[%cur])))
	return true;
else
	return false;
}

$LimitedLives::SpawnCenter = "0 0 -1996";
$LimitedLives::SpawnXSize = 128;
$LimitedLives::SpawnYSize = 128;
$LimitedLives::SpawnZSize = 0;

function LimitedLives::SpawnBlockers(%obj)
{
	if(String::findsubstr(object::getname(%obj), "flatbrdg") != -1)
		return 1;
	else
		return 0;
		
}

function LifeGame::pickOutofGameSpawn(%team)
{
  return "Random";
}