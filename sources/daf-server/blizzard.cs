
function WindLoop()
{
	%blasts = floor(getRandom()*0)+20;
	%blaststr = getRandom()*$MaxWindBlastSize;
	if(%blaststr<$MaxWindBlastSize/3)
		%wav = "~wwind1.wav";
	else
		%wav = "~wwind2.wav";

	messageall(0, %wav);
	%x = (2*getRandom()*$MaxXYWind)-$MaxXYWind;
	%y = (2*getRandom()*$MaxXYWind)-$MaxXYWind;
	%z = (2*getRandom()*$MaxZWind);
	%dir = vector::scale(vector::normalize(%x@" "@%y@" "@%z), %blaststr);
	//messageall(0, %dir@" ("@%blaststr@")");
	for(%x = 0; %x<=5; %x= %x+5/%blasts)
	{
		schedule("group::iteraterecursive(\"MissionCleanup\", Windblast, \""@%dir@"\", "@%blaststr@");", %x);
	}
	schedule("group::iteraterecursive(\"MissionCleanup\", ResetTrees);", 5.1);
	%snowdir = %blaststr*100@" "@getword(%dir, 0)*50@" "@getword(%dir, 1)*50;
	
	//echo(%snowdir);
	MakeSnow(%snowdir);
	%time = 6+getRandom()*10;
	schedule("WindLoop();", %time);
}

function WindBlast(%this, %dir, %str)
{
	if(getobjecttype(%this) == "Player"&&client::getcontrolobject(player::getclient(%this))==%this)
	{
		%t=gamebase::getmuzzletransform(%this);
		%w=getword(%t, 3)@" "@getword(%t, 4)@" "@getword(%t, 5);
		%rot = vector::getrotation(%w);
		%rot = %rot;
		//%rot = ($pi/2 + getword(%rot, 0));
		%apply = true;
		if((gamebase::getlosinfo(%this, 20, (0)-(getword(%rot, 0))@" 0 0")))
		{
		if($LOS::OBJECT.WindProtect)
		{
		//echo("COVER!");
		%apply = false;
		}
		}
		
		%dirrot = getword(vector::getrotation(vector::normalize(%dir)),2);
		%losrot = ($pi/2)-getword(%rot, 0)@" 0 "@%dirrot-getword(%rot, 2);

		if(gamebase::getlosinfo(%this, 1.75, %losrot))
		{
		%apply = false;
		//echo("FRONTAL COVER! "@vector::getdistance(getword($los::position, 0)@" "@getword($los::position, 1)@" 0",getword(gamebase::getposition(%this), 0)@" "@getword(gamebase::getposition(%this), 1)@" 0"));
		
		}
		
		if(%apply)
			player::applyimpulse(%this, %dir);
		
	}
	
	if(getobjecttype(%this) == "Item")
	{
		if((gamebase::getlosinfo(%this, 20, $Pi/2@" 0 0")))
		{
		if($LOS::OBJECT.WindProtect)
		{
		return;
		}
		}
		item::setvelocity(%this, vector::add(item::getvelocity(%this), %dir) );
	}
	if(getobjecttype(%this) == "Mine")
	{
		%data = GameBase::getDataName(%this);
		if(%data == "Handgrenade")
			{
			//messageall(0, item::getvelocity(%this));
						item::setvelocity(%this, vector::add(item::getvelocity(%this), vector::scale(%dir, 0.1)) );
			gamebase::setposition(%this, vector::add(vector::scale(item::getvelocity(%this), 0.075), gamebase::Getposition(%this)));

			}
		else
			messageall(0, %data);
	}
	if(getobjecttype(%this) == "Grenade")
	{
				item::setvelocity(%this, vector::add(item::getvelocity(%this), vector::scale(%dir, 0.1)) );
			gamebase::setposition(%this, vector::add(vector::scale(item::getvelocity(%this), 0.075), gamebase::Getposition(%this)));

	}
	if(getobjecttype(%this) == "StaticShape"&&Object::getname(%this)=="tree")
	{
		
		%mult = vector::sub("1 1 1", %this.normal);
		%mult = "1 1 1";
		%rot = vector::getrotation(vector::mult(vector::normalize(%dir), %mult));
		%rot = (%str/($MaxWindBlastSize*2))*(getword(%rot, 0)+((getRandom()*0.1)-0.05))@" 0 "@getword(%rot, 2)+((getRandom()*0.1)-0.05);
		gamebase::setrotation(%this, %rot);
		
	}
	

	
}

