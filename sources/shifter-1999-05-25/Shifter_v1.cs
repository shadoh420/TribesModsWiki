$Shifter::PersonalSkin = True;			//== Personal Skins On or Off

$Shifter::AutoSuperAdmin = True;		//== Auto Super Admin
$Shifter::AdminName = "Name1";			//== AutoSuper Admin Player Name 1 -- Names ARE Case SeNsEtIvE
$Shifter::AdminIP = "*.*.*.*";			//== AutoSuper Admin IP 1
$Shifter::AdminName1 = "Name2";			//== AutoSuper Admin Player Name 2 -- Names ARE Case SeNsEtIvE
$Shifter::AdminIP1 = "*.*.*.*";			//== AutoSuper Admin IP 2
$Shifter::AdminName2 = "Name3";			//== AutoSuper Admin Player Name 3 -- Names ARE Case SeNsEtIvE
$Shifter::AdminIP2 = "*.*.*.*";			//== AutoSuper Admin IP 3  

$Shifter::SpawnRandom = True;			//== Turn on Random Spawn Setup?
$Shifter::AreThereBots = True;			//== Are there bots?
$Shifter::VoteAdmin = False;			//== Can players initiate vote to admin
$Shifter::VoteKick = True;				//== Can players initiate vote to kick

//======================================================= Admin Checking Scheme
function Shifter::CheckAdmin(%cl){
     %address = Client::getTransportAddress(%cl);
     //%string = String::replace(%address, ":", " ");
	 
     %ip1 = getword(%string,1);
     %ip2 = $Shifter::AdminIP;
	 
     %name1 = Client::getName(%cl);
     %name2 = $Shifter::AdminName;
	 
     for(%i = 0; %i < 4; %i++)
	 {
       %ipword1[%i] = getword(%string1,%i);
       %ipword2[%i] = getword(%string2,%i);
     }
	   
//======================================================= Check Admin And IP

 if((%ipword1[0] == %ipword2[0]) || (%ipword2[0] =="*"))
     %word1 = true;

 if((%ipword1[1] == %ipword2[1]) || (%ipword2[1] =="*"))
     %word2 = true;
	 
 if((%ipword1[2] == %ipword2[2]) || (%ipword2[2] =="*"))
     %word3 = true;
	 
 if((%ipword1[3] == %ipword2[3]) || (%ipword2[3] =="*"))
     %word4 = true;
	 
 if((%name1 == %name2) || (%name2 =="*"))
     %word5 = true;
	 
 if(%word1 && %word2 && %word3 && %word4 && %word5)
     return true;
	 	 
//======================================================= Check Admin1 And IP1

     %ip2 = $Shifter::AdminIP1;
     %name2 = $Shifter::AdminName1;


 if((%ipword1[0] == %ipword2[0]) || (%ipword2[0] =="*"))
     %word1 = true;
	 
 if((%ipword1[1] == %ipword2[1]) || (%ipword2[1] =="*"))
     %word2 = true;
	 
 if((%ipword1[2] == %ipword2[2]) || (%ipword2[2] =="*"))
     %word3 = true;
	 
 if((%ipword1[3] == %ipword2[3]) || (%ipword2[3] =="*"))
     %word4 = true;
	 
 if((%name1 == %name2) || (%name2 =="*"))
     %word5 = true;
	 
 if(%word1 && %word2 && %word3 && %word4 && %word5)
     return true;

//======================================================= Check Admin1 And IP1

     %ip2 = $Shifter::AdminIP2;
     %name2 = $Shifter::AdminName2;

 if((%ipword1[0] == %ipword2[0]) || (%ipword2[0] =="*"))
     %word1 = true;
	 
 if((%ipword1[1] == %ipword2[1]) || (%ipword2[1] =="*"))
     %word2 = true;
	 
 if((%ipword1[2] == %ipword2[2]) || (%ipword2[2] =="*"))
     %word3 = true;
	 
 if((%ipword1[3] == %ipword2[3]) || (%ipword2[3] =="*"))
     %word4 = true;
	 
 if((%name1 == %name2) || (%name2 =="*"))
     %word5 = true;
	 
 if(%word1 && %word2 && %word3 && %word4 && %word5)
     return true;

 else
     return false;
}    






















