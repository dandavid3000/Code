import pytsk3
import time
import sys
from optparse import OptionParser
import os

parser = OptionParser()	# -f : ko can thiet lam => bo!
parser.add_option("-f", "--file", dest="filename",
                  help="disk image", metavar="FILE",default="/home/trhuy/disk.img")

(options, args) = parser.parse_args()

pathImage= options.filename


# doc file, image
img = pytsk3.Img_Info(pathImage)
fs = pytsk3.FS_Info(img) # lay file system cua image
numfiles =0
percent = 0
subdir = 'slackData/'
if not os.path.exists(subdir):	# tao thu muc xuat ket qua
    os.makedirs(subdir)

blocksize = fs.info.block_size	# lay blocksize cua fS
files = []

# in progress bar
def updateProcess(progress):
	barLength = 1
	block = int(round(barLength*progress))
	text = "\rProcess: [{0}] {1}% {2}".format( "#"*block + "-"*(barLength-block), int(round(progress)),'')
    	sys.stdout.write(text)
    	sys.stdout.flush()

def isDir(f):
	return f.info.name.type == pytsk3.TSK_FS_NAME_TYPE_DIR
def isFile(f):
	return f.info.name.type == pytsk3.TSK_FS_NAME_TYPE_REG
def getSlack (inode):
	global percent
	f = fs.open_meta(inode=inode)
	
	if f.info.meta.size > 0:
		last_offset = 0

    
		
		# lay file size
		filesize = f.info.meta.size

		if filesize % blocksize != 0:
			number of block = filesize / blocksize + 1

			size_data_in_last_block = filesize % blocksize
			last_block = (numberofblock -1 = =filesize/blocksize) * blocksize	

		else:( ko co slack)
			numberofblock = filesize / blocksize 
						
			
		slack_size = blocksize - size_data_in_last_block
		
		if (last_block + size_data_in_last_block < number of block x blocksize):	
		# read_random = doc du lieu tren dia => block tuong doi
			data = f.read_random(last_block + size_data_in_last_block, slack_size)
		else:
			data=None
		return data,slack_size
	else:
		return None,None

# dem cac tat ca cac file trong FS ==> hien thi % cho nguoi dung
def getTotalFile(path):
	global numfiles
	directory = fs.open_dir(path)
        listFile = []
        listDir = []
        for x in directory:
		if isFile(x):
			listFile.append(x)
                elif isDir(x):
                         listDir.append(x)

        for f in listFile:
                fInode= f.info.meta.addr
                fName = f.info.name.name
                fSize = f.info.meta.size
		numfiles = numfiles + 1
       	for d in listDir:
                fInode= d.info.meta.addr
                fName = d.info.name.name
                fSize = d.info.meta.size
                if fName != '.' and fName != '..':
			newpath = path + fName + '/'
                        getTotalFile(newpath)

# path = duong dan thu muc
def fwalk(path):
	global percent
	try:
		directory = fs.open_dir(path)
		listFile = []
		listDir = []
		for x in directory:
			if isFile(x):
				listFile.append(x)
			elif isDir(x):
				listDir.append(x)

		for f in listFile:
			fInode= f.info.meta.addr
			fName = f.info.name.name
			fSize = f.info.meta.size
			percentInc = 100.0 / numfiles
			percent = percent + percentInc
			updateProcess(percent)
			time.sleep(0.5)
		#	print fInode,fName,fSize
		#	print getSlack(fInode)
			data,slack_size = getSlack(fInode)
			if data != None:
				files.append((fInode,fName,slack_size))
				fi = open(subdir+str(fInode),'w') # thu muc hien tai (trong file python dang chay)
				fi.write(str(data))
				fi.close()
			#print 'Slack Content:' + str(getSlack(fInode))
			#print len(listDir)
		for d in listDir:
			try:
				fInode= d.info.meta.addr
				fName = d.info.name.name
				fSize = d.info.meta.size
				if fName != '.' and fName != '..':
					newpath = path + fName + '/'
					fwalk(newpath)
			except:# tai vi co mot so FS ma trong do co mot so file ko lay duoc inode => catch
				#raise => bo raise vi ko can thiet, cu tiep tuc chay
	except:
		raise
getTotalFile("/")
#print numfiles
fwalk("/")
#print files
sys.stdout.write('\n')

# in ra console ko can thiet!!!!

print("\r {0:10} | {1:70} | {2:30}".format('inode', 'Filename' , 'Slack size'))
print("{}".format("-"*110))
for i in files:
	print("\r {0:10} | {1:70} | {2:30}".format(i[0], i[1] , i[2]))
