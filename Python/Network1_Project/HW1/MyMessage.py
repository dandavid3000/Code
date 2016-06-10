__author__ = 'Ledvic'

import struct

def send_msg(sock, msg):
    # Prefix each message with a 4-byte length (network byte order)
    msg = struct.pack('>I', len(msg)) + msg
    sock.sendall(msg)


def receive_msg(sock):
    # Read the length of message and unpack it into an integer
    raw_len_msg = receive_all(sock, 4)
    if not raw_len_msg:
        return None
    len_msg = struct.unpack('>I', raw_len_msg)[0]
    # Read the message data
    return receive_all(sock, len_msg)


def receive_all(sock, n_byte):
    # Helper function to receive n_byte bytes or return None if EOF is hit
    data = ''
    while len(data) < n_byte:
        packet = sock.recv(n_byte - len(data))
        if not packet:
            return None
        data += packet
    return data