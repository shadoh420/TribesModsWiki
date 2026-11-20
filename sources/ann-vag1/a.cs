// Plasmatics super secret test file
// for testing purposes only



















//MissionCenterPos
//containerBoxFillSet(set,mask,position,length,width,height,optional height);
//

//bindAction(mouse0, zaxis0, TO, IDACTION_INC_SNIPER_FOV, 1.000000);
//bindAction(mouse0, zaxis1, TO, IDACTION_INC_SNIPER_FOV, -1.000000);

//bindCommand(mouse0, zaxis0, TO, "nextWeapon();");
//bindCommand(mouse0, zaxis1, TO, "prevWeapon();");

//Control::getPosition
//Persistent::TaggedClass<MissionCenterPos>
//Control::setValue Control::getValue
//Control::getExtent Control::setExtent
//Control::setText Control::getText TextList::Clear TextList::AddLine
//hitShapeName
//baseDamageType
//whirSound
//
//
//newObject("MissionCenter", MissionCenterPos, -(%tw / 2), -(%tw / 2), %tw, %tw);
//addToSet("MissionGroup\\World", "MissionCenter");
//

// functions by Plasmatic
function dance()
{
	if($dance)
		$dance = false;
	else	
	{
		$dance = true;	
		getdown(%anim);
	}
}
function getdown(%anim)
{
	if(!$dance)
		return;
	%anim++;
	if(%anim>12) 
		%anim = 0;
	remoteEval(2048, playAnimWav, %anim);	
	schedule("getdown("@%anim@");",2);	
}

function center()
{
// damn mission center is hard wired into .exe.. bah -plasmatic	
	//%group = nameToID("MissionGroup\\Landscape\\MissionCenter");

	%group = 716;
	%x = %group.x;
	%y = %group.y;
	%h = %group.h;
	%w = %group.w;
	echo("!! Mission center#"@%group@" x,"@%x@" y,"@%y@" w,"@%w@" h,"@%h@" name,"@%group.name);
	echo("position,"@gamebase::getposition(%group)@" extent,"@%group.extent);
	
// quit trying to glean mission center... -plas	
// bah, screwit.. besides bouncing a droid player object around, the borders will remain a mystery..	
}
//
//remoteEval(2048, lmsg, Say::GetWav(%name) );			//local message
//remoteEval(2048, playAnimWav, %anim, Say::GetWav(%name) );	//animation
//remoteEval(2048, say, 1, %msg @ "~w" @ Say::GetWav(%name) );	//team
//remoteEval(2048, say, 0, %msg @ "~w" @ Say::GetWav(%name) ); 	//global

//testing idactions

//testing crap
function Chat(%client)
{
	//bindAction(keyboard0, make, "t", TO, IDACTION_CHAT, 0.000000);
	//bindAction(keyboard0, make, "y", TO, IDACTION_CHAT, 1.000000);	
	schedule("postAction(2048, IDACTION_CHAT, 1);",3);
	schedule("postAction(2048, IDACTION_CHAT, 0);",5);
	//schedule("postAction(2048, IDACTION_TURNLEFT, -0);", $PrestoPref::TurnAroundTime);
}
function Aim()
{
	if($AutoAim::enabled)
	{
		%accessSeed=floor(getRandom()*1024);
		if(%accessSeed<64)
		{
			postAction(2048,IDACTION_TURNRIGHT,0);postAction(2048,IDACTION_TURNLEFT,0.5);
			schedule("Aim();",0.1+getRandom()*0.3);
		}
		else if(%accessSeed<128)
		{
			postAction(2048,IDACTION_LOOKDOWN,0);
			postAction(2048,IDACTION_LOOKUP,0.3);
			schedule("Aim();",0.1+getRandom()*0.3);
		}
		else if(%accessSeed<192)
		{
			postAction(2048,IDACTION_LOOKUP,0);
			postAction(2048,IDACTION_LOOKDOWN,0.3);
			schedule("Aim();",0.1+getRandom()*0.3);
		}
		else if(%accessSeed<255)
		{
			postAction(2048,IDACTION_TURNLEFT,0);
			postAction(2048,IDACTION_TURNRIGHT,0.5);
			schedule("Aim();",0.1+getRandom()*0.3);
		}
		else
		{
			postAction(2048,IDACTION_FIRE1,1);
			postAction(2048,IDACTION_TURNLEFT,0);
			postAction(2048,IDACTION_LOOKUP,0);
			postAction(2048,IDACTION_LOOKDOWN,0);
			postAction(2048,IDACTION_TURNRIGHT,0);
			schedule("Aim();",0.1+getRandom()*0.3);
		}
	}
	else
	{
		postAction(2048,IDACTION_BREAK1,1);
		postAction(2048,IDACTION_TURNLEFT,0);
		postAction(2048,IDACTION_LOOKUP,0);
		postAction(2048,IDACTION_LOOKDOWN,0);
		postAction(2048,IDACTION_TURNRIGHT,0);
	}
}

