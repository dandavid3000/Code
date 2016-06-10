__author__ = 'danvo'

import os
import sys
import time
import pytsk3
from pytsk3 import *

def isDir(f):
    return f.info.name.type ==pytsk3.TSK_FS_NAME_TYPE_DIR
def isFile(f):
    return f.info.name.type ==pytsk3.TSK_FS_NAME_TYPE_REG

def numberoffile(path):
    directory = fs.open_dir(path)
    global nof

    for f in directory:
        if isFile(f):
            nof = nof + 1
        elif isDir(f):
            fname = f.info.name.name
            if fname !='.' and fname!='..':
                newpath = path +fname+ '/'
                numberoffile(newpath)
    return nof

def get_slack(inode):
    global blocksize

    f = fs.open_meta(inode=inode)
    size = f.info.meta.size

    if size % blocksize != 0:
        nob = size / blocksize + 1 #number of block
        l_d_size = size % blocksize #last data size
        l_block = (nob - 1) * blocksize #Offset last block

    else:
        nob = size / blocksize
        l_block = size
        l_d_size = blocksize

    slack_size = blocksize - l_d_size

    if (l_block + l_d_size < nob * blocksize):
        data=f.read_random(l_block+l_d_size,slack_size,TSK_FS_ATTR_TYPE_DEFAULT, 0, TSK_FS_FILE_READ_FLAG_SLACK)
    else:
        data = None

    return data,slack_size
def progress(c, total, suffix=''):
    bar_len = 40
    filled_len = int(round(bar_len * c / float(total)))

    percents = round(100.0 * c / float(total), 1)
    bar = '=' * filled_len + '-' * (bar_len - filled_len)

    sys.stdout.write('[%s] %s%s ...%s\r' % (bar, percents, '%', suffix))

def recoveryFile(path, nof):
    global files
    global count

    directory = fs.open_dir(path)

    for f in directory:
        if isFile(f):
            finode = f.info.meta.addr
            fname = f.info.name.name
            count = count + 1
            time.sleep(0.1)
           # print count
            progress(count,nof,suffix='')
            data,slack_size = get_slack(finode)
            if data != None:
                files.append((finode,fname,slack_size))
                fi = open(subdir+str(finode),'w')
                fi.write(str(data))
                fi.close()

        elif isDir(f):
            fname = f.info.name.name
            if fname !='.' and fname!='..':
                newpath = path +fname+ '/'
                recoveryFile(newpath, nof)


pathImage = sys.argv[1]
#pathImage = '/home/danvo/Desktop/disk-image'
subdir = 'results/'

if not os.path.exists(subdir):
    os.makedirs(subdir)

img = pytsk3.Img_Info(pathImage)
fs = pytsk3.FS_Info(img)

blocksize = fs.info.block_size
files = []
count = 0
nof = 0
numberoffile('/')
#print nof
recoveryFile('/', nof)

#print ('Done!')