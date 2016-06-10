__author__ = 'danvo'

import socket
import json
from MyMessage import*

HOST = ''
PORT = 8888
ADDRESS = (HOST,PORT)

# create a new socket object (server)
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# bind  socket to the address
server_socket.bind(ADDRESS)
print "...Socket Server bind complete..."

server_socket.listen(100)
print("...Chat server started on port " + str(PORT) + "...")

# new connection
sockfd, addr = server_socket.accept()
print "...Server connected to Client...", addr

# Data received from client
data_receive = receive_msg(sockfd)
print "...Server received the content of table from Client..."

# Send data already received from client to the client
print "...Server send data, which already is received from client, back to the client..."
send_msg(sockfd, data_receive)
print

# Store data into file Track_List.txt
f = open("Track_List.txt", "w")
f.write(data_receive)
f.close()
print "Stored data"

# Close connection
sockfd.close()
server_socket.close()
print "...Connection to client is closed..."
