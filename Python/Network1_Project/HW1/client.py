__author__ = 'danvo'

import urllib
from HTML_table_parser import HTMLTableParser
import json
import socket
from MyMessage import*

URL = "http://en.wikipedia.org/wiki/Metallica_(album)"


def read_url(url):
    # Read the given URL and decode the response as UTF-8.
    return urllib.urlopen(url).read().decode('unicode_escape').encode('ascii', 'ignore')


def read_ith_table(url, i):
    # Read the content of i-th table in all of tables from given URL
    html_content = read_url(url)
    p = HTMLTableParser()
    p.feed(html_content)
    return p.tables[i]


def standarise_table(table):
    # delete unnecessary elements in table
    table.pop()
    table[0].pop()
    return table


def parse_table_to_JSON(table):
    # Parsing table to JSON format
    dict = []
    for row in table[1:]:
        dict.append({table[0][0]: row[0].replace('"', ''), table[0][1]: row[1].replace('"', ''), table[0][2]: row[2].replace('"', ''), table[0][3]: row[3].replace('"', '')})
        #json.dumps(row)

    return json.dumps(dict, indent=3)  # Convert Python nested dictionary/list to JSON (output as string).


def scrape_table_from_wiki():
    """I extract the table which have information of the album (5th table in all of tables in HTML file)
     such as No, Title, Music and Length
    """
    table = read_ith_table(URL, 4)

    table = standarise_table(table)

    json_table = parse_table_to_JSON(table)

    return json_table


if __name__ == '__main__':
    # Scraping the content of table in given wikipedia url
    table_content = scrape_table_from_wiki()

    # Set up a connection between client and server
    HOST = 'localhost'
    PORT = 8888  # port from before
    ADDRESS = (HOST, PORT)

    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect(ADDRESS)
    print"...Client connected to server..."

    # Client send content of table scraping from wiki to server
    print
    send_msg(client_socket, table_content)
    print "...Client sent the content of table from Server..."

    # Data received from server
    data = receive_msg(client_socket)
    print "...Client received data from Server..."

    # Compare the original data scraped from wikipedia with data received from server
    print "...Comparing data sent to server with received from server..."
    if(data == table_content):
        print "\t YES, they are the same "
    else:
        print '\t NO, the data maybe lost'

    client_socket.close()
    print "...Connection to server is closed..."
