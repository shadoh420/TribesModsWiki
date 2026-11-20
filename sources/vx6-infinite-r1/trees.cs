// =================================================================
//  U L T R A   R E N E G A D E S   V X 6   I N F I N I T E    +]-[+  
// =================================================================
// Copyright © 2005 +]-[+Armageddon+. List of credits in credits.txt


if focusServer
	focusClient
	simTreeCreate ServerTree MainWindow server
	simTreeAddSet ServerTree manager
endif

simTreeCreate ClientTree MainWindow
simTreeAddSet ClientTree manager
