exec(shieldmounts);

function DisplayShields(%this, %lnum)
{
	if(Gamebase::getenergy(%this) < 0.002) {
		GameBase::applyDamage(%this, $AsphyxiationDamageType, 0.005, GameBase::getPosition(%this), "0 0 0", "0 0 0", Player::getClient(%this));	
	}
	%num = floor(getrandom()*18+1);
	while(%num == %lnum)
	{
		%num = floor(getrandom()*18+1);
	}
	player::unmountitem(%this, 5);
	player::mountitem(%this, "S"@%num, 5);
	Gamebase::setEnergy(%this, Gamebase::GetEnergy(%this) - 0.002);
	
	
	if(%this.shieldStrength)
		schedule("DisplayShields("@%this@","@%num@");",0.1,%this);
	else
		player::unmountitem(%this, 5);
}


// Ice's Shield Sphere Show Effect

function DisplayFlierShields(%this)
{
	%rot = vector::normalize(getrandom()-0.5@" "@getrandom()-0.5@" "@getrandom()-0.5);
	GameBase::activateShield(%this, %rot);
	if(%this.shieldStrength)
		schedule("DisplayShields3("@%this@");",0.3,%this);
}

function ShellPort(%this, %vec)
{
	if(%this.shieldStrength) {
		GameBase::activateShield(%this, %vec);
		Gamebase::setEnergy(%this, Gamebase::GetEnergy(%this) - 0.001);
	}
}

function ShellPort2(%this, %num)
{
player::unmountitem(%this, 5);
	if(%this.shieldStrength) {
		
		player::mountitem(%this, "S"@%num, 5);
		Gamebase::setEnergy(%this, Gamebase::GetEnergy(%this) - 0.001);
	}
}

function ShellFlash(%this)
{
for(%i = 1; %i <= 6; %i++) 
	{
		player::mountitem(%this, "S"@%i, %i-1);
	}
	schedule("ShellunFlash("@%this@");", 0.5);
}

function ShellShell(%this)
{
for(%i = 1; %i <= 6; %i++) 
	{
		player::mountitem(%this, "S"@%i, %i-1);
	}
}

function Shell2Flash(%this)
{
for(%i = 1; %i <= 6; %i++) {
		player::unmountitem(%this, %i-1);
	}
for(%i = 9; %i <= 16; %i++) 
	{
		player::mountitem(%this, "S"@%i, %i-9);
	}
	schedule("ShellUnFlash("@%this@");", 0.5);
}

