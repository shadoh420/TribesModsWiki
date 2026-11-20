// - = - = - = - = - = - = - = - = - = - = - = - \\
//      U l t r a  R e n e g a d e s  V X E      \\
// - = - = - = - = - = - = - = - = - = - = - = - \\
//tress.cs


#
#
#

# Make sure the server manager exists
#
if focusServer
	focusClient
	simTreeCreate ServerTree MainWindow server
	simTreeAddSet ServerTree manager
endif

# Client manager always exists
#
simTreeCreate ClientTree MainWindow
simTreeAddSet ClientTree manager
