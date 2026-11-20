///-----------------------------------------------
/// description = "JailGun";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------

LightningData jailbolt
{
  bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 4.0;
   coneAngle        = 1.0;
   damagePerSec      = 0.01;
   energyDrainPerSec = 60.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%aclient = Player::getClient(%target);
if(getObjectType(%target) != "Player")
      {
       return;
      }


if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
        {
        return;
        }


    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%target);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%shooterId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%target);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%target,GameBase::GetPosition(%o));
                        Client::sendMessage(%client,0,"You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 20 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
                        schedule("jLargeForceField::jailSesame("@%target@");",20);
                    }
                    }

}