function ShellUnFlash(%this, %num)
{
for(%i = 1; %i <= 6; %i++) {
		player::unmountitem(%this, %i-1);
	}
}
//- My masterpiece of Vector working, 18 vectors to form a sphere
function HAPC::Deflectors(%this)
{
	%rot1  = GameBase::getRotation(%this);                                  	   //- rotation aim forward
	%rot2  = Vector::Add(GameBase::getRotation(%this),"0 0 3.141592654");   	   //- rotation aim back
	%rot3  = Vector::Add(GameBase::getRotation(%this),"0 0 -1.570796327");  	   //- rotation aim left
	%rot4  = Vector::Add(GameBase::getRotation(%this),"0 0 1.570796327");   	   //- rotation aim right
	%rot5  = Vector::Add(GameBase::getRotation(%this),"1.570796327 0 0");   	   //- rotation aim up
	%rot6  = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0 0");  	   //- rotation aim down
	%rot7  = Vector::Add(GameBase::getRotation(%this),"-0.7853981635 0 0");		   //- rotation aim down/forward
	%rot8  = Vector::Add(GameBase::getRotation(%this),"0.7853981635 0 0");  	   //- rotation aim up/forward
	%rot9  = Vector::Add(GameBase::getRotation(%this),"-3.9269908175 0 0");            //- rotation aim down/back
	%rot10 = Vector::Add(GameBase::getRotation(%this),"3.9269908175 0 0");             //- rotation aim up/back
	%rot11 = Vector::Add(GameBase::getRotation(%this),"0 0 -0.7853981635");            //- rotation aim left/forward
	%rot12 = Vector::Add(GameBase::getRotation(%this),"0 0 0.7853981635");             //- rotation aim right/forward
	%rot13 = Vector::Add(GameBase::getRotation(%this),"0 0 -3.9269908175");            //- rotation aim left/back
	%rot14 = Vector::Add(GameBase::getRotation(%this),"0 0 3.9269908175");             //- rotation aim right/back
	%rot15 = Vector::Add(GameBase::getRotation(%this),"1.570796327 0.7853981635 0");   //- rotation aim up/right
	%rot16 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0.7853981635 0");  //- rotation aim down/right
	%rot17 = Vector::Add(GameBase::getRotation(%this),"1.570796327 -0.7853981635 0");  //- rotation aim up/left
	%rot18 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 -0.7853981635 0"); //- rotation aim down/left
	%vec1  = Vector::getFromRot(%rot1,10);
	%vec2  = Vector::getFromRot(%rot2,10);
	%vec3  = Vector::getFromRot(%rot3,10);
	%vec4  = Vector::getFromRot(%rot4,10);
	%vec5  = Vector::getFromRot(%rot5,10);
	%vec6  = Vector::getFromRot(%rot6,10);
	%vec7  = Vector::getFromRot(%rot7,10);
	%vec8  = Vector::getFromRot(%rot8,10);
	%vec9  = Vector::getFromRot(%rot9,10);
	%vec10 = Vector::getFromRot(%rot10,10);
	%vec11 = Vector::getFromRot(%rot11,10);
	%vec12 = Vector::getFromRot(%rot12,10);
	%vec13 = Vector::getFromRot(%rot13,10);
	%vec14 = Vector::getFromRot(%rot14,10);
	%vec15 = Vector::getFromRot(%rot15,10);
	%vec16 = Vector::getFromRot(%rot16,10);
	%vec17 = Vector::getFromRot(%rot17,10);
	%vec18 = Vector::getFromRot(%rot18,10);
	GameBase::playSound(%this,SoundShield,2);
	schedule("GameBase::activateShield("@%this@",\""@%vec2@"\");",0.05,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec3@"\");",0.10,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec4@"\");",0.15,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec5@"\");",0.20,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec6@"\");",0.25,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec7@"\");",0.30,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec8@"\");",0.35,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec9@"\");",0.40,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec10@"\");",0.45,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec11@"\");",0.50,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec12@"\");",0.55,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec13@"\");",0.60,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec14@"\");",0.65,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec15@"\");",0.70,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec16@"\");",0.75,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec17@"\");",0.80,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec18@"\");",0.85,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec1@"\");",0.90,%this);

	schedule("GameBase::activateShield("@%this@",\""@%vec2@"\");",0.01,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec3@"\");",0.02,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec4@"\");",0.03,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec5@"\");",0.04,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec6@"\");",0.05,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec7@"\");",0.06,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec8@"\");",0.07,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec9@"\");",0.08,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec10@"\");",0.09,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec11@"\");",0.10,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec12@"\");",0.11,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec13@"\");",0.12,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec14@"\");",0.13,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec15@"\");",0.14,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec16@"\");",0.15,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec17@"\");",0.16,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec18@"\");",0.17,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec1@"\");",0.18,%this);
//	GameBase::activateShield(%this,%vec2);
//	GameBase::activateShield(%this,%vec3);
//	GameBase::activateShield(%this,%vec4);
//	GameBase::activateShield(%this,%vec5);
//	GameBase::activateShield(%this,%vec6);
//	GameBase::activateShield(%this,%vec7);
//	GameBase::activateShield(%this,%vec8);
//	GameBase::activateShield(%this,%vec9);
//	GameBase::activateShield(%this,%vec10);
//	GameBase::activateShield(%this,%vec11);
//	GameBase::activateShield(%this,%vec12);
//	GameBase::activateShield(%this,%vec13);
//	GameBase::activateShield(%this,%vec14);
//	GameBase::activateShield(%this,%vec15);
//	GameBase::activateShield(%this,%vec16);
//	GameBase::activateShield(%this,%vec17);
//	GameBase::activateShield(%this,%vec18);
//	GameBase::activateShield(%this,%vec1);
	if(%this.superShield)
		schedule("HAPC::Deflectors("@%this@");",0.2,%this);
}