function FixSpawns(%this)
{
	if(getobjecttype(%this) == "Marker")
	{
		%data = GameBase::getDataName(%this);
		echo(%data);
		if(%data == "DropPointMarker")
		{
			
			//if(gamebase::Getteam(%this)>-1)
			//{
				%rot = gamebase::getrotation(%this);
				gamebase::setrotation(%this, "0 0 "@getword(%rot, 2));
				%pos = gamebase::getposition(%this);
				gamebase::setposition(%this, vector::add(%pos, "0 0 10"));
				if((gamebase::getlosinfo(%this, 200, 0*$Pi@" 0 0")))
				{
					echo("MOVED");
					gamebase::setposition(%this,$LOS::position);
				}
				else
				{
				echo("HERE");
				gamebase::setposition(%this, %pos);
				}
			//}
		
		}
	//echo("MARKER: "@%data);
	}

}

function vector::mult(%v1, %v2)
{
%q = "";
	for(%x = 0; %x <3; %x++)
	{
	%v = getword(%v1, %x);
	%p = getword(%v2, %x);
	%r = %v * %p;
	%q = %q @ %r @ " ";
	}
	return %q;
}
function ResetTrees(%this)
{
	$echonow = 1;
	if(getobjecttype(%this) == "StaticShape"&&Object::getname(%this)=="tree")
	{
		
			
			
		gamebase::setrotation(%this, %this.normalrot);

	}
	MakeSnow("1000 "@getRandom()*10-5@" "@getRandom()*10-5);
}

$treescale = 0.2;
$MaxXYWind = 10;
$MaxZWind = 2;
$MaxWindBlastSize = 30;
//StaticShapeData TreeShape
//StaticShapeData TreeShapeTwo
$TreeMax = 100;
function MakeTrees(%misX, %misY, %misW, %misH)
{
	for(%i = 0; %i<$TreeMax; %i++)
	{
		%test = newObject("ForceBeacon","StaticShape","ForceBeacon",true);
		gamebase::setrotation(%test, -1*$pi/2 @ " 0 0");
		%loop = true;
		while(%loop)
		{
			
			%X = %misx ; 
			%W = getRandom() * (%misw) - (%misw/2); 					
			%Y = %misY; 
			%H = getRandom() * (%misH) - (%misH/2); 					
			%tx = %X + %W; 
			%ty = %Y + %H; 
			%tz = 500;
			%pos = %tx@" "@%ty@" "@%tz;
			
 			gamebase::setposition(%test, %pos);
 
   			if(gamebase::getlosinfo(%test, 5000))
   		   	{
				
				if(getobjecttype($LOS::Object) == "SimTerrain")
				{
					%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType | $SimInteriorObjectType | $SimPlayerObjectType,$LOS::Position,3,3,5,0);
					//echo(%num@" "@%pos);
					if(%num==0)
					{
						%tag = "";
						if(getRandom()>0.5)
							%tag = "Two";

						%tree = newObject("Tree", StaticShape, "TreeShape"@%tag);
   						addToSet("MissionCleanup", %tree);
						%tree.normal = $LOS::Normal;
						%tree.normalrot = vector::getrotation($LOS::Normal);
						gamebase::setrotation(%tree, %tree.normalrot);
						gamebase::setposition(%tree, $LOS::Position);
						%loop = false;
						//%marker = newobject("Tree #"@%x+1@"/"@$TreeMax, Marker, MapMarker, "Tree #"@%x+1@"/"@$TreeMax);
						//gamebase::setposition(%marker, gamebase::getposition(%tree));
						//Gamebase::setMapName(%marker,"Tree #"@%x+1@"/"@$TreeMax);
						//GameBase::setTeam(%marker,-1);
						//addToSet("MissionCleanup", %marker);
					}
				}
			}
		}
	}
	MakeSnow("-35 0 0");
	
}
function MakeSnow(%d)
{
if($snow!="")
	deleteobject($snow);

$Snow = newobject(Snow, Snowfall, getword(%d, 0), getword(%d, 1), getword(%d, 2), 0);
addToSet("MissionCleanup", $Snow);
}