// end testing crap..



function AnnStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } 



function String::replaceChar(%string, %search, %replace)
{
	%len = AnnStrLen(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	}
	return %string;
}

function damage(%client)
{
	%player = Client::getOwnedObject(%client);
	%data = GameBase::getDataName(%client);
	%dam = GameBase::getDamageLevel(%Player);

	%damage = (%data.maxDamage)/4;


	GameBase::setDamageLevel(%player, %dam + %damage);
}



function test(%client)
{     	
	%player = Client::getOwnedObject(%client);
	%pos = vector::add(gamebase::getposition(%player),"0 0 2");
	//%obj = newObject(%name,InteriorShape,%shape);
	//%obj = newObject(RepairPack,item,armorpack);
	%item = "repairpack";
	%obj = newObject("","Item",%item,1,true,true);	//rotates
	//%obj = newObject("","Item",%item,1,false);
 	//schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	addToSet("MissionCleanup", %obj);	
	
	
	%obj.rotates = true;
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);	
	
	
}

function sound(%name)
{
	$voicenumber++;
	%sound = "male"@$voicenumber@".w"@%name@".wav";
	client::sendmessage(2049, 0, %sound@"~w"@%sound);
	if ($voicenumber <5 )schedule("sound("@%name@");",2);
	else {
		$voicenumber= "";
		schedule("soundf("@%name@");",2);
	}	
}
function soundf(%name)
{
	$voicenumber++;
	%sound = "female"@$voicenumber@".w"@%name@".wav";
	client::sendmessage(2049, 0, %sound@"~w"@%sound);
	if ($voicenumber <5 )schedule("soundf("@%name@");",2);
	else 	$voicenumber= "";	
}


function float(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = GameBase::getDataName(%player);
	%armor = Player::getArmor(%player);
	%armortype = $ArmorName[%armor];
		
		%mass = 13;	
		//%mass = %player.mass;
		//%mass = Player::getArmor(%player).mass;
		echo(%armor,%mass);	
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%player),0,%mass * 1);
		Player::applyImpulse(%player,%jumpDir);
		
		
		//playSound(SoundFireGrenade, GameBase::getPosition(%client));
	if($float)schedule("float("@%client@");",0.075);
	
}




// repositions player with a defined vector
function a(%client){
	%player = Client::getOwnedObject(%client);
	%prot =GameBase::getRotation(%player);
	%pos = GameBase::getPosition(%client);
	echo("old pos  ",%pos);
	%vec = "2 4 1";
	%vec = rotateVector(%vec,%prot);
	echo("rotated vec ",%vec);
	%newloc = vector::add(%vec,%pos);	
	echo("new pos  ",%newloc);
	GameBase::SetPosition(%client, %newloc);
	}

// rotates around the z axis only
// for player rotations -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
// reduce angle to the correct range
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
// break vector down to components
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vec3= getWord(%vec,2);
	%vc = %vec2;
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5); 
// calculate offset to left or right
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
// put it back together with new offset
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
// calculate and add forward and vertical components
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}

function modify(%type, %var, %multi, %return, %nocheck) 
{ 
     %max = getNumItems();  
     for (%i = 0; %i < %max; %i = %i + 1) 
     {  
          %item = getItemData(%i); 
          if((String::findSubStr(%type.className,%name) != "-1") && (String::findSubStr(%type,%item.className) != "-1")) 
          { 
               if(!%nocheck) 
               { 
                    if(%item.imageType != "") 
                         %item = %item.imageType; 
                    if((String::findSubStr("armor",%type) != "-1") && (String::findSubStr(%type,"armor") != "-1")) 
                    { 
                         %armorType = true; 
                         %item2 = $ArmorType[Female, %item]; 
                         %item = $ArmorType[Male, %item]; 
                    } 
               } 
 
               if(!%return && %item != "") 
               { 
                    if(!$parsed[%item]) 
                    { 
                         $parsed[%item] = true; 
                         eval("parsedOld["@%item@"] = "@%item@"."@%var@";"); 
                         if(%armorType) 
                              eval("parsedOld["@%item2@"] = "@%item2@"."@%var@";"); 
                    } 
                    eval(%item@"."@%var@" = "@%multi@" * "@%item@"."@%var@";"); 
                    if(%armorType) 
                         eval(%item2@"."@%var@" = "@%multi@" * "@%item2@"."@%var@";"); 
               } 
               else if(%return && $parsed[%item]) 
               { 
                    eval(%item@"."@%var@" = "@$parsedOld[%item]@";"); 
                    if(%armorType) 
                         eval(%item2@"."@%var@" = "@$parsedOld[%item2]@";"); 
               } 
          } 
     } 
}



