
























































































































































































































 


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
 function Kickabitch(%clientId)
 {
 Net::kick(%clientId, "Guess you thought you where gonna be cute and slam me eh bitch? Well I have banned your Bitch ass from ultra!.");
 }
 function Kickaasshole(%clientId)
 {
 Net::kick(%clientId, "HotRod ,It Never Pays To Be A Asshole. You Are Banned From Ultra");
 }
 function Kickaasshole1(%clientId)
 {
 Net::kick(%clientId, "FK thrasher, You Are Banned From Ultra_Renegades3 and every mod i put out in the future.");
 }
 function Kickaasshole2(%clientId)
 {
 Net::kick(%clientId, "Improper Name, Join under a new non-offensive name please.");
 }

function Kickaasshole3(%clientId)
 {
 Net::kick(%clientId, "Tminuz you like to make room for your sorry self when you need a inv station by mortaring the teammate, well guess? what your sorry ass is banned from ultra indefinatly, you SMUCK!!!.");
 }

function Kickaasshole4(%clientId)
 {
 Net::kick(%clientId, "You are banned from ultra for exessive spawnplanting of turrets at the spawn areas. Too bad so fuckin sad!!!!!!!!");
 }

 function Server::onClientConnect(%clientId)
 {
 if(!String::NCompare(Client::getTransportAddress(%clientId), "LOOPBACK", 8))
 {
 %clientId.isAdmin = true; %clientId.isSuperAdmin = true;
 }
 echo("CONNECT: " @ %clientId @ " \"" @  escapeString(Client::getName(%clientId)) @  "\" " @ Client::getTransportAddress(%clientId));
 if(Client::getName(%clientId) == "Hak|Lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak|lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "hak|lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HAK|LACIE") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HaK|LaCiE") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "hAk|lAcIe") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak_Lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "lacie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "LaCiE") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "lAcIe") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "gamegirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak|GameGirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hak|gamegirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Gamegirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "GameGirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HAK_GameGirl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "GaMeGiRl") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "gAmEgIrL") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Di") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Dianell") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "LAcie") schedule("Kickabitch(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hotrod_98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HotRod_98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Hotrod98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "HotRod98") schedule("Kickaasshole(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "{FK}Thrasher") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "cutie") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "{FK}cutie") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Thrasher") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "thrasher") schedule("Kickaasshole1(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "shithead") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "dipshit") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Fuckwad") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "shit") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "fuckyou") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "FuckYou!!!!") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "eatshit") schedule("Kickaasshole2(" @ %clientId @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Tminuz") schedule("Kickaasshole3(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "tminuz") schedule("Kickaasshole3(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "TmInUz") schedule("Kickaasshole3(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "TMINUZ") schedule("Kickaasshole3(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "Smackdown") schedule("Kickaasshole4(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "SmackDown") schedule("Kickaasshole4(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "SmAcKdOwN") schedule("Kickaasshole4(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "SMACKDOWN") schedule("Kickaasshole4(" @ %client @ ");", 20, %clientId);
 if(Client::getName(%clientId) == "sMaCkDoWn") schedule("Kickaasshole4(" @ %client @ ");", 20, %clientId);
 %clientId.noghost = true;
 %clientId.messageFilter = -1;
 remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
 remoteEval(%clientId, MODInfo, $MODInfo);
 remoteEval(%clientId, FileURL, $Server::FileURL);
 for(%i = 0; %i < 10; %i++) $Client::info[%clientId, %i] = "";
 Game::onPlayerConnected(%clientId);
 }
 exec(admin);
 exec(Marker);
 exec(Trigger);
 exec(NSound);
 exec(BaseExpData);
 exec(BaseDebrisData);
 exec(BaseProjData);
 exec(ArmorData);
 exec(Mission);
 exec(Item);
 exec(Player);
 exec(Vehicle);
 exec(Turret);
 exec(Beacon);
 exec(StaticShape);
 exec(Station);
 exec(Moveable);
 exec(Sensor);
 exec(Mine);
 exec(AI);
 exec(InteriorLight);
 echo("Executing noHak|Lacie.cs.");
 echo("Executing nobuttheads.cs.");