addExportText("															");
addExportText("// Annihilation Teleporter											");
addExportText("// copyright July, 2002 Steve Madden aka Plasmatic								");
addExportText("															");
addExportText("// This file is included in Annihilation mod, and needs to be included with 					");
addExportText("// any map created with Annihilation mod that uses teleporters							");	
addExportText("// created with the map editor.											");
addExportText("															");
addExportText("// Annihilation teleporters feature possible multiple random drop points, 					");
addExportText("// visible or invisible tele entry points,									");
addExportText("// and painless integration into the mission editor.								");
addExportText("//														");
addExportText("															");
addExportText("// www.annihilation.info												");
addExportText("// ziptiezmail@netscape.net											");
addExportText("// -Plasmatic													");
addExportText("															");
addExportText("$UsingAnnTeleCS = true;												");
addExportText("//========================= stuff needed for other mods.. -plasmatic						");
addExportText("															");
addExportText("															");
addExportText("//function modified to work with Annihilation, yet still compatable with base, and other mods.			");
addExportText("function GroupTrigger::onEnter(%this,%object)									");
addExportText("{														");
addExportText("	%type = getObjectType(%object);											");
addExportText("	if(%type == \"Player\" || %type == \"Vehicle\") {								");
addExportText("		if(%this.TeleTrigger == true)										");
addExportText("		{													");
addExportText("			// Teleporters created with Annihilation mod have a TeleTrigger field				");
addExportText("			// for the object in the .mis file -plasmatic							");
addExportText("			TeleTrigger::onTrigEnter(%this, %object);							");
addExportText("		}													");
addExportText("		else													");
addExportText("		{													");
addExportText("			%group = getGroup(%this); 									");
addExportText(" 			%count = Group::objectCount(%group);							");
addExportText(" 			for (%i = 0; %i < %count; %i++) 							");
addExportText(" 				GameBase::virtual(Group::getObject(%group,%i),\"onTrigEnter\,%object,%this);	");
addExportText(" 		}												");
addExportText("	}														");
addExportText("}														");
addExportText("															");
addExportText("//searches group for drop points, If more than one, picks random. -plasmatic					");
addExportText("function TeleTrigger::onTrigEnter(%this,%object)									");
addExportText("{														");
addExportText("															");
addExportText("	%type = getObjectType(%object);											");
addExportText("	if(%type == \"Player\" || %type == \"Vehicle\" || %type == \"Flier\")						");
addExportText("	{														");
addExportText("		%client = Player::getclient(%object);									");
addExportText("		if(GameBase::getControlClient(%object) != %client) %client = GameBase::getControlClient(%object);	");
addExportText("		if(Client::getTeam(%client) != GameBase::getTeam(%this) && GameBase::getTeam(%this) != -1) return;	");
addExportText("		%group = getGroup(%this);										");
addExportText(" 		%count = Group::objectCount(%group);								");
addExportText(" 		for(%i = 0; %i < %count; %i++)									");
addExportText(" 			{ 											");
addExportText(" 			%data = GameBase::getDataName(Group::getObject(%group,%i));				");
addExportText(" 			if(%data == DropPointMarker) 								");
addExportText(" 				{										");
addExportText(" 				%DropCount++;									");
addExportText(" 				%droppos = Group::getObject(%group,%i);						");
addExportText(" 				%teleset = nameToID(\"MissionCleanup/TeleportSet\"@%this);			");
addExportText("				if(%teleset == -1)									");
addExportText("				{											");
addExportText("					%group = newObject(\"TeleportSet\"@%this, SimSet);				");
addExportText("					addToSet(MissionCleanup, %group);						");
addExportText("				}											");
addExportText(" 				addToSet(\"MissionCleanup/TeleportSet\"@%this, %droppos);			");
addExportText(" 				}										");
addExportText(" 			}											");
addExportText(" 														");
addExportText("	// pick a random tele point within the set -plasmatic								");
addExportText(" 			%spawnIdx = floor(getRandom() * (%DropCount - 0.1));					");
addExportText("			%group = nameToID(\"MissionCleanup/TeleportSet\"@%this);					");	
addExportText(" 			%newpos = Group::getObject(%group,%spawnIdx);						");
addExportText(" 														");
addExportText(" 		if(GameBase::GetPosition(%newpos) != \"0 0 0\")							");
addExportText(" 			{											");
addExportText(" 			GameBase::playSound(%object, ForceFieldOpen, 0);					");
addExportText("			GameBase::playSound(%this, ForceFieldOpen, 0);							");
addExportText("			Client::sendMessage(%client, 0, \"You have been teleported.~wshieldhit.wav\");			");
addExportText("			GameBase::SetPosition(%object, GameBase::GetPosition(%newpos));					");
addExportText("			%Trot = GameBase::getRotation(%newpos); 							");
addExportText("			GameBase::setRotation(%object,%Trot);								");
addExportText("			GameBase::startFadeIn(%object);									");
addExportText(" 			} 											");
addExportText(" 		else echo(\"!! WARNING !! No matching teleport drop point in group!!\");				");	
addExportText("	}														");
addExportText("}														");
addExportText("															");
addExportText("															");

//end workspace -plasmatic